using _46612r_MS.Models;
using Microsoft.AspNet.Identity;
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
            try
            {
                int userForDell = Int32.Parse(Request.Params["userID"]);
                if (userID != userForDell)
                {
                    Response.Redirect("~/Pages/Profile");
                }
            }
            catch { Response.Redirect("~/Pages/Profile"); }
            Users user = Entities._entities.Users.FirstOrDefault(u => u.IDUser == userID);
            foreach (var product in user.Products)
            {
                DeleteUserProducts(product.IDProduct);
            }
            user.Username = "";
            user.Password = "";
            user.Email = "";
            user.RoleID = 4;
            user.Photo = new byte[0];
            Entities._entities.SaveChanges();
            Session["userID"] = null;
            Response.Redirect("~/Pages/LoginPage");
        }
        private void DeleteUserProducts(int prodID)
        {
            Products product = Entities._entities.Products.FirstOrDefault(p => p.IDProduct == prodID);
            product.ProductStatusID = 3;
            product.ProductName = "";
            product.ProductDescription = "";
            product.Price = 0;
            foreach (var image in product.ProductsImages)
            {
                image.Image = new byte[0];
            }
        }
    }
}