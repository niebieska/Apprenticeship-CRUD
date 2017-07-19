﻿using System;
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
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Hide();
            textBox1.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button Click");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Dispose();
            button3.Dispose();
            button2.Dispose();
            button4.Dispose();
            pictureBox1.Dispose();
            label1.Dispose();
            MessageBox.Show("Button Click");
            textBox1.Show();
            dataGridView1.Show();
            LoadData();

           
        }
        private void LoadData()
        { 
        StreamWriter sw = new StreamWriter(@"C:\Users\praktykant\Documents\nowyplik.txt", false);
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";

            /*Connection String:
             * zawiera dane serwera SQL, z którym się łączymy:
             * nazwę instancji - Data Source
             * dane konta: User ID / Password
             * Nazwa Bazy Danych-Initial Catalog
             */
            SqlConnection connection = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

            string sql = "select p.id_pracownika as ID, p.imie as Imie, p.nazwisko as Nazwisko,  s.nazwa as Stanowisko, d.nazwa_dzialu as 'Nazwa działu', si.nazwa_siedziby as Siedziba, si.adres as Adres" +
                    " from PRACOWNICY p join DZIALY d on p.id_dzialu=d.id_dzialu join STANOWISKA s on p.id_stanowiska=s.id_stanowiska join SIEDZIBY si on d.id_siedziby=si.id_siedziby;";
            /*string sql = "select p.id_pracownika, p.imie, p.nazwisko,  s.nazwa, d.nazwa_dzialu, si.nazwa_siedziby, si.adres" +
                    " from PRACOWNICY p join DZIALY d on p.id_dzialu=d.id_dzialu join STANOWISKA s on p.id_stanowiska=s.id_stanowiska join SIEDZIBY si on d.id_siedziby=si.id_siedziby;";*/
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                dataadapter.Fill(ds, "Pracownicy");
                connection.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Pracownicy";
            }
            catch (System.Data.SqlClient.SqlException se)
            {
                string s = " Wystąpił błąd połączenia z bazą danych ! Uruchom program ponownie!";
                textBox1.Text = s;
                sw.WriteLine(se);
                sw.Close();
            }
            
        }
        
        
        
        

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button Click");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button Click");
        }
    }
}
