namespace ConvertXMLToExcell
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rdExcelToXML = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExportFolder = new System.Windows.Forms.TextBox();
            this.btnChoiceFolderExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnChoiceImportFolder = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnConvert = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdXmlToExcel = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdExcelToXML
            // 
            this.rdExcelToXML.AutoSize = true;
            this.rdExcelToXML.Location = new System.Drawing.Point(186, 29);
            this.rdExcelToXML.Name = "rdExcelToXML";
            this.rdExcelToXML.Size = new System.Drawing.Size(88, 17);
            this.rdExcelToXML.TabIndex = 10;
            this.rdExcelToXML.TabStop = true;
            this.rdExcelToXML.Text = "Excel to XML";
            this.rdExcelToXML.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Export Folder:";
            // 
            // txtExportFolder
            // 
            this.txtExportFolder.Location = new System.Drawing.Point(86, 66);
            this.txtExportFolder.Name = "txtExportFolder";
            this.txtExportFolder.ReadOnly = true;
            this.txtExportFolder.Size = new System.Drawing.Size(297, 20);
            this.txtExportFolder.TabIndex = 13;
            // 
            // btnChoiceFolderExport
            // 
            this.btnChoiceFolderExport.Location = new System.Drawing.Point(389, 64);
            this.btnChoiceFolderExport.Name = "btnChoiceFolderExport";
            this.btnChoiceFolderExport.Size = new System.Drawing.Size(75, 23);
            this.btnChoiceFolderExport.TabIndex = 12;
            this.btnChoiceFolderExport.Text = "...";
            this.btnChoiceFolderExport.UseVisualStyleBackColor = true;
            this.btnChoiceFolderExport.Click += new System.EventHandler(this.btnChoiceFolderExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Import Folder:";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(86, 30);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(297, 20);
            this.txtFolder.TabIndex = 10;
            // 
            // btnChoiceImportFolder
            // 
            this.btnChoiceImportFolder.Location = new System.Drawing.Point(389, 28);
            this.btnChoiceImportFolder.Name = "btnChoiceImportFolder";
            this.btnChoiceImportFolder.Size = new System.Drawing.Size(75, 23);
            this.btnChoiceImportFolder.TabIndex = 9;
            this.btnChoiceImportFolder.Text = "...";
            this.btnChoiceImportFolder.UseVisualStyleBackColor = true;
            this.btnChoiceImportFolder.Click += new System.EventHandler(this.btnChoiceImportFolder_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 68);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(452, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(389, 26);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 16;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChoiceImportFolder);
            this.groupBox1.Controls.Add(this.txtFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnChoiceFolderExport);
            this.groupBox1.Controls.Add(this.txtExportFolder);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 109);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Folder";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConvert);
            this.groupBox2.Controls.Add(this.rdXmlToExcel);
            this.groupBox2.Controls.Add(this.rdExcelToXML);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Location = new System.Drawing.Point(12, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(487, 100);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // rdXmlToExcel
            // 
            this.rdXmlToExcel.AutoSize = true;
            this.rdXmlToExcel.Location = new System.Drawing.Point(12, 29);
            this.rdXmlToExcel.Name = "rdXmlToExcel";
            this.rdXmlToExcel.Size = new System.Drawing.Size(92, 17);
            this.rdXmlToExcel.TabIndex = 9;
            this.rdXmlToExcel.TabStop = true;
            this.rdXmlToExcel.Text = "XML To Excel";
            this.rdXmlToExcel.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 272);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton rdExcelToXML;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExportFolder;
        private System.Windows.Forms.Button btnChoiceFolderExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnChoiceImportFolder;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdXmlToExcel;
    }
}

