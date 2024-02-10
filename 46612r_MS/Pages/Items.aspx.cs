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
            foreach (var product in Entities._entities.Users.FirstOrDefault(u => u.IDUser == userID).Products.Where(p => p.ProductStatusID == 1))
            {
                Literal lt = new Literal();
                lt.Text = "<br />";
                myPanel.Controls.Add(Entities.GetProductFromDB(product));
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
                ProductStatusID = 1,
            };
            Entities._entities.ProductsImages.Add(new ProductsImages() { Image = pic, ProductID = product.IDProduct });
            Entities._entities.Products.Add(product);
            Entities._entities.SaveChanges();
            prodName.Text = string.Empty;
            prodDesc.Text = string.Empty;
            prodPrice.Text = string.Empty;
        }
    }
}