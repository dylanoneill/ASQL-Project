using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ASQLProject {
    public class DAL {

        SqlConnection conn;

        public DAL() {

            //Edit web.config to configure connection string
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["yoyoConn"];
            conn = new SqlConnection(settings.ConnectionString);
        }

        public DataTable FinalYield() {

            //Get number of packaged and scrapped yoyos from database
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT (SELECT COUNT(*) FROM Yoyo) AS 'Packaged', COUNT(*) AS 'Scrapped' FROM Defect WHERE Response = 'SCRAP'");
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable FirstYield() {

            //Get number of packaged yoyos, number of reworked yoyos, and number of scrapped yoyos from database
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT (SELECT COUNT(*) FROM Yoyo) AS 'Packaged', (SELECT COUNT(*) FROM Defect WHERE Response = 'REWORK') AS 'Reworked', COUNT(*) AS 'Scrapped' FROM Defect WHERE Response = 'SCRAP'");
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            return dataTable;
        }

        public void AddUser(string username, string password, bool isAdmin) {
            conn.Open();
            //Adds a new administrative user to the database
            if (isAdmin == true) {
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password, isAdmin) VALUES ('" +
                    username + "', '" + password + "', 1)");
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            //Adds a new general user to the database
            else {
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password, isAdmin) VALUES ('" +
                   username + "', '" + password + "', 0)");
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void AddProduct(string SKU, string description, string colour) {

            //Adds a new product to the database
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Product (SKU, Description, Colour) VALUES ('" +
                SKU + "', '" + description + "', '" + colour + "')");
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}