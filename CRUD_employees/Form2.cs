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
    public partial class Form2 : Form
    {
        Form1 form1 = new Form1();  
        string[] dzialy= new string[20];
        string[] stanowiska = new string[20];
       // StreamWriter sw = new StreamWriter(@"C:\Users\praktykant\Documents\blad.txt", false);
        int id_dzialu;
        int id_stanowiska;
        int i = 1, j = 1;
        
        public Form2(string s)
        {
            InitializeComponent();
            textBox1.Text = s;
        }

        private int CountData()
        {
            int iloscrekordow=0;
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";

            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");
            try
            {    //Wyłuskanie nazw stanowisk
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT  id_pracownika FROM PRACOWNICY  where id_pracownika > (SELECT  count(id_pracownika) as ilosc FROM PRACOWNICY);";
                cmd.Connection = sqlConn;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    iloscrekordow = (int)rdr["id_pracownika"];
                    return iloscrekordow;
                }
                sqlConn.Close();

                if (iloscrekordow == 0) 
                {
                    sqlConn.Open();
                    cmd = new SqlCommand();
                    cmd.CommandText = "SELECT  count(id_pracownika) as ilosc FROM PRACOWNICY;";
                    cmd.Connection = sqlConn;
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        iloscrekordow = (int)rdr["ilosc"];
                        return iloscrekordow;
                    }
                    sqlConn.Close();
                }

            }
            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
                //sw.WriteLine(se);
                //sw.Close();
                //Console.ReadLine();
                return 0;
            }
            return iloscrekordow;
     
        
        
        
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
                   
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";

            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

            try
            {    //Wyłuskanie nazw stanowisk
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select nazwa" + " from STANOWISKA;";
                cmd.Connection = sqlConn;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string Nazwa = (string)rdr["nazwa"];
                    stanowiska[i] = Nazwa; i++;
                    comboBox1.Items.Add(Nazwa);
                }
                sqlConn.Close();
                //Wyłuskanie nazw działów
                sqlConn.Open();
                cmd.CommandText = "select nazwa_dzialu" + " from DZIALY;";
                cmd.Connection = sqlConn;
                rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    string Nazwa = (string)rdr["nazwa_dzialu"];
                    dzialy[j] = Nazwa; j++;
                    comboBox2.Items.Add(Nazwa);
                }
                sqlConn.Close();
                
                //Wyłuskanie nazw siedzib
                sqlConn.Open();
              
                cmd.CommandText = "select nazwa_siedziby" + " from SIEDZIBY;";
                cmd.Connection = sqlConn;


                // Wywołanie odczytu Execute dla pozyskania wyników zapytania
                //SqlDataReader 
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string Nazwa = (string)rdr["nazwa_siedziby"];

                    comboBox3.Items.Add(Nazwa);


                }
                // zamknij połaczenie:
                sqlConn.Close();


            }
            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
                //sw.WriteLine(se);
                //sw.Close();
                //Console.ReadLine();
            }
        
        }
        private void FindId()
        {
            for (int w = 1; w <= j; w++)
            {
                if (this.comboBox2.GetItemText(this.comboBox2.SelectedItem) == dzialy[w]) 
                {
                    id_dzialu = w;
                }
                
            
            }
            for (int z = 1; z <= i; z++) 
            {
                if (this.comboBox1.GetItemText(this.comboBox1.SelectedItem) == stanowiska[z])
                { id_stanowiska = z; }
            }        
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int newID = CountData() + 1;
            MessageBox.Show(newID.ToString());
            string imie = textBox1.Text;
            string nazwisko = textBox2.Text;
            DateTime iDate;
            iDate = dateTimePicker1.Value;
            textBox3.Text = imie + nazwisko + iDate + this.comboBox1.GetItemText(this.comboBox1.SelectedItem)+ this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
            string s = " ";
            textBox3.Text = s + CountData();


            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";

            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

            try
            {
                FindId();
                // otwórz połączenie:
                sqlConn.Open();
                DateTime date = DateTime.Now;
                MessageBox.Show("Połączono z bazą danych!");
                SqlCommand cmd = new SqlCommand("insert into dbo.PRACOWNICY values (@id,@imie,@nazwisko,@data,@ids,@idd)", sqlConn);
                cmd.Parameters.AddWithValue("@id", newID.ToString());
                cmd.Parameters.AddWithValue("@imie", imie);
                cmd.Parameters.AddWithValue("@nazwisko", nazwisko);
                cmd.Parameters.AddWithValue("@data", iDate.ToString());
                cmd.Parameters.AddWithValue("@ids", id_stanowiska.ToString());
                cmd.Parameters.AddWithValue("@idd", id_dzialu.ToString());
                SqlDataReader rdr = cmd.ExecuteReader();
                sqlConn.Close();

            }
            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
                //sw.WriteLine(se);
                //sw.Close();
                Console.ReadLine();
            }
            button1.Enabled = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {}

        private void button2_Click(object sender, EventArgs e)
        {

            //form1.Refresh(); 
            
            form1.LoadData();
             Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";
            DateTime date = new DateTime();

            string index = textBox1.Text;
            
            SqlConnection connection = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

            SqlCommand cmd = new SqlCommand("select p.id_pracownika as ID, p.imie as Imie, p.nazwisko as Nazwisko, p.data_zatrudnienia,  s.nazwa as Stanowisko, d.nazwa_dzialu as 'Nazwa działu', si.nazwa_siedziby as Siedziba, si.adres as Adres" +
                    " from PRACOWNICY p join DZIALY d on p.id_dzialu=d.id_dzialu join STANOWISKA s on p.id_stanowiska=s.id_stanowiska join SIEDZIBY si on d.id_siedziby=si.id_siedziby where id_pracownika=" + index + ";", connection);


            try
            {
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    textBox1.Text=(string)rdr["imie"];
                    textBox2.Text = (string)rdr["nazwisko"];

                    dateTimePicker1.Value = Convert.ToDateTime(rdr["data_zatrudnienia"]);
                    comboBox1.Text = (string)rdr["Stanowisko"];
                    comboBox2.Text = (string)rdr["Nazwa działu"];
                    comboBox3.Text = (string)rdr["Siedziba"];

                }
                connection.Close();

            }
            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
            }





        }
        
    }
    }

