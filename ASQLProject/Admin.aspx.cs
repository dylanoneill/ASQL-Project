using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ASQLProject {
    public partial class Admin : System.Web.UI.Page {

        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
               
                tdCreateUser.Visible = false;
                tdCreateProduct.Visible = false;
                userFbLabel.Visible = false;
            }
        }

        protected void reportButton_Click(object sender, EventArgs e) {
            Response.Redirect("Report.aspx");
        }

        protected void createProductButton_Click(object sender, EventArgs e) {

            tdCreateProduct.Visible = true;
            tdCreateUser.Visible = false;
        }

        protected void createUserButton_Click(object sender, EventArgs e) {
            tdCreateUser.Visible = true;
            tdCreateProduct.Visible = false;
        }       

        protected void addUserButton_Click(object sender, EventArgs e) {

            userFbLabel.Visible = true;
            if (passwordTextbox.Text == confirmTextbox.Text) {

                bool isAdmin = false;
                if (adminCheckbox.Checked == true) {
                    isAdmin = true;
                }

                try {
                    dal.AddUser(usernameTextbox.Text, passwordTextbox.Text, isAdmin);
                    userFbLabel.Text = "User Created Successfully.";
                }
                catch (SqlException) {
                    userFbLabel.Text = "Username already exists.";
                }
            }
            else {
                userFbLabel.Text = "Passwords do not match.";
            }
        }

        protected void addProductButton_Click(object sender, EventArgs e) {

            try {
                dal.AddProduct(skuTextbox.Text, descTextbox.Text, colourDropdown.SelectedValue);
                productFbLabel.Text = "Product Created Successfully.";
            }
            catch (SqlException) {
                productFbLabel.Text = "Error Creating Product.";
            }
        }
    }
}