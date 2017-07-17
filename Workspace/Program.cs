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
            string id= "sa";
            string password = "Pr4ktyk4nt1!";
            Console.WriteLine(password);

            Console.WriteLine("Hello world");
            //string cn = "server=SQLEXPRESS;database=Employess";
            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";"+"User ID=" + id + ";"+"Password="+ password+";" + "Initial Catalog=" + dbdir+";");

            Console.WriteLine(sqlConn.ConnectionString);
            sw.WriteLine(sqlConn.ConnectionString);
            try
            {
                
                // otwórz połączenie:
                sqlConn.Open();

                Console.WriteLine("Połączono z bazą danych!");

                // zamknij połaczenie:
                sqlConn.Close();
                Console.ReadLine();
            }
            catch (System.Data.SqlClient.SqlException se)
            {
                
                Console.WriteLine("Nastąpil bląd połaczenia: " + se);
                //File.WriteAllText("test.txt", s + se);
                sw.WriteLine(se);
                sw.Close();
                Console.ReadLine();
            }
        }
    }
}
