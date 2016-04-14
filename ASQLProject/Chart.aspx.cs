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
                reportHeading.InnerText = (String)Session["Report"] + " Report";

                reportChart.ChartAreas[0].Area3DStyle.Enable3D = true;
                //First yield default report
                if ((String)Session["Report"] == "First Time Yield") {

                    DataTable dataTable = dal.FirstYield();

                    string[] x = new string[3];
                    x[0] = "Packaged";
                    x[1] = "Reworked";
                    x[2] = "Scrapped";     
                             
                    int[] y = new int[3];
                    y[0] = Convert.ToInt32(dataTable.Rows[0][0]);
                    y[1] = Convert.ToInt32(dataTable.Rows[0][1]);
                    y[2] = Convert.ToInt32(dataTable.Rows[0][2]);

                    //Draw chart
                    reportChart.Series[0].Points.DataBindXY(x, y);
                    reportChart.Series[0].ChartType = SeriesChartType.Pie;
                    reportChart.Series[0].Label = "#VALX - #PERCENT";
                    tableGridview.DataSource = dataTable;
                    tableGridview.DataBind();
                }

                //Final yield default report
                else if ((String)Session["Report"] == "Final Yield") {

                    DataTable dataTable = dal.FinalYield();

                    string[] x = new string[2];
                    x[0] = "Packaged";
                    x[1] = "Scrapped";

                    int[] y = new int[2];
                    y[0] = Convert.ToInt32(dataTable.Rows[0][0]);
                    y[1] = Convert.ToInt32(dataTable.Rows[0][1]);

                    //Draw chart
                    reportChart.Series[0].Points.DataBindXY(x, y);
                    reportChart.Series[0].ChartType = SeriesChartType.Pie;
                    reportChart.Series[0].Label = "#VALX - #PERCENT";
                    tableGridview.DataSource = dataTable;
                    tableGridview.DataBind();
                }

                //Default defect report
                else if ((String)Session["Report"] == "Defect") {

                    DataTable dataTable = dal.DefectPareto(); 

                    string[] barX = new string[dataTable.Rows.Count];
                    int[] barY = new int[dataTable.Rows.Count];        
                    
                    for(int i = 0; i < dataTable.Rows.Count; i++) {
                        barX[i] = dataTable.Rows[i][0].ToString();
                        barY[i] = Convert.ToInt32(dataTable.Rows[i][1]);
                    }

                    //Calculate cumulative % for pareto chart
                    int total = barY.Sum();
                    double cumulative = 0.00;
                    double[] lineY = new double[barY.Count()];
                    for (int i = 0; i < barY.Count(); i++) {
                        cumulative += (Double)barY[i];
                        if (i == 0) {
                            lineY[i] = (Double)barY[i] / (Double)total * 100;
                        } else if(i == barY.Count() - 1) {
                            lineY[i] = 100;
                        } else {
                            lineY[i] = cumulative / (Double)total * 100;
                        }
                    }

                    //Draw chart
                    Series lineSeries = new Series();
                    reportChart.Series.Add(lineSeries);
                    reportChart.Series[0].Points.DataBindXY(barX, barY);
                    reportChart.Series[1].Points.DataBindXY(barX, lineY);
                    reportChart.Series[1].ChartType = SeriesChartType.Line;
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

        protected void dateFilterButton_Click(object sender, EventArgs e) {

            DataTable dataTable = new DataTable();
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            try {
                dateFbLabel.Text = "";
                startDate = Convert.ToDateTime(startDateTextbox.Text);
                endDate = Convert.ToDateTime(endDateTextbox.Text);
            } catch (FormatException) {
                dateFbLabel.Text = "Could not read date from input, see format above.";
            }

            if (startDate >= endDate) {
                dateFbLabel.Text = "Start Date must be before End Date.";
            }
            else {
                //first yield report filtered by date
                if ((String)Session["Report"] == "First Yield") {

                    dataTable = dal.FirstYieldFilterDate(startDate, endDate);
                    string[] x = new string[3];
                    x[0] = "Packaged";
                    x[1] = "Reworked";
                    x[2] = "Scrapped";

                    int[] y = new int[3];
                    y[0] = Convert.ToInt32(dataTable.Rows[0][0]);
                    y[1] = Convert.ToInt32(dataTable.Rows[0][1]);
                    y[2] = Convert.ToInt32(dataTable.Rows[0][2]);

                    //Draw chart
                    reportChart.Series[0].Points.DataBindXY(x, y);
                    reportChart.Series[0].ChartType = SeriesChartType.Pie;
                    reportChart.Series[0].Label = "#VALX - #PERCENT";
                    tableGridview.DataSource = dataTable;
                    tableGridview.DataBind();
                }

                //final yield report filtered by date
                else if ((String)Session["Report"] == "Final Yield") {

                    dataTable = dal.FinalYieldFilterDate(startDate, endDate);
                    string[] x = new string[2];
                    x[0] = "Packaged";
                    x[1] = "Scrapped";

                    int[] y = new int[2];
                    y[0] = Convert.ToInt32(dataTable.Rows[0][0]);
                    y[1] = Convert.ToInt32(dataTable.Rows[0][1]);

                    //Draw chart
                    reportChart.Series[0].Points.DataBindXY(x, y);
                    reportChart.Series[0].ChartType = SeriesChartType.Pie;
                    reportChart.Series[0].Label = "#VALX - #PERCENT";
                    tableGridview.DataSource = dataTable;
                    tableGridview.DataBind();
                }

                //defect report filtered by date
                else if ((String)Session["Report"] == "Defect") {

                    dataTable = dal.DefectParetoFilterDate(startDate, endDate);
                    string[] barX = new string[dataTable.Rows.Count];
                    int[] barY = new int[dataTable.Rows.Count];

                    for (int i = 0; i < dataTable.Rows.Count; i++) {
                        barX[i] = dataTable.Rows[i][0].ToString();
                        barY[i] = Convert.ToInt32(dataTable.Rows[i][1]);
                    }

                    //Calculate cumulative % for pareto chart
                    int total = barY.Sum();
                    double cumulative = 0.00;
                    double[] lineY = new double[barY.Count()];
                    for (int i = 0; i < barY.Count(); i++) {
                        cumulative += (Double)barY[i];
                        if (i == 0) {
                            lineY[i] = (Double)barY[i] / (Double)total * 100;
                        }
                        else if (i == barY.Count() - 1) {
                            lineY[i] = 100;
                        }
                        else {
                            lineY[i] = cumulative / (Double)total * 100;
                        }
                    }

                    //Draw chart
                    Series lineSeries = new Series();
                    reportChart.Series.Add(lineSeries);
                    reportChart.Series[0].Points.DataBindXY(barX, barY);
                    reportChart.Series[1].Points.DataBindXY(barX, lineY);
                    reportChart.Series[1].ChartType = SeriesChartType.Line;
                    tableGridview.DataSource = dataTable;
                    tableGridview.DataBind();
                }
            }
        }
    }
}