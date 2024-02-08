using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _46612r_MS.Pages
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null && false)
            {
                Response.Redirect("LoginPage");
            }
            string search = Request.Params.AllKeys.Any() ? Request.Params["search"] : "";

        }
    }
}