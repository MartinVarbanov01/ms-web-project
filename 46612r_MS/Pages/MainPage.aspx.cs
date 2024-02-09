using _46612r_MS.Models;
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

        protected void choose_photo_btn_Click(object sender, EventArgs e)
        {
            if (img_upload.HasFile)
            {
                int lenght = img_upload.PostedFile.ContentLength;
                byte[] pic = new byte[lenght];
                img_upload.PostedFile.InputStream.Read(pic, 0, lenght);
                var products = Entities._entities.Products;
                Products product = new Products() {UserID=1, ProductName="First Product", ProductDescription="hope it works"};
                var ent = Entities._entities.Products;
                ent.Add(product);
                Entities._entities.SaveChanges();
            }
        }
    }
}