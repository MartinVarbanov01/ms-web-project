using System;
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
    public partial class Items : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("LoginPage");
            }
            int userID = (int)Session["userID"];
            foreach (var product in Entities._entities.Users.FirstOrDefault(u => u.IDUser == userID).Products)
            {
                Panel name_desc = new Panel();
                name_desc.Style.Add("margin-top", "10px");
                Panel img_nm = new Panel();
                img_nm.ID = product.IDProduct.ToString();
                img_nm.Style.Add("display", "flex");
                img_nm.Style.Add("margin", "auto");
                img_nm.Style.Add("width", "50%");
                img_nm.Style.Add("min-height", "220px");
                img_nm.Style.Add("Border", "solid 2px");
                img_nm.Style.Add("border-radius", "5px");
                img_nm.Attributes.Add("onclick", "productClicked(this.id)");
                Image img = new Image();
                img.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(product.ProductsImages.FirstOrDefault().Image);
                img.Style.Add("width", "200px");
                img.Style.Add("height", "200px");
                img.Style.Add("border-radius", "5px");
                img.Style.Add("margin", "10px 5px 10px 10px");
                Label prodName = new Label();
                prodName.Text = product.ProductName;
                prodName.Style.Add("font-size", "22px");
                prodName.Style.Add("font-width", "bold");
                prodName.Style.Add("border", "none");
                Label prodDesc = new Label();
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

        protected void addProduct_btn_Click(object sender, EventArgs e)
        {
            int userID = (int)Session["userID"];
            if(prodName.Text == "" || prodDesc.Text == "" || !prodPic.HasFile || prodPrice.Text == "")
            {
                MessageBox.Show(this.Page, "Not all fields are filled!");
                return;
            }
            int length = prodPic.PostedFile.ContentLength;
            byte[] pic = new byte[length];
            prodPic.PostedFile.InputStream.Read(pic, 0, length);
            var product = new Products()
            {
                ProductName = prodName.Text,
                ProductDescription = prodDesc.Text,
                UserID = userID,
                Price = Decimal.Parse(prodPrice.Text),
            };
            Entities._entities.ProductsImages.Add(new ProductsImages() { Image = pic, ProductID = product.IDProduct });
            Entities._entities.Products.Add(product);
            Entities._entities.SaveChanges();
        }
    }
}