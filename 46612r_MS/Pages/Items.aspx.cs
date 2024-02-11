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
                Response.Redirect("~/Pages/LoginPage");
            }
            int userID = (int)Session["userID"];
            Users User = Entities._entities.Users.FirstOrDefault(u => u.IDUser == userID);
            if(User.RoleID == 1 && Request.Params.AllKeys.Any(k => k == "userID"))
            {
                try
                {
                    userID = Int32.Parse(Request.Params["userID"]);
                }
                catch { Response.Redirect("~/Pages/MainPage"); }
            }
            foreach (var product in Entities._entities.Users.FirstOrDefault(u => u.IDUser == userID).Products.Where(p => p.ProductStatusID == 1 || p.ProductStatusID == 2))
            {
                if (product == null) { continue; }
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
            Response.Redirect(Request.RawUrl);
        }
    }
}