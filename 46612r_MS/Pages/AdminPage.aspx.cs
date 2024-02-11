using _46612r_MS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _46612r_MS.Pages
{
    class UserList
    {
        public int IDUser { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Photo { get; set; }
        public string ProfilePic { get; set; }
        public UserList(int IDUser, string Username, string Email, string Role, string Photo)
        {
            this.IDUser = IDUser;
            this.Username = Username;
            this.Email = Email;
            this.Role = Role;
            this.Photo = Photo;
            this.ProfilePic = Photo;
        }
    }
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("~/Pages/LoginPage");
            }
            var usersList = Entities._entities.Users.Select(u => new
            {
                u.IDUser,
                u.Username,
                u.Email,
                u.Roles.Role,
                u.Photo,
            }).ToList();
            List<UserList> userLists = new List<UserList>();
            foreach (var user in usersList)
            {
                userLists.Add(new UserList(user.IDUser, user.Username,user.Email,user.Role,Entities.GetImageFromBytes(user.Photo)));
            }
            users.DataSource = userLists;
            users.DataBind();
        }

        protected void users_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;
            MessageBox.Show(this.Page, gridView.SelectedIndex.ToString());
        }

        protected void users_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image img = e.Row.Cells[1].Controls[0] as Image;
                img.ImageUrl = DataBinder.Eval(e.Row.DataItem, "ProfilePic").ToString();
                img.Style.Add("height","50px");
                img.Style.Add("width","50px");
            }
        }
    }
}