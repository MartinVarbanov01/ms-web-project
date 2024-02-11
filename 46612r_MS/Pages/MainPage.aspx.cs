using _46612r_MS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
            if (Session["userID"] == null)
            {
                Response.Redirect("~/Pages/LoginPage");
            }
            string search = Request.Params["search"] ?? "";
            LoadProducts(search);
        }
        protected void LoadProducts(string search)
        {
            foreach (var product in Entities._entities.Products.Where(p => p.Users.RoleID != 3 && p.ProductStatusID == 1 &&(search == "" || p.ProductName.ToLower().Contains(search.ToLower()))))
            {
                Literal lt = new Literal();
                lt.Text = "<br />";
                myPanel.Controls.Add(Entities.GetProductFromDB(product));
                myPanel.Controls.Add(lt);
            }
            noItems_lbl.Visible = false;
            if (myPanel.Controls.Count == 0)
            {
                noItems_lbl.Visible = true;
            }
        }
    }
}