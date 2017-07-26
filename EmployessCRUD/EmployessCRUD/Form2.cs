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

namespace EmployessCRUD
{
    public partial class AddForm : Form
    {
        Form1 form1 = new Form1();
        string[] Departments= new string[50];
        string[] JobTitles = new string[50];
        string[] Offices = new string[50];
        //List<string> JobTitles= new List<string>();

        int DepartmentId;
        int JobTitleId;
        int D = 1, J = 1;

        public AddForm()
        {
            InitializeComponent();
            HelptextBox.Text = CountData().ToString();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            int ID = CountData() + 1;
            InsertDataToEmployees(ID.ToString());
            SaveBtn.Enabled = false;
            
        }
        

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            form1.Refresh();
            Close();
        }
        private void AddForm_Load(object sender, EventArgs e)
        {
            ComboBoxPreparation();
        }


        private int CountData() 
        {
            int iloscrekordow = 0;
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";

            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");
            try
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("SELECT  max(id_pracownika) as ilosc FROM PRACOWNICY;", sqlConn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr["ilosc"] == DBNull.Value) { return 0; };
                    iloscrekordow = (int)rdr["ilosc"];
                    return iloscrekordow;
                }
                sqlConn.Close();
                if (iloscrekordow == 0) { return 0; }
            }

            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
                return 0;
            }
            return iloscrekordow;
        }
        private void ComboBoxPreparation()
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
                cmd.CommandText = "select id_stanowiska,nazwa" + " from STANOWISKA;";
                cmd.Connection = sqlConn;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {   
                    string Name= (string)rdr["nazwa"];
                    JobTitles[(int)rdr["id_stanowiska"]] = Name;
                    JobTitlecomboBox.Items.Add(Name);
                }
                sqlConn.Close();

                sqlConn.Open();
              
                cmd.CommandText = "select id_siedziby,nazwa_siedziby" + " from SIEDZIBY;";
                cmd.Connection = sqlConn;
                rdr = cmd.ExecuteReader();

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
        
        private void OfficecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";
            string Office = "";

            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

            MessageBox.Show(this.OfficecomboBox.GetItemText(this.OfficecomboBox.SelectedItem));
            Office = this.OfficecomboBox.GetItemText(this.OfficecomboBox.SelectedItem);
            try
            {    //Wyłuskanie nazw stanowisk
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "select d.id_dzialu,d.nazwa_dzialu" + " from DZIALY d " + "Join SIEDZIBY s on d.id_siedziby=s.id_siedziby where s.nazwa_siedziby= '" + Office + " ';";
                cmd.Connection = sqlConn;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string Name = (string)rdr["nazwa_dzialu"];
                    Departments[(int)rdr["id_dzialu"]] = Name;
                    DepartmentcomboBox.Items.Add(Name);
                }
                sqlConn.Close();
            }

            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: Oddzialy " + se);

            }
        }
               
         
     private void InsertDataToEmployees(string ID) 
        {
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";
            FindId();

            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");
            try
            {
                // otwórz połączenie:
                sqlConn.Open();
                MessageBox.Show("Połączono z bazą danych!");
                SqlCommand cmd = new SqlCommand("insert into dbo.PRACOWNICY values (@id,@imie,@nazwisko,@data,@ids,@idd)", sqlConn);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@imie", NametextBox.Text);
                cmd.Parameters.AddWithValue("@nazwisko", SurnametextBox.Text);
                cmd.Parameters.AddWithValue("@data", dateTimePicker1.Value.ToString());
                cmd.Parameters.AddWithValue("@ids", JobTitleId.ToString());
                cmd.Parameters.AddWithValue("@idd", DepartmentId.ToString());
                SqlDataReader rdr = cmd.ExecuteReader();
                sqlConn.Close();

            }
            catch (System.Data.SqlClient.SqlException se)
            {
                MessageBox.Show("Nastąpil bląd połaczenia: " + se);
                Console.ReadLine();
            }
     }
     private void FindId() 
     { 
       while(J<50)
       {
           if (this.JobTitlecomboBox.GetItemText(this.JobTitlecomboBox.SelectedItem) == JobTitles[J])
           {
               JobTitleId = J; break;
           }
           J++;
       
       }
     
     while(D<50)
       {
           if (this.DepartmentcomboBox.GetItemText(this.DepartmentcomboBox .SelectedItem) == Departments[D])
           {
               DepartmentId = D; break;
           }
           D++;
       
       }
     
     }




        
        
        } 

        
    }

