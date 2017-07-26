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
       
        int DepartmentId;
        int JobTitleId;
        int OldJobTitleId;
        int OldDepartmentId;
        int D = 1, J = 1;

        public AddForm(string s)
        {
            InitializeComponent();
            if (s.Length > 1)
            {
                HelptextBox.Text = s;
                LoadDataForEdit();

            }
            
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            
            if (HelptextBox.Text.Length < 1)
            {
                int ID = CountData() + 1;
                InsertDataToEmployees(ID.ToString());
                SaveBtn.Enabled = false;
            }
            else
            {
                
                UpdateData(); 
                 SaveBtn.Enabled = false; 
                }
                            
            
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
                //MessageBox.Show("Połączono z bazą danych!");
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
     private void LoadDataForEdit()
     {
         string instance = @"ELPLC-0305\SQLEXPRESS";
         string dbdir = "Pracownicy";
         string id = "sa";
         string password = "Pr4ktyk4nt1!";

         string index = HelptextBox.Text;
         
         SqlConnection connection = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

         SqlCommand cmd = new SqlCommand("select p.id_pracownika as ID, p.imie as Imie, p.nazwisko as Nazwisko, p.data_zatrudnienia,s.id_stanowiska ,  s.nazwa as Stanowisko, d.id_dzialu,d.nazwa_dzialu as 'Nazwa działu', si.nazwa_siedziby as Siedziba, si.adres as Adres" +
                 " from PRACOWNICY p join DZIALY d on p.id_dzialu=d.id_dzialu join STANOWISKA s on p.id_stanowiska=s.id_stanowiska join SIEDZIBY si on d.id_siedziby=si.id_siedziby where id_pracownika=" + index + ";", connection);


         try
         {
             connection.Open();
             SqlDataReader rdr = cmd.ExecuteReader();
             while (rdr.Read())
             {
                 NametextBox.Text = (string)rdr["imie"];
                 SurnametextBox.Text = (string)rdr["nazwisko"];

                 dateTimePicker1.Value = Convert.ToDateTime(rdr["data_zatrudnienia"]);
                 JobTitlecomboBox.Text = (string)rdr["Stanowisko"];
                 DepartmentcomboBox.Text = (string)rdr["Nazwa działu"];
                 OfficecomboBox.Text = (string)rdr["Siedziba"];
                 OldJobTitleId = (int)rdr["id_stanowiska"];
                 OldDepartmentId = (int)rdr["id_dzialu"];

             }
             connection.Close();

         }
         catch (System.Data.SqlClient.SqlException se)
         {
             MessageBox.Show("Nastąpil bląd połaczenia: " + se);
         }
     }
     private void UpdateData()
     {
         int id_stanowiska;
         int id_dzialu;
         string instance = @"ELPLC-0305\SQLEXPRESS";
         string dbdir = "Pracownicy";
         string id = "sa";
         string password = "Pr4ktyk4nt1!";
         
         FindId();

         

         if (JobTitleId == 0) { id_stanowiska = OldJobTitleId; }
         else { id_stanowiska = JobTitleId; }
        
         if (DepartmentId == 0){ id_dzialu = OldDepartmentId; }
         else
         {          
             id_dzialu = DepartmentId; 
         }
         

         SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

         try
         {
             sqlConn.Open();

             //MessageBox.Show("Połączono z bazą danych!");
            // MessageBox.Show(id_stanowiska.ToString());
             SqlCommand cmd = new SqlCommand("Update dbo.PRACOWNICY set imie=@im,nazwisko=@nazw,data_zatrudnienia =@date, id_stanowiska=@ids,id_dzialu=@idd where id_pracownika=@IDE", sqlConn);
             cmd.Parameters.AddWithValue("@im", NametextBox.Text);
             cmd.Parameters.AddWithValue("@nazw", SurnametextBox.Text);
             cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString());
             cmd.Parameters.AddWithValue("@ids", id_stanowiska.ToString());
             cmd.Parameters.AddWithValue("@idd", id_dzialu.ToString());
             cmd.Parameters.AddWithValue("@IDE", HelptextBox.Text);
             SqlDataReader rdr = cmd.ExecuteReader();
         }
         catch (System.Data.SqlClient.SqlException se)
         {
             MessageBox.Show("Nastąpil bląd połaczenia: " + se);

         }




     }

     private void DepartmentcomboBox_SelectedIndexChanged(object sender, EventArgs e)
     {}

          
        
        } 

        
    }

