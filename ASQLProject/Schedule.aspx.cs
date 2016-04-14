using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASQLProject
{
    public partial class Scehdule : System.Web.UI.Page
    {
        DAL dal = new DAL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            string startDate = startDateTextBox.Text;
            string startTime = startTimeTextBox.Text;
            string endTime = endTimeTextBox.Text;
            string SKU = skuDropBox.Text;


            if (startDate != "" && startTime != "" && endTime != "")
            {
                dal.ChangeSchedule(startDate, startTime, endTime, SKU);
                errorLabel.Text = "Database Updated";
            }
            else
            {
                errorLabel.Text = "Invalid fields";
            }
            

        }
    }
}