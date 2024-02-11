using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _46612r_MS.Pages
{
    public partial class GetSeassionhtml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("~/Pages/LoginPage");
            }
            int user = (int)Session["userID"];
            this.Response.ContentType = "text/plain;charset=utf-8";
            this.Response.StatusCode = (int)HttpStatusCode.OK;
            this.Response.Write(user);
            this.Response.End();

        }
    }
}