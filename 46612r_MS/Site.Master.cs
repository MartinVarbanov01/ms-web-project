using _46612r_MS.Models;
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
            if (Session["userID"] == null)
            {
                Response.Redirect("LoginPage");
            }
            if (search_items.Text != "Search Alazomn")
            {
                Response.Redirect("~/Pages/MainPage?search=" + search_items.Text);
            }
            int userID = (int)Session["userID"];
            Users user = Entities._entities.Users.FirstOrDefault(u => u.IDUser == userID);
            if(user.RoleID == 1)
            {
                admin_btn.Visible = true;
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

        protected void admin_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AdminPage");
        }
    }
}