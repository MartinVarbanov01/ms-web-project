using _46612r_MS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _46612r_MS.Pages
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("LoginPage");
            }
            int userID = (int)Session["userID"];
            Users users = Entities._entities.Users.FirstOrDefault(user => user.IDUser == userID);
            profilePic.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(users.Photo);
            profilePic.Style.Add("width", "200px");
            profilePic.Style.Add("height", "200px");
            profilePic.Style.Add("border-radius", "5px");
            profileUsername.Text = users.Username;
            profileEmail.Text = users.Email;
        }

        protected void editProfile_Click(object sender, EventArgs e)
        {
            profilePassOld.Visible = true;
            profilePassNew.Visible = true;
            profilePassNew2.Visible = true;
            profilePassOld_lbl.Visible = true;
            profilePassNew_lbl.Visible = true;
            profilePassNew2_lbl.Visible = true;
            saveProfile.Visible = true;
            profilePic_uploader.Visible = true;
        }

        protected void saveProfile_Click(object sender, EventArgs e)
        {
            int userID = (int)Session["userID"];
            Users UserProf = Entities._entities.Users.FirstOrDefault(u => u.IDUser == userID);
            if (profilePic_uploader.HasFile)
            {
                var length = profilePic_uploader.PostedFile.ContentLength;
                byte[] pic = new byte[length];
                profilePic_uploader.PostedFile.InputStream.Read(pic, 0, length);
                UserProf.Photo = pic;
                Entities._entities.SaveChanges();
            }
            if(profilePassNew.Text != "")
            {
                if(profilePassNew.Text != profilePassNew2.Text)
                {
                    error.Visible = true;
                    error.Text = "New passwords don't match!";
                    return;
                }
                if(profilePassOld.Text != UserProf.Password)
                {
                    error.Visible = true;
                    error.Text = "Incorrect old password!";
                    return;
                }
                UserProf.Password = profilePassNew.Text;
            }
            error.Visible = false;
        }

        protected void myProd_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Items");
        }
    }
}