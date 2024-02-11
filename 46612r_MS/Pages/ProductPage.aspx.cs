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
                unSuspendProd_btn.Visible = false;
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
                unSuspendProd_btn.Visible = false;
                deleteProd_btn.Visible = false;
                prodNotFound_lbl.Visible = true;
                return;
            }
            if (product.ProductStatusID == 2)
            {
                if (userID != product.UserID && user.RoleID != 1)
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
            else if (user.RoleID == 1)
            {
                editPanel.Visible = true;
                if (product.ProductStatusID == 1)
                {
                    suspdenProd_btn.Visible = true;
                    unSuspendProd_btn.Visible = false;
                }
                else if (product.ProductStatusID == 2)
                {
                    suspdenProd_btn.Visible = false;
                    unSuspendProd_btn.Visible = true;
                }
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
        private void AllowEdit()
        {
            editPanel.Visible = true;
            deleteProd_btn.Visible = true;
            editProd_btn.Visible = true;
        }

        protected void suspdenProd_btn_Click(object sender, EventArgs e)
        {
            int prodID = Int32.Parse(Request.Params["prodID"]);
            Products product = Entities._entities.Products.FirstOrDefault(p => p.IDProduct == prodID);
            product.ProductStatusID = 2;
            Entities._entities.SaveChanges();
            Response.Redirect(Request.RawUrl);
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

        protected void unSuspendProd_btn_Click(object sender, EventArgs e)
        {
            int prodID = Int32.Parse(Request.Params["prodID"]);
            Products product = Entities._entities.Products.FirstOrDefault(p => p.IDProduct == prodID);
            product.ProductStatusID = 1;
            Entities._entities.SaveChanges();
            Response.Redirect(Request.RawUrl);
        }

        protected void editProd_btn_Click(object sender, EventArgs e)
        {
            saveChanges_btn.Visible = true;
            photoUpload_lbl.Visible = true;
            pic_uploader.Visible = true;
            prodPrice.ReadOnly = false;
            prodName.ReadOnly = false;
            prodDesc.ReadOnly = false;
        }

        protected void saveChanges_btn_Click(object sender, EventArgs e)
        {
            int prodID = Int32.Parse(Request.Params["prodID"]);
            Products product = Entities._entities.Products.FirstOrDefault(u => u.IDProduct == prodID);
            product.ProductName = prodName.Text;
            product.ProductDescription = prodDesc.Text;
            product.Price = decimal.Parse(prodPrice.Text.Split(' ').ToList()[0]);
            if (pic_uploader.HasFile)
            {
                var length = pic_uploader.PostedFile.ContentLength;
                byte[] pic = new byte[length];
                pic_uploader.PostedFile.InputStream.Read(pic, 0, length);
                ProductsImages images = new ProductsImages() { ProductID = product.IDProduct, Image=pic};
                product.ProductsImages.Add(images);
            }
            Entities._entities.SaveChanges();
            Response.Redirect(Request.RawUrl);
        }
    }
}