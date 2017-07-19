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
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select COUNT(p.id_pracownika)"+
                    " from PRACOWNICY p ;";
                cmd.Connection = sqlConn;
                //SqlCommand cmd = new SqlCommand("delete from dbo.PRACOWNICY where ", sqlConn);
              /*SqlCommand cmd = new SqlCommand("insert into dbo.PRACOWNICY values (@id,@imie,@nazwisko,@data,@ids,@idd)", sqlConn);
                cmd.Parameters.AddWithValue("@id", "1");
                cmd.Parameters.AddWithValue("@imie", "Jan");
                cmd.Parameters.AddWithValue("@nazwisko", "Kowalski");
                cmd.Parameters.AddWithValue("@data", date);
                cmd.Parameters.AddWithValue("@ids", "1");
                cmd.Parameters.AddWithValue("@idd", "1");
                /* Inicjalizacja nowego polecenia wraz z zapytaniem i połączeniem
               
                SqlCommand cmd = new SqlCommand("insert into dbo.DZIALY values (@id,@nazwa,@ids)", sqlConn);
                cmd.Parameters.AddWithValue("@id", 1);
                cmd.Parameters.AddWithValue("@nazwa", "IT");
                cmd.Parameters.AddWithValue("@ids", 1);
                */
                    
                
                  
                   /* SqlCommand cmd = new SqlCommand("insert into dbo.STANOWISKA values (@id,@nazwa)",sqlConn);
                    cmd.Parameters.AddWithValue("@id", 1);
                    cmd.Parameters.AddWithValue("@nazwa", "PROGRAMISTA");
            */
                              
             
               // Wywołanie odczytu Execute dla pozyskania wyników zapytania
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int ID = (int)rdr[""];
                    //string imie=(string)rdr["imie"];
                    //string nazwisko = (string)rdr["nazwisko"];
                    // string data  = Convert.ToDateTime(rdr["data_zatrudnienia"]).ToString("dd/MM/yyyy");
                    //string ids = (string)rdr["nazwa"];
                    //string idd = (string)rdr["nazwa_dzialu"];
                    //string nazwa = (string)rdr["nazwa_siedziby"];
                    //string adres= (string)rdr["adres"];
                    
                    /*int Id = (int)rdr["id_siedziby"];
                    string Nazwa = (string)rdr["nazwa"];
                    string adres = (string)rdr["adres"];
                    Console.WriteLine(Id +" "+ Nazwa +" "+ adres + ";");*/
                    Console.WriteLine(ID); //+ " " + imie + " " + nazwisko + " " + ids + " " + idd+ " " +nazwa+ " " +adres);//+ data+ids + idd);
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
