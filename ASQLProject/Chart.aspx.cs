using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace ASQLProject {
    public partial class Chart : System.Web.UI.Page {

        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {              
                trColour.Visible = false;
                trProduct.Visible = false;
                trDefect.Visible = false;

                if ((String)Session["Report"] == "First Yield") {

                    DataTable dataTable = dal.FirstYield();

                    string[] x = new string[3];
                    x[0] = "Packaged";
                    x[1] = "Reworked";
                    x[2] = "Scrapped";     
                             
                    int[] y = new int[3];
                    y[0] = Convert.ToInt32(dataTable.Rows[0][0]);
                    y[1] = Convert.ToInt32(dataTable.Rows[0][1]);
                    y[2] = Convert.ToInt32(dataTable.Rows[0][2]);
                    
                    reportChart.Series[0].Points.DataBindXY(x, y);
                    reportChart.Series[0].ChartType = SeriesChartType.Pie;
                    reportChart.Series[0].Label = "#VALX - #PERCENT";
                    tableGridview.DataSource = dataTable;
                    tableGridview.DataBind();
                }

                if ((String)Session["Report"] == "Final Yield") {

                    DataTable dataTable = dal.FinalYield();

                    string[] x = new string[2];
                    x[0] = "Packaged";
                    x[1] = "Scrapped";

                    int[] y = new int[2];
                    y[0] = Convert.ToInt32(dataTable.Rows[0][0]);
                    y[1] = Convert.ToInt32(dataTable.Rows[0][1]);
                   
                    reportChart.Series[0].Points.DataBindXY(x, y);
                    reportChart.Series[0].ChartType = SeriesChartType.Pie;
                    reportChart.Series[0].Label = "#VALX - #PERCENT";
                    tableGridview.DataSource = dataTable;
                    tableGridview.DataBind();
                }
            }
        }

        protected void filterDropdown_SelectedIndexChanged(object sender, EventArgs e) {

            if(filterDropdown.SelectedValue == "0") {

                trDate.Visible = true;
                trColour.Visible = false;
                trDefect.Visible = false;
                trProduct.Visible = false;
            }
            else if (filterDropdown.SelectedValue == "1") {

                trDate.Visible = false;
                trColour.Visible = true;
                trDefect.Visible = false;
                trProduct.Visible = false;
            }
            else if (filterDropdown.SelectedValue == "2") {

                trDate.Visible = false;
                trColour.Visible = false;
                trDefect.Visible = false;
                trProduct.Visible = true;
            }
            else {
      
                trDate.Visible = false;
                trColour.Visible = false;
                trDefect.Visible = true;
                trProduct.Visible = false;
            }
        }
    }
}