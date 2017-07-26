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
        bool IsClicked = false;
        /*Deklaracje zmiennych globalnych*/
        SqlDataAdapter dataadapter;
        SqlCommandBuilder databuilder;
        DataSet ds;
        DataTable sTable;
        int[] IDs = new int[50]; //tablica z numerami ID pracowników
        int i = 0;
        int ChoosenEmployee = 0;
       


        public Form1()
        {
            InitializeComponent();
            SqldataGridView.Hide();
            CreateBtn.Hide();
            UpdateBtn.Hide();
            UpdateBtn.Enabled = false;
            DeleteBtn.Hide();
            DeleteBtn.Enabled = false;
            TurnOnEditBth.Hide();
            TurnOffEditBth.Hide();
            SqldataGridView.ReadOnly = false;


        }

        private void EmployeesBtn_Click(object sender, EventArgs e)
        {
            SqldataGridView.Show();
            CreateBtn.Show();
            UpdateBtn.Show();
            DeleteBtn.Show();
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
            AddForm aform = new AddForm("");
            string sql = "select p.id_pracownika as ID, p.imie as Imie, p.nazwisko as Nazwisko,  s.nazwa as Stanowisko, d.nazwa_dzialu as 'Nazwa działu', si.nazwa_siedziby as Siedziba, si.adres as Adres" +
                   " from PRACOWNICY p join DZIALY d on p.id_dzialu=d.id_dzialu join STANOWISKA s on p.id_stanowiska=s.id_stanowiska join SIEDZIBY si on d.id_siedziby=si.id_siedziby;";
            aform.ShowDialog();
            LoadDataToSqldataGridView("Pracownicy", sql);
            EmployeesBtn.Enabled = false;
           

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            ListofEmployees();
            if (IsClicked == false) { MessageBox.Show("Nie wybrano Pracownika !"); }
            else
            {
                IsClicked = false;
                AddForm aform= new AddForm( " "+IDs[SqldataGridView.SelectedRows[0].Index]);
                aform.ShowDialog();
            
            
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
                        LoadDataToSqldataGridView("Pracownicy", sql);
                         MessageBox.Show("After Delete"); break;
                    case DialogResult.No: break;
                }
            }
        }

        private void LoadDataToSqldataGridView(string TableName, string sql) 
        {
            //MessageBox.Show("Data Loading ...");
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
        {

        }
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

        private void Delete(int condition)
        {
            //MessageBox.Show("Usuwanie");
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";
            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

            try
            {
                //MessageBox.Show("Connected");
                sqlConn.Open();
                DateTime date = DateTime.Now;
                Console.WriteLine("Połączono z bazą danych!");
                               
                //MessageBox.Show(condition.ToString());
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.PRACOWNICY where id_pracownika='" + condition + "';", sqlConn);

                SqlDataReader rdr = cmd.ExecuteReader();
                sqlConn.Close();
                //MessageBox.Show("finished");
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
        

    }
}
