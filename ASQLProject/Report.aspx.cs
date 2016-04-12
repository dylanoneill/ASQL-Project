using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASQLProject {
    public partial class Report : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void FirstYieldClicked(object sender, EventArgs e) {
            Session["Report"] = "First Yield";
            Response.Redirect("Chart.aspx");
        }

        protected void FinalYieldClicked(object sender, EventArgs e) {
            Session["Report"] = "Final Yield";
            Response.Redirect("Chart.aspx");
        }

        protected void DefectParetoClicked(object sender, EventArgs e) {
            Session["Report"] = "Defects";
            Response.Redirect("Chart.aspx");
        }
    }
}