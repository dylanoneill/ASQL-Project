using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ASQLProject {
    public partial class Login : System.Web.UI.Page {

        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void LoginClicked(object sender, EventArgs e) {

            //Response.Redirect("Admin.aspx");
            VerifyUser(usernameTextBox.Text);
        }

        private void VerifyUser(string user)
        {
            
            DataTable dataTable = new DataTable();
            dataTable = dal.GetUser();

            foreach (DataRow row in dataTable.Rows)
            {
                if (Convert.ToString(row[0]) == usernameTextBox.Text)
                {
                    if (Convert.ToString(row[1]) == passwordTextBox.Text)
                    {
                        if (Convert.ToInt32(row[2]) == 1)
                        {
                            Session["User"] = "admin";
                            Response.Redirect("Admin.aspx");
                        }
                        else
                        {
                            Session["User"] = "general";
                            Response.Redirect("Admin.aspx");
                        }
                    }
                    else
                    {
                        errorLogin.Text = "Incorrect Username or Password";
                    }
                }
                else
                {
                    errorLogin.Text = "Incorrect Username or Password";
                }
            }

        }
    }
}