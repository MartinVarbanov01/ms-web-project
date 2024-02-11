using _46612r_MS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _46612r_MS.Pages
{
    public partial class DeleteUserAPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("~/Pages/LoginPage");
            }
            int userID = (int)Session["userID"];
            if(!Request.Params.AllKeys.Any(k => k == "userID"))
            {
                Response.Redirect("~/Pages/LoginPage");
            }
        }
    }
}