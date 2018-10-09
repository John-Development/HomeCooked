using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCook.Clases
{
    public class Extras
    {
        internal static User Login(string user, string password)
        {
            User logedUser = null;

            using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
            {
                //Tabla de Usuarios
                db.Open();
                string tableCommand = "SELECT * FROM Users WHERE Username = @User AND Password = @Pass";
                SqliteCommand getUser = new SqliteCommand(tableCommand, db);
                getUser.Parameters.AddWithValue("@User", user);
                getUser.Parameters.AddWithValue("@Pass", password);
                try
                {
                    SqliteDataReader query = getUser.ExecuteReader();

                    while (query.Read())
                    {
                        logedUser = new User
                        {
                            Id = query.GetInt32(0),
                            Username = query.GetString(1),
                            Password = query.GetString(2),
                            Email = query.GetString(3)
                        };
                    }

                }
                catch (SqliteException)
                {
                    //Do nothing
                }
                db.Close();
            }

            return logedUser;
        }
    }
}