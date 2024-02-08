using _46612r_MS.Models;
using System;
using System.Collections.Generic;
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
            var users = Entities._entities.Users;
            if (Entities._entities.Users.FirstOrDefault(p => (p.Username == Username.Text || p.Email == Email.Text)) == null)
            {
                if (Password.Text == Password2.Text)
                {
                    Users createUser = new Users() { Username = Username.Text, Email = Email.Text, Password = Password.Text, RoleID = 2 };
                    users.Add(createUser);
                    Entities._entities.SaveChanges();
                    Session.Add("userID", Entities._entities.Users.FirstOrDefault(p => p.Email == Email.Text).IDUser);
                    Response.Redirect("MainPage.aspx");
                }
                else
                {
                    pass.Visible = true;
                }
            }
            else
            {
                MessageBox.Show(Page, "This User already exists");
            }
        }
    }
}