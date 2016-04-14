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
            DateTime startDate = new DateTime();

            startDate = Convert.ToDateTime(startDateTextBox.Text);
            string startTime = startTimeTextBox.Text;
            string endTime = endTimeTextBox.Text;
            string SKU = skuDropBox.DataValueField;

          
            
            dal.ChangeSchedule(startDate, startTime, endTime, SKU);
            

        }
    }
}