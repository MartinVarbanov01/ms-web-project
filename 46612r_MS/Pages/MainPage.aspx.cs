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
            my_img.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(Entities._entities.Products.FirstOrDefault().Image);
        }

        protected void choose_photo_btn_Click(object sender, EventArgs e)
        {
            if (img_upload.HasFile)
            {
                int lenght = img_upload.PostedFile.ContentLength;
                byte[] pic = new byte[lenght];
                img_upload.PostedFile.InputStream.Read(pic, 0, lenght);
                var products = Entities._entities.Products;
                Products product = new Products() { UserID = (int)(Session["userID"] ?? 1), ProductName = "First Product", ProductDescription = "hope it works", Image = pic };
                Entities._entities.Products.Add(product);
                Entities._entities.SaveChanges();
            }
        }
        protected void AddTextBox(object sender, EventArgs e)
        {
            foreach (var product in Entities._entities.Products)
            {
                Panel name_desc = new Panel();
                Panel img_nm = new Panel();
                img_nm.Style.Add("display", "flex");
                Image img = new Image();
                img.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(product.Image);
                img.Style.Add("width", "60px");
                img.Style.Add("white-space", "nowrap");
                TextBox prodName = new TextBox();
                prodName.Text = product.ProductName;
                TextBox prodDesc = new TextBox();
                prodDesc.Text = product.ProductDescription;
                Literal lt = new Literal();
                lt.Text = "<br />";
                Literal lt1 = new Literal();
                lt1.Text = "<br />";
                img_nm.Controls.Add(img);
                name_desc.Controls.Add(prodName);
                name_desc.Controls.Add(lt1);
                name_desc.Controls.Add(prodDesc);
                img_nm.Controls.Add(name_desc);
                myPanel.Controls.Add(img_nm);
                myPanel.Controls.Add(lt);
            }
        }
    }
}