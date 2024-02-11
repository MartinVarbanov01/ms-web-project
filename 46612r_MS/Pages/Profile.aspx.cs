using _46612r_MS.Models;
using Microsoft.AspNet.Identity;
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
        Users usersGlobal = new Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("~/Pages/LoginPage");
            }
            int userID = (int)Session["userID"];
            usersGlobal = GetUser();
            LoadProfile(usersGlobal, userID != usersGlobal.IDUser);
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
            if (profilePassNew.Text != "")
            {
                if (profilePassNew.Text != profilePassNew2.Text)
                {
                    error.Visible = true;
                    error.Text = "New passwords don't match!";
                    return;
                }
                if (profilePassOld.Text != UserProf.Password)
                {
                    error.Visible = true;
                    error.Text = "Incorrect old password!";
                    return;
                }
                UserProf.Password = profilePassNew.Text;
                Entities._entities.SaveChanges();
                Session["userID"] = null;
                Response.Redirect("~/Pages/LoginPage");
            }
            Response.Redirect(Request.RawUrl);
            error.Visible = false;
        }

        protected void myProd_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Items?userID=" + usersGlobal.IDUser);
        }
        private void LoadProfile(Users users, bool isAdmin)
        {
            profilePic.ImageUrl = Entities.GetImageFromBytes(users.Photo);
            profilePic.Style.Add("width", "200px");
            profilePic.Style.Add("height", "200px");
            profilePic.Style.Add("border-radius", "5px");
            profileUsername.Text = users.Username;
            profileEmail.Text = users.Email;
            SuspendUser_btn.Visible = false;
            unSuspendUser_btn.Visible = false;
            if (isAdmin)
            {
                editProfile.Visible = false;
                deleteUser_btn.Visible = false;
                if (users.RoleID != 3)
                {
                    SuspendUser_btn.Visible = true;
                    unSuspendUser_btn.Visible = false;
                }
                else
                {
                    SuspendUser_btn.Visible = false;
                    unSuspendUser_btn.Visible = true;
                }
            }
        }
        private Users GetUser()
        {
            int userID = (int)Session["userID"];
            Users users = Entities._entities.Users.FirstOrDefault(user => user.IDUser == userID);
            if (users.RoleID == 1)
            {
                if (Request.Params.AllKeys.Any(usr => usr == "userID"))
                {
                    try
                    {
                        userID = Int32.Parse(this.Request.Params["userID"]);
                        Users adminInUser = Entities._entities.Users.FirstOrDefault(user => user.IDUser == userID);
                        return adminInUser;
                    }
                    catch { Response.Redirect("~/Pages/ProfilePage"); }
                }
            }
            return users;
        }

        protected void SuspendUser_btn_Click(object sender, EventArgs e)
        {
            int userID = Int32.Parse(Request.Params["userID"]);
            Entities._entities.Users.FirstOrDefault(u => u.IDUser == userID).RoleID = 3;
            Entities._entities.SaveChanges();
            Response.Redirect(Request.RawUrl);
        }

        protected void unSuspendUser_btn_Click(object sender, EventArgs e)
        {
            int userID = Int32.Parse(Request.Params["userID"]);
            Entities._entities.Users.FirstOrDefault(u => u.IDUser == userID).RoleID = 2;
            Entities._entities.SaveChanges();
            Response.Redirect(Request.RawUrl);
        }
    }
}