namespace EmployessCRUD
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
            this.MainPicture = new System.Windows.Forms.PictureBox();
            this.EmployeesBtn = new System.Windows.Forms.Button();
            this.JobTitlesbtn = new System.Windows.Forms.Button();
            this.OfficesBtn = new System.Windows.Forms.Button();
            this.DepartmentsBtn = new System.Windows.Forms.Button();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.TurnOnEditBth = new System.Windows.Forms.Button();
            this.SqldataGridView = new System.Windows.Forms.DataGridView();
            this.TurnOffEditBth = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.JobTitlesLabel = new System.Windows.Forms.Label();
            this.TitlestextBox = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SqldataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPicture
            // 
            this.MainPicture.Image = ((System.Drawing.Image)(resources.GetObject("MainPicture.Image")));
            this.MainPicture.Location = new System.Drawing.Point(22, 53);
            this.MainPicture.Name = "MainPicture";
            this.MainPicture.Size = new System.Drawing.Size(708, 292);
            this.MainPicture.TabIndex = 0;
            this.MainPicture.TabStop = false;
            // 
            // EmployeesBtn
            // 
            this.EmployeesBtn.BackColor = System.Drawing.Color.Navy;
            this.EmployeesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EmployeesBtn.ForeColor = System.Drawing.Color.Navy;
            this.EmployeesBtn.Image = ((System.Drawing.Image)(resources.GetObject("EmployeesBtn.Image")));
            this.EmployeesBtn.Location = new System.Drawing.Point(43, 14);
            this.EmployeesBtn.Name = "EmployeesBtn";
            this.EmployeesBtn.Size = new System.Drawing.Size(163, 23);
            this.EmployeesBtn.TabIndex = 1;
            this.EmployeesBtn.Text = "Pracownicy";
            this.EmployeesBtn.UseVisualStyleBackColor = false;
            this.EmployeesBtn.Click += new System.EventHandler(this.EmployeesBtn_Click);
            // 
            // JobTitlesbtn
            // 
            this.JobTitlesbtn.BackColor = System.Drawing.Color.Navy;
            this.JobTitlesbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JobTitlesbtn.ForeColor = System.Drawing.Color.Navy;
            this.JobTitlesbtn.Image = ((System.Drawing.Image)(resources.GetObject("JobTitlesbtn.Image")));
            this.JobTitlesbtn.Location = new System.Drawing.Point(222, 13);
            this.JobTitlesbtn.Name = "JobTitlesbtn";
            this.JobTitlesbtn.Size = new System.Drawing.Size(163, 23);
            this.JobTitlesbtn.TabIndex = 2;
            this.JobTitlesbtn.Text = "Stanowiska";
            this.JobTitlesbtn.UseVisualStyleBackColor = false;
            this.JobTitlesbtn.Click += new System.EventHandler(this.JobTitlesbtn_Click);
            // 
            // OfficesBtn
            // 
            this.OfficesBtn.BackColor = System.Drawing.Color.Navy;
            this.OfficesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OfficesBtn.ForeColor = System.Drawing.Color.Navy;
            this.OfficesBtn.Image = ((System.Drawing.Image)(resources.GetObject("OfficesBtn.Image")));
            this.OfficesBtn.Location = new System.Drawing.Point(405, 13);
            this.OfficesBtn.Name = "OfficesBtn";
            this.OfficesBtn.Size = new System.Drawing.Size(163, 23);
            this.OfficesBtn.TabIndex = 3;
            this.OfficesBtn.Text = "Oddziały";
            this.OfficesBtn.UseVisualStyleBackColor = false;
            this.OfficesBtn.Click += new System.EventHandler(this.OfficesBtn_Click);
            // 
            // DepartmentsBtn
            // 
            this.DepartmentsBtn.BackColor = System.Drawing.Color.Navy;
            this.DepartmentsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DepartmentsBtn.ForeColor = System.Drawing.Color.Navy;
            this.DepartmentsBtn.Image = ((System.Drawing.Image)(resources.GetObject("DepartmentsBtn.Image")));
            this.DepartmentsBtn.Location = new System.Drawing.Point(583, 13);
            this.DepartmentsBtn.Name = "DepartmentsBtn";
            this.DepartmentsBtn.Size = new System.Drawing.Size(163, 23);
            this.DepartmentsBtn.TabIndex = 4;
            this.DepartmentsBtn.Text = "Działy";
            this.DepartmentsBtn.UseVisualStyleBackColor = false;
            this.DepartmentsBtn.Click += new System.EventHandler(this.DepartmentsBtn_Click);
            // 
            // CreateBtn
            // 
            this.CreateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateBtn.ForeColor = System.Drawing.Color.Navy;
            this.CreateBtn.Image = ((System.Drawing.Image)(resources.GetObject("CreateBtn.Image")));
            this.CreateBtn.Location = new System.Drawing.Point(42, 351);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(111, 23);
            this.CreateBtn.TabIndex = 5;
            this.CreateBtn.Text = "Dodaj";
            this.CreateBtn.UseVisualStyleBackColor = true;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateBtn.ForeColor = System.Drawing.Color.Navy;
            this.UpdateBtn.Image = ((System.Drawing.Image)(resources.GetObject("UpdateBtn.Image")));
            this.UpdateBtn.Location = new System.Drawing.Point(164, 351);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(111, 23);
            this.UpdateBtn.TabIndex = 6;
            this.UpdateBtn.Text = "Aktualizuj";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.ForeColor = System.Drawing.Color.Navy;
            this.DeleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeleteBtn.Image")));
            this.DeleteBtn.Location = new System.Drawing.Point(283, 351);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(111, 23);
            this.DeleteBtn.TabIndex = 7;
            this.DeleteBtn.Text = "Usuń";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // TurnOnEditBth
            // 
            this.TurnOnEditBth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TurnOnEditBth.ForeColor = System.Drawing.Color.Navy;
            this.TurnOnEditBth.Image = ((System.Drawing.Image)(resources.GetObject("TurnOnEditBth.Image")));
            this.TurnOnEditBth.Location = new System.Drawing.Point(565, 351);
            this.TurnOnEditBth.Name = "TurnOnEditBth";
            this.TurnOnEditBth.Size = new System.Drawing.Size(181, 23);
            this.TurnOnEditBth.TabIndex = 8;
            this.TurnOnEditBth.Text = "Włącz edycję";
            this.TurnOnEditBth.UseVisualStyleBackColor = true;
            this.TurnOnEditBth.Click += new System.EventHandler(this.TurnOnEditBth_Click);
            // 
            // SqldataGridView
            // 
            this.SqldataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.SqldataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SqldataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SqldataGridView.Location = new System.Drawing.Point(22, 53);
            this.SqldataGridView.Name = "SqldataGridView";
            this.SqldataGridView.Size = new System.Drawing.Size(742, 292);
            this.SqldataGridView.TabIndex = 9;
            this.SqldataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SqldataGridView_CellContentClick);
            // 
            // TurnOffEditBth
            // 
            this.TurnOffEditBth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TurnOffEditBth.ForeColor = System.Drawing.Color.Navy;
            this.TurnOffEditBth.Image = ((System.Drawing.Image)(resources.GetObject("TurnOffEditBth.Image")));
            this.TurnOffEditBth.Location = new System.Drawing.Point(565, 351);
            this.TurnOffEditBth.Name = "TurnOffEditBth";
            this.TurnOffEditBth.Size = new System.Drawing.Size(181, 23);
            this.TurnOffEditBth.TabIndex = 10;
            this.TurnOffEditBth.Text = "Wyłącz edycję";
            this.TurnOffEditBth.UseVisualStyleBackColor = true;
            this.TurnOffEditBth.Click += new System.EventHandler(this.TurnOffEditBth_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78F));
            this.tableLayoutPanel1.Controls.Add(this.JobTitlesLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TitlestextBox, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(352, 53);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(312, 33);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // JobTitlesLabel
            // 
            this.JobTitlesLabel.AutoSize = true;
            this.JobTitlesLabel.Location = new System.Drawing.Point(3, 0);
            this.JobTitlesLabel.Name = "JobTitlesLabel";
            this.JobTitlesLabel.Size = new System.Drawing.Size(62, 13);
            this.JobTitlesLabel.TabIndex = 0;
            this.JobTitlesLabel.Text = "Stanowisko";
            // 
            // TitlestextBox
            // 
            this.TitlestextBox.Location = new System.Drawing.Point(71, 3);
            this.TitlestextBox.Name = "TitlestextBox";
            this.TitlestextBox.Size = new System.Drawing.Size(208, 20);
            this.TitlestextBox.TabIndex = 1;
            // 
            // SaveBtn
            // 
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.ForeColor = System.Drawing.Color.Navy;
            this.SaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("SaveBtn.Image")));
            this.SaveBtn.Location = new System.Drawing.Point(549, 92);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(82, 23);
            this.SaveBtn.TabIndex = 12;
            this.SaveBtn.Text = "Zapisz";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 464);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.TurnOnEditBth);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.CreateBtn);
            this.Controls.Add(this.DepartmentsBtn);
            this.Controls.Add(this.OfficesBtn);
            this.Controls.Add(this.JobTitlesbtn);
            this.Controls.Add(this.EmployeesBtn);
            this.Controls.Add(this.MainPicture);
            this.Controls.Add(this.SqldataGridView);
            this.Controls.Add(this.TurnOffEditBth);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Employees Managment";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SqldataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPicture;
        private System.Windows.Forms.Button EmployeesBtn;
        private System.Windows.Forms.Button JobTitlesbtn;
        private System.Windows.Forms.Button OfficesBtn;
        private System.Windows.Forms.Button DepartmentsBtn;
        private System.Windows.Forms.Button CreateBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button TurnOnEditBth;
        private System.Windows.Forms.DataGridView SqldataGridView;
        private System.Windows.Forms.Button TurnOffEditBth;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label JobTitlesLabel;
        private System.Windows.Forms.TextBox TitlestextBox;
        private System.Windows.Forms.Button SaveBtn;
    }
}

