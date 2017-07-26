namespace EmployessCRUD
{
    partial class AddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddForm));
            this.NametextBox = new System.Windows.Forms.TextBox();
            this.SurnametextBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.HelptextBox = new System.Windows.Forms.TextBox();
            this.JobTitlecomboBox = new System.Windows.Forms.ComboBox();
            this.OfficecomboBox = new System.Windows.Forms.ComboBox();
            this.DepartmentcomboBox = new System.Windows.Forms.ComboBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NametextBox
            // 
            this.NametextBox.Location = new System.Drawing.Point(107, 3);
            this.NametextBox.Name = "NametextBox";
            this.NametextBox.Size = new System.Drawing.Size(186, 20);
            this.NametextBox.TabIndex = 6;
            // 
            // SurnametextBox
            // 
            this.SurnametextBox.Location = new System.Drawing.Point(107, 30);
            this.SurnametextBox.Name = "SurnametextBox";
            this.SurnametextBox.Size = new System.Drawing.Size(186, 20);
            this.SurnametextBox.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(107, 65);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // HelptextBox
            // 
            this.HelptextBox.Location = new System.Drawing.Point(273, 12);
            this.HelptextBox.Name = "HelptextBox";
            this.HelptextBox.Size = new System.Drawing.Size(100, 20);
            this.HelptextBox.TabIndex = 1;
            // 
            // JobTitlecomboBox
            // 
            this.JobTitlecomboBox.FormattingEnabled = true;
            this.JobTitlecomboBox.Location = new System.Drawing.Point(107, 103);
            this.JobTitlecomboBox.Name = "JobTitlecomboBox";
            this.JobTitlecomboBox.Size = new System.Drawing.Size(186, 21);
            this.JobTitlecomboBox.TabIndex = 9;
            // 
            // OfficecomboBox
            // 
            this.OfficecomboBox.FormattingEnabled = true;
            this.OfficecomboBox.Location = new System.Drawing.Point(107, 133);
            this.OfficecomboBox.Name = "OfficecomboBox";
            this.OfficecomboBox.Size = new System.Drawing.Size(186, 21);
            this.OfficecomboBox.TabIndex = 10;
            this.OfficecomboBox.SelectedIndexChanged += new System.EventHandler(this.OfficecomboBox_SelectedIndexChanged);
            // 
            // DepartmentcomboBox
            // 
            this.DepartmentcomboBox.FormattingEnabled = true;
            this.DepartmentcomboBox.Location = new System.Drawing.Point(107, 166);
            this.DepartmentcomboBox.Name = "DepartmentcomboBox";
            this.DepartmentcomboBox.Size = new System.Drawing.Size(186, 21);
            this.DepartmentcomboBox.TabIndex = 11;
            this.DepartmentcomboBox.SelectedIndexChanged += new System.EventHandler(this.DepartmentcomboBox_SelectedIndexChanged);
            // 
            // SaveBtn
            // 
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.ForeColor = System.Drawing.Color.Navy;
            this.SaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("SaveBtn.Image")));
            this.SaveBtn.Location = new System.Drawing.Point(220, 276);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(77, 23);
            this.SaveBtn.TabIndex = 6;
            this.SaveBtn.Text = "Zapisz";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.ForeColor = System.Drawing.Color.Navy;
            this.ExitBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExitBtn.Image")));
            this.ExitBtn.Location = new System.Drawing.Point(303, 276);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(77, 23);
            this.ExitBtn.TabIndex = 7;
            this.ExitBtn.Text = "Wróć";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.78261F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.21739F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.SurnametextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.OfficecomboBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.NametextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.JobTitlecomboBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.DepartmentcomboBox, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(56, 62);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.58974F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.41026F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(299, 195);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Dział:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nazwisko:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Imie:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Data zatrudnienia:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Stanowisko:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Oddział:";
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 378);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.HelptextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NametextBox;
        private System.Windows.Forms.TextBox SurnametextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox JobTitlecomboBox;
        private System.Windows.Forms.ComboBox OfficecomboBox;
        private System.Windows.Forms.ComboBox DepartmentcomboBox;
        private System.Windows.Forms.TextBox HelptextBox;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}