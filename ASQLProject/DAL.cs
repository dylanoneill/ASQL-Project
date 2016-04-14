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

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["yoyoConn"];
            conn = new SqlConnection(settings.ConnectionString);
        }

        public DataTable FinalYield() {

            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT (SELECT COUNT(*) FROM Yoyo) AS 'Packaged', COUNT(*) AS 'Scrapped' FROM Defect WHERE Response = 'SCRAP'");
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable FinalYieldFilterDate(DateTime startDate, DateTime endDate) {

            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT (SELECT COUNT(*) FROM Yoyo WHERE CreationTime BETWEEN '" + startDate.ToString() + "' AND '" + endDate.ToString()
                + "') AS 'Packaged', COUNT(*) AS 'Scrapped' FROM Defect WHERE Response = 'SCRAP' AND InspectionTime BETWEEN '" + startDate.ToString() + "' AND '" + endDate.ToString() + "'");
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable FirstYield() {

            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT (SELECT COUNT(*) FROM Yoyo) AS 'Packaged', (SELECT COUNT(*) FROM Defect WHERE Response = 'REWORK') AS 'Reworked', COUNT(*) AS 'Scrapped' FROM Defect WHERE Response = 'SCRAP'");
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable FirstYieldFilterDate(DateTime startDate, DateTime endDate) {

            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT (SELECT COUNT(*) FROM Yoyo WHERE CreationTime BETWEEN '" + startDate.ToString() + "' AND '" + endDate.ToString()
                + "') AS 'Packaged', (SELECT COUNT(*) FROM Defect WHERE Response = 'REWORK' AND InspectionTime BETWEEN '" + startDate.ToString() + "' AND '" + endDate.ToString()
                + "') AS 'Reworked', COUNT(*) AS 'Scrapped' FROM Defect WHERE Response = 'SCRAP' AND InspectionTime BETWEEN '" + startDate.ToString() + "' AND '" + endDate.ToString() + "'");
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable DefectPareto() {

            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT Reason, COUNT(*) AS 'Amount' FROM Defect GROUP BY Reason ORDER BY 'Amount' DESC");
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable DefectParetoFilterDate(DateTime startDate, DateTime endDate) {

            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT Reason, COUNT(*) AS 'Amount' FROM Defect WHERE InspectionTime BETWEEN '" + startDate.ToString() + "' AND '" + endDate.ToString() + "' GROUP BY Reason ORDER BY 'Amount' DESC");
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);

            return dataTable;
        }

        public void AddUser(string username, string password, bool isAdmin) {

            conn.Open();
            if (isAdmin == true) {
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password, isAdmin) VALUES ('" +
                    username + "', '" + password + "', 1)");
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
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

        public DataTable GetUsers() {


            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users");
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}