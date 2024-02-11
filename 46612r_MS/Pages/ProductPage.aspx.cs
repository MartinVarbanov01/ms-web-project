using _46612r_MS.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _46612r_MS.Pages
{
    public partial class ProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("~/Pages/LoginPage");
            }
            int userID = (int)Session["userID"];
            Users user = Entities._entities.Users.FirstOrDefault(u => u.IDUser == userID);
            if (Request.Params["prodID"] == null || Request.Params["prodID"] == "")
            {
                mainPanel.Visible = false;
                suspdenProd_btn.Visible = false;
                deleteProd_btn.Visible = false;
                prodNotFound_lbl.Visible = true;
                return;
            }
            int prodID = Int32.Parse(Request.Params["prodID"]);
            Products product = Entities._entities.Products.FirstOrDefault(p => p.IDProduct == prodID);
            if (product == null || product.ProductStatusID == 3)
            {
                mainPanel.Visible = false;
                suspdenProd_btn.Visible = false;
                deleteProd_btn.Visible = false;
                prodNotFound_lbl.Visible = true;
                return;
            }
            if (product.ProductStatusID == 2)
            {
                if (userID != product.UserID)
                {
                    mainPanel.Visible = false;
                    prodNotFound_lbl.Visible = true;
                    return;
                }
                suspendedProd_lbl.Visible = true;
            }
            if (userID == product.UserID)
            {
                AllowEdit();
            }
            else if (user.RoleID == 2)
            {
                deleteProd_btn.Visible = true;
            }
            if (product.ProductsImages.ToList().Count > 0)
                prodImg1.ImageUrl = Entities.GetImageFromBytes(product.ProductsImages.ToList()[0].Image);
            if (product.ProductsImages.ToList().Count > 1)
                prodImg2.ImageUrl = Entities.GetImageFromBytes(product.ProductsImages.ToList()[1].Image);
            if (product.ProductsImages.ToList().Count > 2)
                prodImg3.ImageUrl = Entities.GetImageFromBytes(product.ProductsImages.ToList()[2].Image);
            if (product.ProductsImages.ToList().Count > 3)
                prodImg4.ImageUrl = Entities.GetImageFromBytes(product.ProductsImages.ToList()[3].Image);
            prodName.Text = product.ProductName;
            prodDesc.Text = product.ProductDescription;
            prodPrice.Text = product.Price.ToString() + " лв.  ";
        }

        protected void prodImg1_Click(object sender, ImageClickEventArgs e)
        {

        }
        private void AllowEdit()
        {
            deleteProd_btn.Visible = true;
        }

        protected void suspdenProd_btn_Click(object sender, EventArgs e)
        {
            int prodID = Int32.Parse(Request.Params["prodID"]);
            Products product = Entities._entities.Products.FirstOrDefault(p => p.IDProduct == prodID);
            product.ProductStatusID = 2;
            Entities._entities.SaveChanges();
            Response.Redirect("~/Pages/MainPage");
        }

        protected void deleteProd_btn_Click(object sender, EventArgs e)
        {
            int prodID = Int32.Parse(Request.Params["prodID"]);
            Products product = Entities._entities.Products.FirstOrDefault(p => p.IDProduct == prodID);
            product.ProductStatusID = 3;
            product.ProductName = "";
            product.ProductDescription = "";
            product.Price = 0;
            foreach (var image in product.ProductsImages)
            {
                image.Image = new byte[0];
            }
            Entities._entities.SaveChanges();
            Response.Redirect("~/Pages/MainPage");
        }
    }
}