using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;
using System.Web;
using System.Web.UI;

namespace HomeCook.Clases
{
    public class Extras
    {
        internal static bool IsValidate(string id)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
            {
                //Tabla de Usuarios
                db.Open();
                string tableCommand = "SELECT Username FROM Users WHERE Validate = @Val";
                SqliteCommand getUser = new SqliteCommand(tableCommand, db);
                getUser.Parameters.AddWithValue("@Val", id);
                try
                {
                    SqliteDataReader query = getUser.ExecuteReader();

                    while (query.Read())
                    {
                        return false;
                    }
                }
                catch (SqliteException)
                {
                    //Do nothing
                }
                db.Close();
            }
            return true;
        }

        internal static User Login(string user, string password)
        {
            User logedUser = null;

            using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
            {
                //Tabla de Usuarios
                db.Open();
                string tableCommand = "SELECT * FROM Users WHERE Username = @User AND Password = @Pass AND Validate = 1";
                SqliteCommand getUser = new SqliteCommand(tableCommand, db);
                getUser.Parameters.AddWithValue("@User", user);
                getUser.Parameters.AddWithValue("@Pass", password);
                try
                {
                    SqliteDataReader query = getUser.ExecuteReader();

                    while (query.Read())
                    {
                        logedUser = new User(query.GetString(0), query.GetString(1), query.GetString(2), query.GetString(3), new Preferences(query.GetString(6)))
                        {
                            ImageUri = query.IsDBNull(4) ? null : query.GetString(4),
                            Contact = query.IsDBNull(5) ? null : query.GetString(5),
                            Rank = query.IsDBNull(7) ? null : query.GetString(7)
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

        internal static User GetUser(string user)
        {
            User logedUser = null;

            using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
            {
                //Tabla de Usuarios
                db.Open();
                string tableCommand = "SELECT * FROM Users WHERE Username = @User";
                SqliteCommand getUser = new SqliteCommand(tableCommand, db);
                getUser.Parameters.AddWithValue("@User", user);
                try
                {
                    SqliteDataReader query = getUser.ExecuteReader();

                    while (query.Read())
                    {
                        logedUser = new User(query.GetString(0), query.GetString(1), query.GetString(2), query.GetString(3), new Preferences(query.GetString(6)))
                        {
                            ImageUri = query.IsDBNull(4) ? null : query.GetString(4),
                            Contact = query.IsDBNull(5) ? null : query.GetString(5),
                            Rank = query.IsDBNull(7) ? null : query.GetString(7)
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

        internal static List<Advert> GetAdverts()
        {
            List<Advert> adverts = new List<Advert>();
            List<string> users = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
            {
                db.Open();
                string tableCommand = "SELECT * FROM Products WHERE Active = 1";
                SqliteCommand getAdverts = new SqliteCommand(tableCommand, db);
                try
                {
                    SqliteDataReader query = getAdverts.ExecuteReader();

                    while (query.Read())
                    {
                        users.Add(query.GetString(3));
                        adverts.Add(new Advert(query.GetInt32(0), query.GetString(1), query.GetString(2), null, query.GetString(4), query.GetInt32(5), new Preferences(query.GetString(6)), (query.GetInt32(7) == 1)));
                    }
                }
                catch (SqliteException)
                {
                    //Do nothing
                }
                db.Close();
            }

            for(int i = 0; i < users.Count(); i++)
            {
                adverts[i].Owner = GetUser(users[i]);
            }

            return adverts;
        }

        internal static List<Advert> GetAdverts(string username)
        {
            List<Advert> adverts = new List<Advert>();
            List<string> users = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
            {
                db.Open();
                string tableCommand = "SELECT * FROM Products WHERE Active = 1 AND Vendor <> @Vend";
                SqliteCommand getAdverts = new SqliteCommand(tableCommand, db);
                getAdverts.Parameters.AddWithValue("@Vend", username);
                try
                {
                    SqliteDataReader query = getAdverts.ExecuteReader();

                    while (query.Read())
                    {
                        users.Add(query.GetString(3));
                        adverts.Add(new Advert(query.GetInt32(0), query.GetString(1), query.GetString(2), null, query.GetString(4), query.GetInt32(5), new Preferences(query.GetString(6)), (query.GetInt32(7) == 1)));
                    }
                }
                catch (SqliteException)
                {
                    //Do nothing
                }
                db.Close();
            }

            for (int i = 0; i < users.Count(); i++)
            {
                adverts[i].Owner = GetUser(users[i]);
            }

            return adverts;
        }

        internal static List<Advert> GetAdverts(User logedUser)
        {
            List<Advert> adverts = new List<Advert>();

            using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
            {
                db.Open();
                string tableCommand = "SELECT * FROM Products WHERE Vendor = @User";
                SqliteCommand getAdverts = new SqliteCommand(tableCommand, db);
                getAdverts.Parameters.AddWithValue("@User", logedUser.Username);
                try
                {
                    SqliteDataReader query = getAdverts.ExecuteReader();

                    while (query.Read())
                    {
                        adverts.Add(new Advert(query.GetInt32(0), query.GetString(1), query.GetString(2), logedUser, query.GetString(4), query.GetInt32(5), new Preferences(query.GetString(6)), (query.GetInt32(7) == 1)));
                    }
                }
                catch (SqliteException)
                {
                    //Do nothing
                }
                db.Close();
            }

            return adverts;
        }

        internal static bool IsAdvertActive(int id)
        {
            bool advert = false;

            using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
            {
                db.Open();
                string tableCommand = "SELECT Active FROM Products WHERE ID = @id";
                SqliteCommand getAdverts = new SqliteCommand(tableCommand, db);
                getAdverts.Parameters.AddWithValue("@id", id);
                try
                {
                    SqliteDataReader query = getAdverts.ExecuteReader();

                    while (query.Read())
                    {
                        advert = query.GetInt32(0) == 1;
                    }
                }
                catch (SqliteException)
                {
                    //Do nothing
                }
                db.Close();
            }

            return advert;
        }

        internal static void CreateAdvert(string name, string details, Preferences prefs, User owner, int portions, string image)
        {
            //string id = user + password;

            using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
            {
                //Tabla de Usuarios
                db.Open();
                //ID Name Details Vendor Image Portions Preferences
                string tableCommand = "INSERT INTO Products (Name, Details, Vendor, Image, Portions, Preferences, Active) VALUES (@Name, @Details, @Vendor, @Image, @Portions, @Prefs, @Active)";
                SqliteCommand setAdvert = new SqliteCommand(tableCommand, db);
                setAdvert.Parameters.AddWithValue("@Name", name);
                setAdvert.Parameters.AddWithValue("@Details", details);
                setAdvert.Parameters.AddWithValue("@Portions", portions);
                setAdvert.Parameters.AddWithValue("@Vendor", owner.Username);
                setAdvert.Parameters.AddWithValue("@Prefs", prefs.ToString());
                setAdvert.Parameters.AddWithValue("@Image", image);
                setAdvert.Parameters.AddWithValue("@Active", 1);
                try
                {
                    setAdvert.ExecuteReader();
                }
                catch (SqliteException ex)
                {
                    throw ex;
                }
                db.Close();
            }
            //return id.GetHashCode().ToString();
        }

        internal static void ModifyAdvert(int id, bool active)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
            {
                //Tabla de Usuarios
                db.Open();

                string tableCommand = "UPDATE Products SET Active = @active WHERE ID = @id";
                SqliteCommand updateUser = new SqliteCommand(tableCommand, db);
                updateUser.Parameters.AddWithValue("@active", active);
                updateUser.Parameters.AddWithValue("@id", id);
                try
                {
                    updateUser.ExecuteReader();
                }
                catch (SqliteException ex)
                {
                    throw ex;
                }
                db.Close();
            }
        }

        internal static void DeleteAdvert(int id)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
            {
                db.Open();

                string tableCommand = "DELETE FROM Products WHERE ID = @id";
                SqliteCommand deleteAdvert = new SqliteCommand(tableCommand, db);
                deleteAdvert.Parameters.AddWithValue("@id", id);
                try
                {
                    deleteAdvert.ExecuteReader();
                }
                catch (SqliteException ex)
                {
                    throw ex;
                }
                db.Close();
            }
        }

        internal static void Register(string user, string email, string password, string location, Preferences pref)
        {
            string id = (user + password).GetHashCode().ToString();

            using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
            {
                //Tabla de Usuarios
                db.Open();
                string tableCommand = "INSERT INTO Users (Username, Email, Password, Location, Preferences, Validate) VALUES (@User, @Email, @Pass, @Loc, @Alerg, @Val)";
                SqliteCommand setUser = new SqliteCommand(tableCommand, db);
                setUser.Parameters.AddWithValue("@User", user);
                setUser.Parameters.AddWithValue("@Email", email);
                setUser.Parameters.AddWithValue("@Pass", password);
                setUser.Parameters.AddWithValue("@Loc", location);
                setUser.Parameters.AddWithValue("@Alerg", pref.ToString());
                setUser.Parameters.AddWithValue("@Val", id);

                try
                {
                    setUser.ExecuteReader();
                }
                catch (SqliteException ex)
                {
                    throw ex;
                }
                db.Close();
            }
            VerificationEmail(id, user, email, password);
        }

        internal static void ModifyUser(User user)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
            {
                //Tabla de Usuarios
                db.Open();

                string tableCommand = "UPDATE Users SET Password = @Pass, Location = @Loc, Preferences = @Alerg WHERE Username = @User";
                SqliteCommand updateUser = new SqliteCommand(tableCommand, db);
                updateUser.Parameters.AddWithValue("@User", user.Username);
                updateUser.Parameters.AddWithValue("@Pass", user.Password);
                updateUser.Parameters.AddWithValue("@Loc", user.Location);
                updateUser.Parameters.AddWithValue("@Alerg", user.Preferences.ToString());
                try
                {
                    updateUser.ExecuteReader();
                }
                catch (SqliteException ex)
                {
                    throw ex;
                }
                db.Close();
            }
        }

        internal static void DeleteUser(User user)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
            {
                //Tabla de Productos
                db.Open();

                string tableCommand = "DELETE FROM Products WHERE Vendor = @User";
                SqliteCommand deleteUser = new SqliteCommand(tableCommand, db);
                deleteUser.Parameters.AddWithValue("@User", user.Username);
                try
                {
                    deleteUser.ExecuteReader();
                }
                catch (SqliteException ex)
                {
                    throw ex;
                }
                db.Close();

                //Tabla de Usuarios
                db.Open();

                tableCommand = "DELETE FROM Users WHERE Username = @User";
                deleteUser = new SqliteCommand(tableCommand, db);
                deleteUser.Parameters.AddWithValue("@User", user.Username);
                try
                {
                    deleteUser.ExecuteReader();
                }
                catch (SqliteException ex)
                {
                    throw ex;
                }
                db.Close();
            }
        }

        internal static void VerificationEmail(string id, string username, string email, string password)
        {
            var fromAddress = new MailAddress("homecooked.notify@gmail.com", "HomeCooked");
            var toAddress = new MailAddress(email, username);
            string fromPassword = "homecooked1234";
            string subject = "Verifique su cuenta";
            string body = "Acceda al siguiente enlace para verificar su cuenta y poder disfrutar de HomeCooked:\n http://localhost:65527/login?id=" + id;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        internal static void VerifyAccount(string id)
        {
            if (!IsValidate(id))
            {
                using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
                {
                    //Tabla de Usuarios
                    db.Open();

                    string tableCommand = "UPDATE Users SET Validate = @Val WHERE Validate = @OldVal";
                    SqliteCommand updateUser = new SqliteCommand(tableCommand, db);
                    updateUser.Parameters.AddWithValue("@Val", 1);
                    updateUser.Parameters.AddWithValue("@OldVal", id);
                    try
                    {
                        updateUser.ExecuteReader();
                    }
                    catch (SqliteException ex)
                    {
                        throw ex;
                    }
                    db.Close();
                }
            }
        }

        internal string Preferences(Preferences preferencias)
        {
            string res = "Este producto ";

            res = !preferencias.GetPref("shellfish") && !preferencias.GetPref("gluten") && !preferencias.GetPref("lactose") ?
                res + " no contiene ningún alérgeno, " : res + " contiene ";

            if (preferencias.GetPref("shellfish"))
            {
                res = res + "marisco, ";
            }
            if (preferencias.GetPref("gluten"))
            {
                res = res + "gluten, ";
            }
            if (preferencias.GetPref("lactose"))
            {
                res = res + "lactosa, ";
            }

            res = res.Substring(0, res.Count() - 2);
            res = res + ".";
            return res;
        }
    }
}