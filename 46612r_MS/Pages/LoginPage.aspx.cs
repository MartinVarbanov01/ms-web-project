using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace _46612r_MS.Pages
{
    public partial class LoginPageaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_btn_Click(object sender, EventArgs e)
        {
            var user = Entities._entities.Users.FirstOrDefault(p =>
            p.Email == UserEmail.Text
            && p.Password == UserPassword.Text
            );
            if(user == null)
            {
                wrong_pass.Visible = true;
                //MessageBox.Show(this.Page, "ERROR! Email has been send to the developer.");
                return;
            }
            Session.Add("userID", user.IDUser);
            Response.Redirect("MainPage.aspx");
        }

        protected void Register_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }
    }
}