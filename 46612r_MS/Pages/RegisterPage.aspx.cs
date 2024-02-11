using _46612r_MS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _46612r_MS.Pages
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Register_btn_Click(object sender, EventArgs e)
        {
            byte[] pic = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Images/default-profile-icon.jpg"));
            var users = Entities._entities.Users;
            if (Username.Text == "" || Email.Text == "" || Password.Text == "" || Password2.Text == "")
            {
                MessageBox.Show(this.Page, "Please set all fields!");
                return;
            }
            if (Entities._entities.Users.FirstOrDefault(p => (p.Email == Email.Text)) == null)
            {
                if (Password.Text == Password2.Text)
                {
                    Users createUser = new Users() { Username = Username.Text, Email = Email.Text, Password = Password.Text, RoleID = 2, Photo = pic};
                    users.Add(createUser);
                    Entities._entities.SaveChanges();
                    Session.Add("userID", Entities._entities.Users.FirstOrDefault(p => p.Email == Email.Text).IDUser);
                    Response.Redirect("~/Pages/MainPage");
                }
                else
                {
                    pass.Visible = true;
                }
            }
            else
            {
                MessageBox.Show(Page, "This email is already registered");
            }
        }

        protected void login_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/LoginPage");
        }
    }
}