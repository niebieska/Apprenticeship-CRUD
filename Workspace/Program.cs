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
        {    // Inicjalizacja nowego obiektu odpowiedzialnego za zapis do pliku
            
            StreamWriter sw = new StreamWriter(@"C:\Users\praktykant\Documents\nowyplik.txt", false);
            
            /*
             * Zmienne do Connection String
            */
            string instance = @"ELPLC-0305\SQLEXPRESS";
            string dbdir = "Pracownicy";
            string id= "sa";
            string password = "Pr4ktyk4nt1!";
            
            /*Connection String:
             * zawiera dane serwera SQL, z którym się łączymy:
             * nazwę instancji - Data Source
             * dane konta: User ID / Password
             * Nazwa Bazy Danych-Initial Catalog
             */
                      SqlConnection sqlConn = new SqlConnection("Data Source=" + instance + ";"+"User ID=" + id + ";"+"Password="+ password+";" + "Initial Catalog=" + dbdir+";");

            try
            {               
                // otwórz połączenie:
                sqlConn.Open();
                DateTime date=DateTime.Now;
                Console.WriteLine("Połączono z bazą danych!");
                
                SqlCommand cmd = new SqlCommand("insert into dbo.PRACOWNICY values (@id,@imie,@nazwisko,@data,@ids,@idd)", sqlConn);
                cmd.Parameters.AddWithValue("@id", "1");
                cmd.Parameters.AddWithValue("@imie", "Jan");
                cmd.Parameters.AddWithValue("@nazwisko", "Kowalski");
                cmd.Parameters.AddWithValue("@data", date);
                cmd.Parameters.AddWithValue("@ids", "1");
                cmd.Parameters.AddWithValue("@idd", "1");
                // Inicjalizacja nowego polecenia wraz z zapytaniem i połączeniem
                /*
                SqlCommand cmd = new SqlCommand("insert into dbo.DZIALY values (@id,@nazwa,@ids)", sqlConn);
                cmd.Parameters.AddWithValue("@id", 1);
                cmd.Parameters.AddWithValue("@nazwa", "IT");
                cmd.Parameters.AddWithValue("@ids", 1);
                
                    SqlCommand cmd = new SqlCommand("select * from dbo.SIEDZIBY", sqlConn);
                
                    Insert do tabeli dbo.STANOWISKA
                    SqlCommand cmd = new SqlCommand("insert into dbo.STANOWISKA values (@id,@nazwa)",sqlConn);
                    cmd.Parameters.AddWithValue("@id", 1);
                    cmd.Parameters.AddWithValue("@nazwa", "PROGRAMISTA");
            
                SqlCommand cmd = new SqlCommand("insert into dbo.PRACOWNICY values (@id,@imie,@nazwisko,@data,@ids,@idd)", sqlConn);
                cmd.Parameters.AddWithValue("@id", "1000");
                cmd.Parameters.AddWithValue("@imie", "Jan");
                cmd.Parameters.AddWithValue("@nazwisko", "Kowalski");
                cmd.Parameters.AddWithValue("@data", "2001-01-12");
                cmd.Parameters.AddWithValue("@ids", "1");
                cmd.Parameters.AddWithValue("@idd", "1");
                
              */
               // Wywołanie odczytu Execute dla pozyskania wyników zapytania
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int Id = (int)rdr["id_siedziby"];
                    string Nazwa = (string)rdr["nazwa"];
                    string adres = (string)rdr["adres"];
                    Console.WriteLine(Id +" "+ Nazwa +" "+ adres + ";");
                }

                //Console.Write(rdr);
                
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
