using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _46612r_MS
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (search_items.Text != "Search Alazomn")
            {
                Response.Redirect("~/Pages/MainPage?search=" + search_items.Text);
            }
        }

        protected void search_items_TextChanged(object sender, EventArgs e)
        {
            if(search_items.Text != "Search Alazomn")
            {
                Response.Redirect("~/Pages/MainPage?search=" + search_items.Text);
            }
            else
            {
                Response.Redirect("~/Pages/MainPage");
            }
        }

        protected void profile_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Profile");
        }

        protected void logout_btn_Click(object sender, EventArgs e)
        {
            Session["userID"] = null;
            Response.Redirect("~/Pages/LoginPage");
        }
    }
}