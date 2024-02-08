using System;
using _46612r_MS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _46612r_MS.Pages
{
    public partial class LoginPageaspx : System.Web.UI.Page
    {
        ManagementEntities _entities = new ManagementEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_btn_Click(object sender, EventArgs e)
        {
            var user = _entities.Users.FirstOrDefault(p =>
            (p.Username == Username.Text || p.Email == Username.Text)
            && p.Password == Password.Text
            );
            string x = user.Username;
        }
    }
}