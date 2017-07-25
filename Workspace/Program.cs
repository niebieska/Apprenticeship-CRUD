using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Workspace
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\praktykant\Documents\nowyplik.txt", false);
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id = "sa";
            string password = "Pr4ktyk4nt1!";

            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";" + "User ID=" + id + ";" + "Password=" + password + ";" + "Initial Catalog=" + dbdir + ";");

            try
            {   sqlConn.Open();
                DateTime date = DateTime.Now;
                Console.WriteLine("Połączono z bazą danych!");
               
                SqlCommand cmd = new SqlCommand("Update dbo.PRACOWNICY set imie=@im,nazwisko=@nazw,data_zatrudnienia =@date, id_stanowiska=@ids,id_dzialu=@idd where id_pracownika=@IDE", sqlConn);
                SqlDataReader rdr = cmd.ExecuteReader();

                sqlConn.Close();
                Console.ReadLine();
            }
            catch (System.Data.SqlClient.SqlException se)
            {

                Console.WriteLine("Nastąpil bląd połaczenia: " + se);
                sw.WriteLine(se);
                sw.Close();
                Console.ReadLine();
            }



        }
    }
}
