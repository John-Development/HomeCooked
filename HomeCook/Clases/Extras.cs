﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace HomeCook.Clases
{
    public class Extras
    {
        private static Dictionary<string, string[]> pendingActivation = new Dictionary<string, string[]>();

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
                        logedUser = new User(query.GetString(0), query.GetString(1), query.GetString(2), query.GetString(3), new Preferences(query.GetString(6)))
                        {
                            Image = query.IsDBNull(4) ? null : query.GetString(4),
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

        internal static string Register(string user, string email, string password, string location, Preferences pref)
        {
            string id = user + password;

            using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
            {
                //Tabla de Usuarios
                db.Open();
                string tableCommand = "INSERT INTO Users (Username, Email, Password, Location, Preferences) VALUES (@User, @Email, @Pass, @Loc, @Alerg)";
                SqliteCommand setUser = new SqliteCommand(tableCommand, db);
                setUser.Parameters.AddWithValue("@User", user);
                setUser.Parameters.AddWithValue("@Email", email);
                setUser.Parameters.AddWithValue("@Pass", password);
                setUser.Parameters.AddWithValue("@Loc", location);
                setUser.Parameters.AddWithValue("@Alerg", pref.ToString());
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
            return id.GetHashCode().ToString();
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

        internal static void VerificationEmail(string id, string username, string email, string password)
        {
            var fromAddress = new MailAddress("homecooked.notify@gmail.com", "HomeCooked");
            var toAddress = new MailAddress(email, username);
            string fromPassword = "homecooked1234";
            string subject = "Verifique su cuenta";
            string body = "Acceda al siguiente enlace para verificar su cuenta y poder disfrutar de HomeCooked:\n http://localhost:65527/login?id=" + id;

            pendingActivation.Add(id, new string[2]{ username, password });

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

        internal static User VerifyAccount(string id)
        {
            string[] user = pendingActivation[id];
            if (user != null)
            {
                pendingActivation.Remove(id);
                return Login(user[0], user[1]);
            }
            return null;
        }
    }
}