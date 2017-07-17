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
        {    //
            StreamWriter sw = new StreamWriter(@"C:\Users\praktykant\Documents\nowyplik.txt", false);



            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id= "sa";
            string password = "Pr4ktyk4nt1!";
            Console.WriteLine(password);

            Console.WriteLine("Hello world");

            /*Connection String:
             * zawiera dane serwera SQL, z którym się łączymy:
             * nazwę instancji - Data Source
             * dane konta: User ID / Password
             * Nazwa Bazy Danych
             */
            SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";"+"User ID=" + id + ";"+"Password="+ password+";" + "Initial Catalog=" + dbdir+";");

            Console.WriteLine(sqlConn.ConnectionString);
            sw.WriteLine(sqlConn.ConnectionString);
            try
            {
                
                // otwórz połączenie:
                sqlConn.Open();

                Console.WriteLine("Połączono z bazą danych!");

                // zamknij połaczenie:
                
               // Console.ReadLine();
                // 1. inicjujemy nowe polecenie wraz z zapytaniem i połączeniem
                SqlCommand cmd = new SqlCommand("select * from dbo.SIEDZIBY", sqlConn);


                // 2. wywołujemy  odczyt Execute dla pozyskania wyników zapytania
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                while (rdr.Read())
                {
                    int Id = (int)rdr["id_siedziby"];
                    string Nazwa = (string)rdr["nazwa"];
                    string adres = (string)rdr["adres"];
                    Console.WriteLine(Id +" "+ Nazwa +" "+ adres + ";");
                }

                Console.Write(rdr);
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
