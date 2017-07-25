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
        SqlDataAdapter dataadapter;
        SqlCommandBuilder databuilder;
        DataSet ds;
        DataTable sTable;
       


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
            AddForm aform = new AddForm();
            aform.ShowDialog();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

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
        {

        }
        
        

    }
}
