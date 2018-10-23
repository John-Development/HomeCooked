using HomeCook.Clases;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeCook
{
    public partial class SiteMaster : MasterPage
    {
        User logedUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((logedUser = (User)Session["logedUser"]) == null)
                Perfil.InnerText = "Iniciar sesión";
            else
                Perfil.InnerText = "Perfil";

            //Crea las nuevas bbdd
            using (SqliteConnection db = new SqliteConnection("Filename=DB.db"))
            {
                //Tabla de Usuarios

                db.Open();
                string tableCommand = "CREATE TABLE IF NOT EXISTS Users (Username NVARCHAR(2048) PRIMARY KEY, Password NVARCHAR(2048), Email INTEGER, Location NVARCHAR(2048), Image NVARCHAR(2048), Contact NVARCHAR(2048), Preferences NVARCHAR(2048), Rank INTEGER)";
                //string tableCommand = "DROP TABLE IF EXISTS Users";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                try
                {
                    createTable.ExecuteReader();
                }
                catch (SqliteException)
                {
                    //Do nothing
                }
                db.Close();

                ////Tabla de MARCADORES

                //db.Open();
                //tableCommand = "CREATE TABLE IF NOT EXISTS Score (ID INTEGER PRIMARY KEY, Length TEXT, History NVARCHAR(2048), TimesA NVARCHAR(2048), TimesB NVARCHAR(2048), SetLen TEXT)";
                ////string tableCommand = "DROP TABLE IF EXISTS Events";
                //createTable = new SqliteCommand(tableCommand, db);
                //try
                //{
                //    createTable.ExecuteReader();
                //}
                //catch (SqliteException)
                //{
                //    //Do nothing
                //}
                //db.Close();

                ////Tabla de TORNEOS

                //db.Open();
                //tableCommand = "CREATE TABLE IF NOT EXISTS Tournament (ID INTEGER PRIMARY KEY, Name NVARCHAR(2048), Ended INTEGER, Rules NVARCHAR(2048), Date TEXT NULL, Description TEXT NULL, Place NVARCHAR(2048) NULL, Leq NVARCHAR(2048) NULL, LeqCopy NVARCHAR(2048) NULL, UltRonda INTEGER, Rondas INTEGER)";
                ////string tableCommand = "DROP TABLE IF EXISTS Events";
                //createTable = new SqliteCommand(tableCommand, db);
                //try
                //{
                //    createTable.ExecuteReader();
                //}
                //catch (SqliteException)
                //{
                //    //Do nothing
                //}
                //db.Close();

                ////Tabla de LIGAS

                //db.Open();
                //tableCommand = "CREATE TABLE IF NOT EXISTS League (ID INTEGER PRIMARY KEY, Name NVARCHAR(2048), Ended INTEGER, Rules NVARCHAR(2048), Date TEXT NULL, Description TEXT NULL, Place NVARCHAR(2048) NULL, Leq NVARCHAR(2048) NULL, LeqCopy NVARCHAR(2048) NULL)";
                ////string tableCommand = "DROP TABLE IF EXISTS Events";
                //createTable = new SqliteCommand(tableCommand, db);
                //try
                //{
                //    createTable.ExecuteReader();
                //}
                //catch (SqliteException)
                //{
                //    //Do nothing
                //}
                //db.Close();
            }
        }
    }
}