using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace CRUD_employees
{
    public partial class Form1 : Form
    {
        int[] IDs = new int[50]; //tablica z numerami ID pracowników
        int i = 0;
       public int WybranyPracownik=0;
        
        SqlDataAdapter dataadapter;
        SqlCommandBuilder databuilder;
        DataSet ds;
        DataTable sTable;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.Hide();
            textBox1.Hide();
            button5.Hide();
            button1.Hide();
            button3.Hide();
            button4.Hide();
        }
        /*Obsługa przycisku "Dodaj", Otwarcie formularza */
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(" ");
            SendToBack();
            form2.ShowDialog();
        }       
        public void LoadData()
        {
            //StreamWriter sw = new StreamWriter(@"C:\Users\praktykant\Documents\nowyplik.txt", false);
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";

            SqlConnection connection = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

            string sql = "select p.id_pracownika as ID, p.imie as Imie, p.nazwisko as Nazwisko,  s.nazwa as Stanowisko, d.nazwa_dzialu as 'Nazwa działu', si.nazwa_siedziby as Siedziba, si.adres as Adres" +
                    " from PRACOWNICY p join DZIALY d on p.id_dzialu=d.id_dzialu join STANOWISKA s on p.id_stanowiska=s.id_stanowiska join SIEDZIBY si on d.id_siedziby=si.id_siedziby;";
           
            dataadapter = new SqlDataAdapter(sql, connection);
            ds = new DataSet();
            try
            {
                connection.Open();
                dataadapter.Fill(ds, "Pracownicy");
                databuilder = new SqlCommandBuilder(dataadapter);
                sTable = ds.Tables["Pracownicy"];
                connection.Close();
                button5.Enabled = false;
                connection.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Pracownicy";
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
            }
        }
        
        private void AddButtons(string name)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "Click to " + name;
            btn.Text = name;
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
        }
        /*Włączenie edycji, Uaktywnienie przycisków*/
        private void button3_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            button1.Enabled = false;
            button4.Enabled = true;
            dataGridView1.ReadOnly = false;
            MessageBox.Show("Wlaczono edycje");
        }
        

        private void Delete()
        {
            MessageBox.Show("Usuwanie");
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";
            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

            try
            {
                MessageBox.Show("Connected");
                sqlConn.Open();
                DateTime date = DateTime.Now;
                Console.WriteLine("Połączono z bazą danych!");
                ListofEmployees();
                int condition = IDs[dataGridView1.SelectedRows[0].Index];
                MessageBox.Show(condition.ToString());
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.PRACOWNICY where id_pracownika='" + condition + "';", sqlConn);

                SqlDataReader rdr = cmd.ExecuteReader();
                sqlConn.Close();
                MessageBox.Show("finished");
            }

            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
            }
        }

        private void ListofEmployees()
        { 
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id= "sa";
            string password = "Pr4ktyk4nt1!";
            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";"+"User ID=" + id + ";"+"Password="+ password+";" + "Initial Catalog=" + dbdir+";");
            
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
        /*Obsługa przycisku "Usuń"*/
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Czy na pewno chcesz usunac wybrany  rekord?", 
                      "Usuwanie", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes: Delete(); break;
                case DialogResult.No: break;
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string data;
            data = dataGridView1.SelectedRows.ToString();
            int index = dataGridView1.SelectedRows[0].Index;
            textBox1.Text = index.ToString();
        }
              

        private void button5_Click(object sender, EventArgs e)
        {
            
            ListofEmployees();
            WybranyPracownik=IDs[dataGridView1.SelectedRows[0].Index];
            Form2 form2 = new Form2(WybranyPracownik.ToString());
            MessageBox.Show(WybranyPracownik.ToString());
            form2.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pictureBox1.Dispose();
            label1.Dispose();
            textBox1.Show();
            dataGridView1.Show();
            button5.Show();
            button1.Show();
            button3.Show();
            button4.Show();
            LoadData();
            button5.Enabled = false;
            button1.Enabled = true;
            button4.Enabled = false;
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {}

        private void button6_Click(object sender, EventArgs e)
        {}
    }
}
