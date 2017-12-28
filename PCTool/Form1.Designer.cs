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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SelectFileBtn = new System.Windows.Forms.Button();
            this.AddDescriptionBtn = new System.Windows.Forms.Button();
            this.SelectFileLbl = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GenerateExcelBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FileId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filepath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.SelectFileBtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AddDescriptionBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.SelectFileLbl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DescriptionBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.GenerateExcelBtn, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(868, 571);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // SelectFileBtn
            // 
            this.SelectFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFileBtn.Location = new System.Drawing.Point(10, 10);
            this.SelectFileBtn.Margin = new System.Windows.Forms.Padding(10);
            this.SelectFileBtn.Name = "SelectFileBtn";
            this.SelectFileBtn.Size = new System.Drawing.Size(153, 30);
            this.SelectFileBtn.TabIndex = 0;
            this.SelectFileBtn.Text = "Select File";
            this.SelectFileBtn.UseVisualStyleBackColor = true;
            this.SelectFileBtn.Click += new System.EventHandler(this.SelectFileBtn_Click);
            // 
            // AddDescriptionBtn
            // 
            this.AddDescriptionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddDescriptionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddDescriptionBtn.Location = new System.Drawing.Point(10, 60);
            this.AddDescriptionBtn.Margin = new System.Windows.Forms.Padding(10);
            this.AddDescriptionBtn.Name = "AddDescriptionBtn";
            this.AddDescriptionBtn.Size = new System.Drawing.Size(153, 30);
            this.AddDescriptionBtn.TabIndex = 2;
            this.AddDescriptionBtn.Text = "Add description";
            this.AddDescriptionBtn.UseVisualStyleBackColor = true;
            this.AddDescriptionBtn.Click += new System.EventHandler(this.AddDescriptionBtn_Click);
            // 
            // SelectFileLbl
            // 
            this.SelectFileLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectFileLbl.AutoSize = true;
            this.SelectFileLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SelectFileLbl.Location = new System.Drawing.Point(176, 10);
            this.SelectFileLbl.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.SelectFileLbl.Name = "SelectFileLbl";
            this.SelectFileLbl.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.SelectFileLbl.Size = new System.Drawing.Size(514, 30);
            this.SelectFileLbl.TabIndex = 1;
            this.SelectFileLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionBox.Location = new System.Drawing.Point(176, 63);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(514, 24);
            this.DescriptionBox.TabIndex = 1;
            this.DescriptionBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DescriptionBox_Enter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileId,
            this.Filepath});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(687, 465);
            this.dataGridView1.TabIndex = 4;
            // 
            // GenerateExcelBtn
            // 
            this.GenerateExcelBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GenerateExcelBtn.AutoSize = true;
            this.GenerateExcelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateExcelBtn.Location = new System.Drawing.Point(702, 318);
            this.GenerateExcelBtn.Name = "GenerateExcelBtn";
            this.GenerateExcelBtn.Size = new System.Drawing.Size(156, 35);
            this.GenerateExcelBtn.TabIndex = 5;
            this.GenerateExcelBtn.Text = "Generate Excel";
            this.GenerateExcelBtn.UseVisualStyleBackColor = true;
            this.GenerateExcelBtn.Click += new System.EventHandler(this.GenerateExcelBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.Tag = "";
            // 
            // FileId
            // 
            this.FileId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.FileId.HeaderText = "Description";
            this.FileId.Name = "FileId";
            this.FileId.Width = 108;
            // 
            // Filepath
            // 
            this.Filepath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Filepath.HeaderText = "Filepath";
            this.Filepath.Name = "Filepath";
            this.Filepath.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 571);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(525, 200);
            this.Name = "Form1";
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
        private System.Windows.Forms.Button AddDescriptionBtn;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button GenerateExcelBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filepath;
    }
}

