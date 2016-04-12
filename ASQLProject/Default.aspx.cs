using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASQLProject {
    public partial class _default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Session.Timeout = 60;
            Response.Redirect("Login.aspx");
        }
    }
}