using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace EmployessCRUD
{
    public partial class Form1 : Form
    {
        /*Deklaracje zmiennych globalnych*/
        bool IsClicked = false;
        int Key = 0;
        char key;
        string[] Offices = new string[50];
        SqlDataAdapter dataadapter;
        SqlCommandBuilder databuilder;
        DataSet ds;
        DataTable sTable;
        int[] IDs = new int[50]; //tablica z numerami ID pracowników;
        int[] IDj = new int[50];//tablica z indeksami ID stanowisk;
        int[] IDo = new int[50];
        int i = 0,J=0;
 
        public Form1()
        {
            InitializeComponent();
            SqldataGridView.Hide();
            tableLayoutPanel1.Hide();
            CreateBtn.Hide();
            UpdateBtn.Hide();
            UpdateBtn.Enabled = false;
            DeleteBtn.Hide();
            DeleteBtn.Enabled = false;
            TurnOnEditBth.Hide();
            TurnOffEditBth.Hide();
            SaveBtn.Hide();
            tableLayoutPanel2.Hide();
            tableLayoutPanel3.Hide();
            
            SqldataGridView.ReadOnly = false;
        }

        private void EmployeesBtn_Click(object sender, EventArgs e)
        {
            Key = 1;
            tableLayoutPanel3.Hide();
            tableLayoutPanel2.Hide();
            tableLayoutPanel1.Hide();
            SaveBtn.Hide();
            JobTitlesbtn.Enabled = true;
            DepartmentsBtn.Enabled = true;
            OfficesBtn.Enabled = true;
            SqldataGridView.Show();
            CreateBtn.Show();
            CreateBtn.Enabled = true;
            UpdateBtn.Show();
            UpdateBtn.Enabled = false;
            DeleteBtn.Show();
            DeleteBtn.Enabled = false;
            TurnOnEditBth.Show();
            MainPicture.Hide();
            string sql = "select p.id_pracownika as ID, p.imie as Imie, p.nazwisko as Nazwisko,  s.nazwa as Stanowisko, d.nazwa_dzialu as 'Nazwa działu', si.nazwa_siedziby as Siedziba, si.adres as Adres" +
                    " from PRACOWNICY p join DZIALY d on p.id_dzialu=d.id_dzialu join STANOWISKA s on p.id_stanowiska=s.id_stanowiska join SIEDZIBY si on d.id_siedziby=si.id_siedziby;";
            LoadDataToSqldataGridView("Pracownicy",sql);
            EmployeesBtn.Enabled = false;
        }

        private void TurnOnEditBth_Click(object sender, EventArgs e)
        {
            SqldataGridView.ReadOnly = false;
            CreateBtn.Enabled = false;
            UpdateBtn.Enabled = true;
            DeleteBtn.Enabled = true;
            TurnOnEditBth.Hide();
            TurnOffEditBth.Show();
        }

        private void TurnOffEditBth_Click(object sender, EventArgs e)
        {
            SqldataGridView.ReadOnly = false;
            CreateBtn.Enabled = true;
            UpdateBtn.Enabled = false;
            DeleteBtn.Enabled = false;
            TurnOnEditBth.Show();
            TurnOffEditBth.Hide();
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            key = 'c';
            switch (Key)
            {
                case 1: CreateEmployees(); break;
                case 2: tableLayoutPanel1.Show(); SaveBtn.Show(); MessageBox.Show("Stanowiska"); break;
                case 3: tableLayoutPanel2.Show(); SaveBtn.Show(); MessageBox.Show("Oddziały"); break;
                default: tableLayoutPanel3.Show(); SaveBtn.Show(); ComboBoxPreparation(); MessageBox.Show("Działy"); break;               
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            key = 'u';
            switch (Key) 
            {
                case 1: Load_Employees();  break;
                case 2: Load_JobTitles(); tableLayoutPanel1.Show(); SaveBtn.Show(); break;
                case 3: Load_Offices(); tableLayoutPanel2.Show(); SaveBtn.Show(); break;
                default: tableLayoutPanel3.Show(); SaveBtn.Show(); ComboBoxPreparation(); Load_Departments();  break;
            }
        }
        private void Load_Employees()
        {
            string sql = "select p.id_pracownika as ID, p.imie as Imie, p.nazwisko as Nazwisko,  s.nazwa as Stanowisko, d.nazwa_dzialu as 'Nazwa działu', si.nazwa_siedziby as Siedziba, si.adres as Adres" +
                         " from PRACOWNICY p join DZIALY d on p.id_dzialu=d.id_dzialu join STANOWISKA s on p.id_stanowiska=s.id_stanowiska join SIEDZIBY si on d.id_siedziby=si.id_siedziby;";
            ListofEmployees();
            if (IsClicked == false) { MessageBox.Show("Nie wybrano Pracownika !"); }
            else
            {
                IsClicked = false;
                AddForm aform = new AddForm(" " + IDs[SqldataGridView.SelectedRows[0].Index]);
                aform.ShowDialog();
            }
            LoadDataToSqldataGridView("Pracownicy", sql);
        }
        private void Load_JobTitles()
        {
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";
            JobTitleID();
            int index = IDj[SqldataGridView.SelectedRows[0].Index];
            TitlestextBox.Text = IDj[SqldataGridView.SelectedRows[0].Index].ToString();


            SqlConnection connection = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

            SqlCommand cmd = new SqlCommand("select nazwa from STANOWISKA where id_stanowiska=" + index + ";", connection);
            try
            {
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TitlestextBox.Text = (string)rdr["nazwa"];


                }
                connection.Close();

            }
            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
            }
        
        
        }
        private void Load_Offices(){}
        private void  Load_Departments(){}

        private void Update_Offices() 
        { 
        
        
        
        }
        private void Update_Departments() 
        { 
        
        
        
        }
        private void JobTitleID() 
        {
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";
            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

            try
            {
                sqlConn.Open();
                DateTime date = DateTime.Now;
                Console.WriteLine("Połączono z bazą danych!");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select id_stanowiska from STANOWISKA";

                cmd.Connection = sqlConn;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    IDj[J] = (int)rdr["id_stanowiska"]; J++;

                    
                }
                sqlConn.Close();
                Console.ReadLine();
            }
            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
            }        
        
        }
        
        private void Update_JobTitles() 
        {
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";
            JobTitleID();
            int ID = IDj[SqldataGridView.SelectedRows[0].Index];

            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("Update dbo.STANOWISKA set nazwa= @nazwa where id_stanowiska=@ID", sqlConn);
                cmd.Parameters.AddWithValue("@ID", ID.ToString());
                cmd.Parameters.AddWithValue("@nazwa", TitlestextBox.Text);

                SqlDataReader rdr = cmd.ExecuteReader();
            }
            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
            }
        }
        
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (IsClicked == false) { MessageBox.Show("Nie wybrano Pracownika !"); }
            else
            {
                IsClicked = false;
                ListofEmployees();
                int IDE = IDs[SqldataGridView.SelectedRows[0].Index];

                DialogResult dr = MessageBox.Show("Czy na pewno chcesz usunac wybrany  rekord?",
                         "Usuwanie", MessageBoxButtons.YesNo);
                string sql = "select p.id_pracownika as ID, p.imie as Imie, p.nazwisko as Nazwisko,  s.nazwa as Stanowisko, d.nazwa_dzialu as 'Nazwa działu', si.nazwa_siedziby as Siedziba, si.adres as Adres" +
                         " from PRACOWNICY p join DZIALY d on p.id_dzialu=d.id_dzialu join STANOWISKA s on p.id_stanowiska=s.id_stanowiska join SIEDZIBY si on d.id_siedziby=si.id_siedziby;";
                switch (dr)
                {
                    case DialogResult.Yes: Delete(IDE);
                        LoadDataToSqldataGridView("Pracownicy", sql); break;
                    case DialogResult.No: break;
                }
            }
        }

        private void LoadDataToSqldataGridView(string TableName, string sql) 
        {
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";

            SqlConnection connection = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");
            
            dataadapter = new SqlDataAdapter(sql, connection);
            ds = new DataSet();
            try
            {
                connection.Open();
                dataadapter.Fill(ds, TableName);
                databuilder = new SqlCommandBuilder(dataadapter);
                sTable = ds.Tables[TableName];
                connection.Close();
                
              
                SqldataGridView.DataSource = ds;
                SqldataGridView.DataMember = TableName;
                SqldataGridView.ReadOnly = true;
                SqldataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {}
        private void ListofEmployees()
        {
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";
            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

            try
            {
                sqlConn.Open();
                DateTime date = DateTime.Now;
                Console.WriteLine("Połączono z bazą danych!");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select p.id_pracownika, p.imie, p.nazwisko,  s.nazwa, d.nazwa_dzialu" +
                    " from PRACOWNICY p join DZIALY d on p.id_dzialu=d.id_dzialu join STANOWISKA s on p.id_stanowiska=s.id_stanowiska";
                cmd.Connection = sqlConn;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    IDs[i] = (int)rdr["id_pracownika"]; i++;
                }
                sqlConn.Close();
                Console.ReadLine();
            }
            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
            }      
        
        }
        private void CreateEmployees() 
        {
            AddForm aform = new AddForm("");
            string sql = "select p.id_pracownika as ID, p.imie as Imie, p.nazwisko as Nazwisko,  s.nazwa as Stanowisko, d.nazwa_dzialu as 'Nazwa działu', si.nazwa_siedziby as Siedziba, si.adres as Adres" +
                   " from PRACOWNICY p join DZIALY d on p.id_dzialu=d.id_dzialu join STANOWISKA s on p.id_stanowiska=s.id_stanowiska join SIEDZIBY si on d.id_siedziby=si.id_siedziby;";
            aform.ShowDialog();
            LoadDataToSqldataGridView("Pracownicy", sql);
            EmployeesBtn.Enabled = false; 
        }
        private void Delete(int condition)
        {
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";
            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

            try
            {
                sqlConn.Open();
                DateTime date = DateTime.Now;
                Console.WriteLine("Połączono z bazą danych!");
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.PRACOWNICY where id_pracownika='" + condition + "';", sqlConn);
                SqlDataReader rdr = cmd.ExecuteReader();
                sqlConn.Close();                
            }

            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
            }
        }

        private void SqldataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IsClicked = true;
        }

        private void JobTitlesbtn_Click(object sender, EventArgs e)
        {
            Key = 2;
            tableLayoutPanel3.Hide();
            tableLayoutPanel2.Hide();
            tableLayoutPanel1.Hide();
            SaveBtn.Hide();
            EmployeesBtn.Enabled = true;
            OfficesBtn.Enabled = true;
            DepartmentsBtn.Enabled = true;
            SqldataGridView.Show();
            CreateBtn.Show();
            UpdateBtn.Show();
            DeleteBtn.Show();
            CreateBtn.Enabled = true;
            UpdateBtn.Enabled = false;
            DeleteBtn.Enabled = false;
            TurnOnEditBth.Show();
            MainPicture.Hide();
            string sql = "select id_stanowiska, nazwa as Stanowisko from STANOWISKA ";
            LoadDataToSqldataGridView("Stanowiska", sql);
            JobTitlesbtn.Enabled = false;
        }

        private void OfficesBtn_Click(object sender, EventArgs e)
        {
            Key = 3;
            tableLayoutPanel3.Hide();
            tableLayoutPanel2.Hide();
            tableLayoutPanel1.Hide();
            SaveBtn.Hide();
            EmployeesBtn.Enabled = true;
            JobTitlesbtn.Enabled = true;
            DepartmentsBtn.Enabled = true;
            SqldataGridView.Show();
            CreateBtn.Show();
            UpdateBtn.Show();
            DeleteBtn.Show();
            CreateBtn.Enabled = true;
            UpdateBtn.Enabled = false;
            DeleteBtn.Enabled = false;
            TurnOnEditBth.Show();
            MainPicture.Hide();
            string sql = "select id_siedziby as ID ,nazwa_siedziby as Oddział, adres as Adres from SIEDZIBY ";
            LoadDataToSqldataGridView("Siedziby", sql);
            OfficesBtn.Enabled = false;

        }

        private void DepartmentsBtn_Click(object sender, EventArgs e)
        {
            Key = 4;
            tableLayoutPanel3.Hide();
            tableLayoutPanel2.Hide();
            tableLayoutPanel1.Hide();
            SaveBtn.Hide();
            EmployeesBtn.Enabled = true;
            JobTitlesbtn.Enabled = true;
            OfficesBtn.Enabled = true;
            SqldataGridView.Show();
            CreateBtn.Show();
            UpdateBtn.Show();
            DeleteBtn.Show();
            CreateBtn.Enabled = true;
            UpdateBtn.Enabled = false;
            DeleteBtn.Enabled = false;
            TurnOnEditBth.Show();
            MainPicture.Hide();
            string sql = "select d.nazwa_dzialu, s.nazwa_siedziby, s.adres from DZIALY d join SIEDZIBY s on  d.id_siedziby=s.id_siedziby ";
            LoadDataToSqldataGridView("Dzialy", sql);
            DepartmentsBtn.Enabled = false;

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            string text = "Wprowadzone  wyrażenie jest za krótkie", text2 = "Nie wybrano biura dla tworzonego działu";
            AddForm aform = new AddForm("");
            switch (Key)
            {
                case 2: 
                switch(key)
                { 
                    case 'c' :
                        if (TitlestextBox.Text.Length <= 3) 
                        {
                            MessageBox.Show(text); 
                        } 
                        else 
                        {
                            InsertToJobTitles();
                            LoadDataToSqldataGridView("Stanowiska", "select id_stanowiska, nazwa as Stanowisko from STANOWISKA "); 
                            TitlestextBox.Text = ""; 
                        } 
                        break;
                    default: Update_JobTitles(); LoadDataToSqldataGridView("Stanowiska", "select id_stanowiska, nazwa as Stanowisko from STANOWISKA ");
                        TitlestextBox.Text = ""; 
                        break;
                }
                break;
                case 3:  
                switch(key)
                { 
                    case 'c' :
                    if (OfficeNametextBox.Text.Length < 3 || OfficeAdresstextBox.Text.Length < 3) 
                    {
                        MessageBox.Show(text); 
                    } 
                    else {
                        InsertIntoOffices();
                        LoadDataToSqldataGridView("Siedziby", "select id_siedziby as ID ,nazwa_siedziby as Oddział, adres as Adres from SIEDZIBY ");
                        OfficeNametextBox.Text = ""; 
                        OfficeAdresstextBox.Text = ""; 
                    } 
                    break;
                    default:
                        break;
                }
                break;
                    default:
                      switch(key)  {
                          case 'c':
                            if (this.OfficecomboBox.GetItemText(this.OfficecomboBox.SelectedItem) == "0")
                            {
                                MessageBox.Show(text2); 
                            }
                            else 
                            {
                                if (DepartmenttextBox.Text.Length < 2)
                                {
                                    MessageBox.Show(text);
                                }                        
                            InsertIntoDepartments(); 
                            LoadDataToSqldataGridView("Dzialy", "select d.nazwa_dzialu, s.nazwa_siedziby, s.adres from DZIALY d join SIEDZIBY s on  d.id_siedziby=s.id_siedziby ");
                            DepartmenttextBox.Text = "";
                            OfficecomboBox.Text = "";
                            } break;
                          default: break;
                   
                        } break;
            }
        }
        private void InsertToJobTitles()
        {
            AddForm aform = new AddForm("");
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";
            int ID = aform.CountData("SELECT  max(id_stanowiska) as ilosc FROM STANOWISKA;") + 1;

            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("insert into dbo.STANOWISKA values (@id,@nazwa)", sqlConn);
                cmd.Parameters.AddWithValue("@id", ID.ToString());
                cmd.Parameters.AddWithValue("@nazwa", TitlestextBox.Text);

                SqlDataReader rdr = cmd.ExecuteReader();
                sqlConn.Close();
            }
            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
                Console.ReadLine();
            }
        
        
        
        }
        private void InsertIntoOffices()
        {
            AddForm aform = new AddForm("");
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";
            int ID = aform.CountData("SELECT  max (id_siedziby) as ilosc From SIEDZIBY;") + 1;

            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("insert into dbo.SIEDZIBY values (@id,@nazwa,@adres)", sqlConn);
                cmd.Parameters.AddWithValue("@id", ID.ToString());
                cmd.Parameters.AddWithValue("@nazwa", OfficeNametextBox.Text);
                cmd.Parameters.AddWithValue("@adres", OfficeAdresstextBox.Text);
                SqlDataReader rdr = cmd.ExecuteReader();
                sqlConn.Close();
            }
            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
                Console.ReadLine();
            }  
        }
        private void ComboBoxPreparation()
        {
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";

            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "select id_siedziby,nazwa_siedziby" + " from SIEDZIBY;";
                cmd.Connection = sqlConn;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string Nazwa = (string)rdr["nazwa_siedziby"];
                    Offices[(int)rdr["id_siedziby"]] = Nazwa;
                    OfficecomboBox.Items.Add(Nazwa);
                }
                sqlConn.Close();
            }
            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
            }
        }

        private void InsertIntoDepartments() 
        {
            AddForm aform = new AddForm("");
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";
            int ID = aform.CountData("SELECT  max(id_dzialu) as ilosc FROM DZIALY;") + 1;

            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("insert into dbo.DZIALY values (@id,@nazwa,@ids)", sqlConn);
                cmd.Parameters.AddWithValue("@id", ID.ToString());
                cmd.Parameters.AddWithValue("@nazwa", DepartmenttextBox.Text);
                cmd.Parameters.AddWithValue("@ids", FindDepartmentId().ToString());
                SqlDataReader rdr = cmd.ExecuteReader();
                sqlConn.Close();
            }
            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
                Console.ReadLine();
            } 
         }
        
        private int FindDepartmentId() 
        {
            int IDO = 0,O=0;
            while (O < 50)
            {
                if (this.OfficecomboBox.GetItemText(this.OfficecomboBox.SelectedItem) == Offices[O])
                {
                    IDO = O; break;
                }
                O++;
            }

            return IDO; 
        }
    }
}
