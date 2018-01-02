namespace PCTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.DescriptionLbl = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FileId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filepath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenerateExcelBtn = new System.Windows.Forms.Button();
            this.AddtoListBtn = new System.Windows.Forms.Button();
            this.SelectFileLbl = new System.Windows.Forms.Label();
            this.OutputDirLbl = new System.Windows.Forms.Label();
            this.OutputDirBox = new System.Windows.Forms.TextBox();
            this.BrowseDirBtn = new System.Windows.Forms.Button();
            this.OutputFilenameLbl = new System.Windows.Forms.Label();
            this.OutputFilenameBox = new System.Windows.Forms.TextBox();
            this.ExtensionLbl = new System.Windows.Forms.Label();
            this.DeleteFilesBtn = new System.Windows.Forms.Button();
            this.SelectFileBtn = new System.Windows.Forms.Button();
            this.InputFileLbl = new System.Windows.Forms.Label();
            this.DisclaimerLbl = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.DescriptionBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.DescriptionLbl, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.GenerateExcelBtn, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.AddtoListBtn, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.SelectFileLbl, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.OutputDirLbl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.OutputDirBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BrowseDirBtn, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.OutputFilenameLbl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.OutputFilenameBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ExtensionLbl, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.DeleteFilesBtn, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.SelectFileBtn, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.InputFileLbl, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.DisclaimerLbl, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1025, 694);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.DescriptionBox, 2);
            this.DescriptionBox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionBox.Location = new System.Drawing.Point(208, 160);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(660, 29);
            this.DescriptionBox.TabIndex = 4;
            this.DescriptionBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DescriptionBox_Enter);
            // 
            // DescriptionLbl
            // 
            this.DescriptionLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionLbl.AutoSize = true;
            this.DescriptionLbl.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLbl.Location = new System.Drawing.Point(3, 154);
            this.DescriptionLbl.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.DescriptionLbl.Name = "DescriptionLbl";
            this.DescriptionLbl.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.DescriptionLbl.Size = new System.Drawing.Size(192, 42);
            this.DescriptionLbl.TabIndex = 10;
            this.DescriptionLbl.Text = "Description:";
            this.DescriptionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileId,
            this.Filepath});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 4);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(10, 203);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1005, 394);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.TabStop = false;
            // 
            // FileId
            // 
            this.FileId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.FileId.HeaderText = "Description";
            this.FileId.Name = "FileId";
            this.FileId.Width = 130;
            // 
            // Filepath
            // 
            this.Filepath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Filepath.HeaderText = "Filepath";
            this.Filepath.Name = "Filepath";
            this.Filepath.ReadOnly = true;
            // 
            // GenerateExcelBtn
            // 
            this.GenerateExcelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GenerateExcelBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateExcelBtn.ForeColor = System.Drawing.Color.DarkGreen;
            this.GenerateExcelBtn.Location = new System.Drawing.Point(874, 603);
            this.GenerateExcelBtn.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.GenerateExcelBtn.Name = "GenerateExcelBtn";
            this.GenerateExcelBtn.Size = new System.Drawing.Size(141, 44);
            this.GenerateExcelBtn.TabIndex = 6;
            this.GenerateExcelBtn.Text = "Generate Excel";
            this.GenerateExcelBtn.UseVisualStyleBackColor = true;
            this.GenerateExcelBtn.Click += new System.EventHandler(this.GenerateExcelBtn_Click);
            // 
            // AddtoListBtn
            // 
            this.AddtoListBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddtoListBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddtoListBtn.Location = new System.Drawing.Point(891, 160);
            this.AddtoListBtn.Margin = new System.Windows.Forms.Padding(20, 10, 10, 10);
            this.AddtoListBtn.Name = "AddtoListBtn";
            this.AddtoListBtn.Size = new System.Drawing.Size(124, 30);
            this.AddtoListBtn.TabIndex = 5;
            this.AddtoListBtn.Text = "Add to list";
            this.AddtoListBtn.UseVisualStyleBackColor = true;
            this.AddtoListBtn.Click += new System.EventHandler(this.AddToListBtn_Click);
            // 
            // SelectFileLbl
            // 
            this.SelectFileLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectFileLbl.AutoSize = true;
            this.SelectFileLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.SelectFileLbl, 2);
            this.SelectFileLbl.Location = new System.Drawing.Point(208, 110);
            this.SelectFileLbl.Margin = new System.Windows.Forms.Padding(3);
            this.SelectFileLbl.Name = "SelectFileLbl";
            this.SelectFileLbl.Padding = new System.Windows.Forms.Padding(5, 2, 0, 3);
            this.SelectFileLbl.Size = new System.Drawing.Size(660, 29);
            this.SelectFileLbl.TabIndex = 9;
            this.SelectFileLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OutputDirLbl
            // 
            this.OutputDirLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputDirLbl.AutoSize = true;
            this.OutputDirLbl.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputDirLbl.Location = new System.Drawing.Point(3, 4);
            this.OutputDirLbl.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.OutputDirLbl.Name = "OutputDirLbl";
            this.OutputDirLbl.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.OutputDirLbl.Size = new System.Drawing.Size(192, 42);
            this.OutputDirLbl.TabIndex = 10;
            this.OutputDirLbl.Text = "Output directory:";
            this.OutputDirLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OutputDirBox
            // 
            this.OutputDirBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.OutputDirBox, 2);
            this.OutputDirBox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputDirBox.Location = new System.Drawing.Point(208, 10);
            this.OutputDirBox.Name = "OutputDirBox";
            this.OutputDirBox.Size = new System.Drawing.Size(660, 29);
            this.OutputDirBox.TabIndex = 0;
            this.OutputDirBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DescriptionBox_Enter);
            // 
            // BrowseDirBtn
            // 
            this.BrowseDirBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseDirBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseDirBtn.Location = new System.Drawing.Point(891, 10);
            this.BrowseDirBtn.Margin = new System.Windows.Forms.Padding(20, 10, 10, 10);
            this.BrowseDirBtn.Name = "BrowseDirBtn";
            this.BrowseDirBtn.Size = new System.Drawing.Size(124, 30);
            this.BrowseDirBtn.TabIndex = 1;
            this.BrowseDirBtn.Text = "Browse";
            this.BrowseDirBtn.UseVisualStyleBackColor = true;
            this.BrowseDirBtn.Click += new System.EventHandler(this.BrowseDirBtn_Click);
            // 
            // OutputFilenameLbl
            // 
            this.OutputFilenameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputFilenameLbl.AutoSize = true;
            this.OutputFilenameLbl.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputFilenameLbl.Location = new System.Drawing.Point(3, 54);
            this.OutputFilenameLbl.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.OutputFilenameLbl.Name = "OutputFilenameLbl";
            this.OutputFilenameLbl.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.OutputFilenameLbl.Size = new System.Drawing.Size(192, 42);
            this.OutputFilenameLbl.TabIndex = 10;
            this.OutputFilenameLbl.Text = "Name output file:";
            this.OutputFilenameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OutputFilenameBox
            // 
            this.OutputFilenameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputFilenameBox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputFilenameBox.Location = new System.Drawing.Point(208, 60);
            this.OutputFilenameBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.OutputFilenameBox.Name = "OutputFilenameBox";
            this.OutputFilenameBox.Size = new System.Drawing.Size(612, 29);
            this.OutputFilenameBox.TabIndex = 2;
            this.OutputFilenameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OutputFilenameBox_Enter);
            // 
            // ExtensionLbl
            // 
            this.ExtensionLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ExtensionLbl.AutoSize = true;
            this.ExtensionLbl.Location = new System.Drawing.Point(820, 64);
            this.ExtensionLbl.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ExtensionLbl.Name = "ExtensionLbl";
            this.ExtensionLbl.Size = new System.Drawing.Size(42, 22);
            this.ExtensionLbl.TabIndex = 14;
            this.ExtensionLbl.Text = ".xlsx";
            // 
            // DeleteFilesBtn
            // 
            this.DeleteFilesBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DeleteFilesBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteFilesBtn.Location = new System.Drawing.Point(10, 603);
            this.DeleteFilesBtn.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.DeleteFilesBtn.Name = "DeleteFilesBtn";
            this.DeleteFilesBtn.Size = new System.Drawing.Size(142, 44);
            this.DeleteFilesBtn.TabIndex = 7;
            this.DeleteFilesBtn.Text = "Clear table";
            this.DeleteFilesBtn.UseVisualStyleBackColor = true;
            this.DeleteFilesBtn.Click += new System.EventHandler(this.DeleteFilesBtn_Click);
            // 
            // SelectFileBtn
            // 
            this.SelectFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectFileBtn.AutoSize = true;
            this.SelectFileBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFileBtn.Location = new System.Drawing.Point(891, 110);
            this.SelectFileBtn.Margin = new System.Windows.Forms.Padding(20, 10, 10, 10);
            this.SelectFileBtn.Name = "SelectFileBtn";
            this.SelectFileBtn.Size = new System.Drawing.Size(124, 30);
            this.SelectFileBtn.TabIndex = 3;
            this.SelectFileBtn.Text = "Select file";
            this.SelectFileBtn.UseVisualStyleBackColor = true;
            this.SelectFileBtn.Click += new System.EventHandler(this.SelectFileBtn_Click);
            // 
            // InputFileLbl
            // 
            this.InputFileLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.InputFileLbl.AutoSize = true;
            this.InputFileLbl.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputFileLbl.Location = new System.Drawing.Point(3, 104);
            this.InputFileLbl.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.InputFileLbl.Name = "InputFileLbl";
            this.InputFileLbl.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.InputFileLbl.Size = new System.Drawing.Size(192, 42);
            this.InputFileLbl.TabIndex = 10;
            this.InputFileLbl.Text = "Name input file:";
            this.InputFileLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DisclaimerLbl
            // 
            this.DisclaimerLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DisclaimerLbl.AutoSize = true;
            this.DisclaimerLbl.Location = new System.Drawing.Point(477, 664);
            this.DisclaimerLbl.Name = "DisclaimerLbl";
            this.DisclaimerLbl.Size = new System.Drawing.Size(70, 22);
            this.DisclaimerLbl.TabIndex = 15;
            this.DisclaimerLbl.TabStop = true;
            this.DisclaimerLbl.Text = "© 2018";
            this.DisclaimerLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DisclaimerLbl_LinkClicked);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.Filter = "XML files (*.xml) | *.xml";
            this.openFileDialog1.Tag = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1025, 694);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(525, 200);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ParamCompare Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button SelectFileBtn;
        private System.Windows.Forms.Label SelectFileLbl;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filepath;
        private System.Windows.Forms.Label DescriptionLbl;
        private System.Windows.Forms.Button AddtoListBtn;
        private System.Windows.Forms.Label OutputDirLbl;
        private System.Windows.Forms.TextBox OutputDirBox;
        private System.Windows.Forms.Button BrowseDirBtn;
        private System.Windows.Forms.Button DeleteFilesBtn;
        private System.Windows.Forms.Button GenerateExcelBtn;
        private System.Windows.Forms.Label OutputFilenameLbl;
        private System.Windows.Forms.TextBox OutputFilenameBox;
        private System.Windows.Forms.Label ExtensionLbl;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label InputFileLbl;
        private System.Windows.Forms.LinkLabel DisclaimerLbl;
    }
}

