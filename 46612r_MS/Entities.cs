using System;
using _46612r_MS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.Entity.Migrations;
using System.Web.UI;

namespace _46612r_MS
{
    public static class Entities
    {
        public static ManagementEntities _entities = new ManagementEntities();
        public static Panel GetProductFromDB(Products product)
        {
            Image Img = new Image();
            Img.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(product.ProductsImages.FirstOrDefault().Image);
            Img.CssClass = "imageProd";
            Img.Style.Add("border-radius", "10px");
            Img.Style.Add("border", "solid 2px");
            Img.Style.Add("box-shadow", "2px 2px #858585");
            Img.Style.Add("margin", "auto 5px auto 10px");

            Label prodName = new Label();
            prodName.Text = "<b>"+product.ProductName+"</b>";
            prodName.Style.Add("font-size", "22px");
            prodName.Style.Add("font-width", "bold");
            prodName.Style.Add("border", "none");

            Label prodDesc = new Label();
            prodDesc.Text = product.ProductDescription.Substring(0, product.ProductDescription.Length > 200 ? 200 : product.ProductDescription.Length) + (product.ProductDescription.Length > 200 ? "...<br/><b><u>Виж още</u></b>" : "");

            Label prodPrice = new Label();
            prodPrice.Style.Add("margin-right", "10px");
            prodPrice.Style.Add("font-weight", "bold");
            prodPrice.Style.Add("text-wrap", "nowrap");
            prodPrice.Style.Add("font-family", "fantasy");
            prodPrice.Style.Add("width", "100%");
            prodPrice.Text = product.Price.ToString() + " лв.";

            Literal lt1 = new Literal();
            lt1.Text = "<p></p>";


            Panel PricePanel = new Panel();
            PricePanel.Style.Add("text-align", "right");
            PricePanel.Style.Add("align-self", "flex-end");
            PricePanel.Style.Add("width", "100%");
            PricePanel.Controls.Add(prodPrice);


            Panel NameDescPanel = new Panel();
            NameDescPanel.Style.Add("margin-top", "10px");
            NameDescPanel.Controls.Add(prodName);
            NameDescPanel.Controls.Add(new Label() { Text = "<br/>"});
            NameDescPanel.Controls.Add(prodDesc);
            NameDescPanel.Controls.Add(lt1);
            NameDescPanel.Controls.Add(PricePanel);


            Panel NDPricePanel = new Panel();
            NDPricePanel.Style.Add("display", "flex");
            NDPricePanel.Style.Add("width", "100%");
            NDPricePanel.Controls.Add(NameDescPanel);
            NDPricePanel.Controls.Add(PricePanel);


            Panel ProdPanel = new Panel();
            ProdPanel.ID = product.IDProduct.ToString();
            ProdPanel.Style.Add("display", "flex");
            ProdPanel.Style.Add("margin", "auto");
            ProdPanel.Style.Add("width", "50%");
            ProdPanel.Style.Add("min-height", "220px");
            ProdPanel.Style.Add("Border", "solid 2px");
            ProdPanel.Style.Add("border-radius", "20px");
            ProdPanel.Attributes.Add("onclick", "productClicked(this.id)");
            ProdPanel.Controls.Add(Img);
            ProdPanel.Controls.Add(NDPricePanel);
            
            
            return ProdPanel;
        }
    }
}