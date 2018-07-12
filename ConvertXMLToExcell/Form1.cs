using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ConvertXMLToExcell
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rdExcelToXML.Checked = true;
        }

        private List<ExportFile> getDataFromFolder(string path)
        {
            string[] filePaths = Directory.GetFiles(path, "*.xlsx", SearchOption.TopDirectoryOnly);
            var listAll = new List<ExportFile>();
            foreach (var filePath in filePaths)
            {
                var list = readDataFromExcel(filePath);
                if (list != null && list.Count > 0)
                    listAll.AddRange(list);
            }
            return listAll;
        }

        private bool updateFile(string path, List<ExportFile> words)
        {
            string text = File.ReadAllText(path);
            var temp = words.OrderByDescending(n => n.Length);
            foreach(var item in temp)
            {
                if(!string.IsNullOrWhiteSpace(item.English) && !string.IsNullOrWhiteSpace(item.NewLang))
                {
                    var regex = new Regex(Regex.Escape(item.English));
                    text = regex.Replace(text, item.NewLang, 1);
                }
            }
            
            File.WriteAllText(path, text);

            return true;
        }


        private List<ExportFile> readDataFromExcel(string path)
        {
            var list = new List<ExportFile>();
            var fileInfo = new FileInfo(path);

            using (var package = new ExcelPackage(fileInfo))
            {
                var workbook = package.Workbook;
                var worksheet = workbook.Worksheets.First();

                for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                {
                    string File = worksheet.Cells[i, 1].Value.ToString();
                    string English = worksheet.Cells[i, 2].Value.ToString();
                    string NewLang = worksheet.Cells[i, 3].Value.ToString();
                    var newLinesRegex = new Regex(@"\r\n|\n|\r", RegexOptions.Singleline);
                    List<string> listStr = newLinesRegex.Split(File).ToList();
                    foreach (var str in listStr)
                    {
                        if(!string.IsNullOrWhiteSpace(str))
                            list.Add(new ExportFile { File = str, English = English, NewLang = NewLang, Length = English.Length });
                    }
                    
                }
            }

            return list;
        }


        private async Task<bool> convertExcellToXML()
        {
            string pathExcel = txtFolder.Text;

            var listData = getDataFromFolder(pathExcel);

            var listFile = listData.GroupBy(n => n.File, (key, g) => new { File = key, Words = g.ToList() });
            foreach(var item in listFile)
            {
                string path = txtExportFolder.Text + item.File;
                updateFile(path, item.Words);
            }

            progressBar1.Value = 100;
            return true;
        }

        private async Task<bool> convertXMLToExcel()
        {
            string path = txtFolder.Text;

            DirectoryInfo directionInfo = new DirectoryInfo(path);
            string[] filePaths = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            List<ExportFile> listFile = new List<ExportFile>();

            IProgress<int> progress = new Progress<int>(v =>
            {
                // This lambda is executed in context of UI thread,
                // so it can safely update form controls
                Console.WriteLine(v);
                progressBar1.Value = v;
            });

            await Task.Run(() =>
            {
                progress.Report(50);
                try
                {
                    int i = 0;
                    foreach (var filePath in filePaths)
                    {
                        List<string> listStr = new List<string>();
                        string extension = GetPathFile(filePath);
                        if (extension == ".xml")
                        {
                            listStr = GetStringFromXML(filePath);
                        }
                        else if (extension == ".asp")
                        {
                            listStr = GetStringFromASP(filePath);
                        }

                        string tempPath = filePath.Replace(path, "");
                        foreach (var str in listStr)
                        {
                            listFile.Add(new ExportFile { File = tempPath, English = str });
                        }

                        if (i != 0 && filePaths.Length != 0)
                        {
                            double per = (double)i / (double)filePaths.Length * (double)100;
                            int percent = (int)Math.Floor(per);
                            if (percent > 0)
                            {
                                progress.Report(percent);
                            }
                        }

                        i++;
                    }

                    var list = listFile.GroupBy(n => n.English
                    , (key, g) => new
                    {
                        English = key,
                        File = g.Aggregate(string.Empty, (item, next) => item + next.File + Environment.NewLine)
                    });


                    DataTable dt = new DataTable();

                    dt.Columns.Add("File", typeof(string));
                    dt.Columns.Add("English", typeof(string));

                    foreach (var item in list)
                    {
                        dt.Rows.Add(item.File, item.English);
                    }

                    exportExcell(dt, "export.xlsx");
                    progress.Report(100);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            });

            return true;
        }

        private void exportExcell(DataTable dt, string fileName)
        {
            FileInfo file = new FileInfo(Path.Combine(txtExportFolder.Text, fileName));

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = null;
                var count = package.Workbook.Worksheets.Count(n => n.Name == "Accounts");
                if (count == 0)
                {
                    worksheet = package.Workbook.Worksheets.Add("Accounts");
                }
                else
                {
                    worksheet = package.Workbook.Worksheets.FirstOrDefault(n => n.Name == "Accounts");
                }
                int totalRows = dt.Rows.Count;
                worksheet.Cells[1, 1].Value = "File";
                worksheet.Cells[1, 2].Value = "English";
                int i = 0;
                for (int row = 2; row <= totalRows + 1; row++)
                {
                    worksheet.Cells[row, 1].Value = dt.Rows[i]["File"];
                    worksheet.Cells[row, 2].Value = dt.Rows[i]["English"];
                    i++;
                }

                package.Save();

            }
        }

        private string GetPathFile(string path)
        {
            return Path.GetExtension(path);
        }

        private List<string> GetStringFromXML(string path)
        {
            List<string> listStr = new List<string>();
            //Create the XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            //Display all the book titles.
            XmlNodeList elemList = doc.GetElementsByTagName("arwctl:Phrase");
            for (int i = 0; i < elemList.Count; i++)
            {
                listStr.Add(elemList[i].InnerXml);
            }

            return listStr;
        }

        private List<string> GetStringFromASP(string path)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            List<string> listStr = new List<string>();
            string readText = File.ReadAllText(path);

            if (string.IsNullOrWhiteSpace(readText)) return listStr;

            doc.LoadHtml(readText);

            foreach (HtmlAgilityPack.HtmlTextNode node in doc.DocumentNode.SelectNodes("//text()"))
            {
                string temp = node.Text;
                if (!string.IsNullOrEmpty(temp))
                    listStr.Add(temp);
            }
            return listStr;
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = 0;
                if (string.IsNullOrWhiteSpace(txtFolder.Text) || string.IsNullOrWhiteSpace(txtExportFolder.Text))
                {
                    MessageBox.Show("Please choice Folder Before");
                    return;
                }

                if (!rdExcelToXML.Checked && !rdXmlToExcel.Checked)
                {
                    MessageBox.Show("Please choice type of convert Before");
                    return;
                }


                if (rdXmlToExcel.Checked) await convertXMLToExcel();

                if (rdExcelToXML.Checked) await convertExcellToXML();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }

        private void btnChoiceImportFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Please select folder";
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtFolder.Text = fbd.SelectedPath;
        }

        private void btnChoiceFolderExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Please select folder";
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtExportFolder.Text = fbd.SelectedPath;
        }
    }

    public class ExportFile
    {
        public string File { get; set; }
        public string English { get; set; }
        public string NewLang { get; set; }
        public int? Length { get; set; }
    }
}
