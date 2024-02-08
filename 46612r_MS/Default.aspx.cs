using _46612r_MS.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _46612r_MS
{
    public partial class _Default : Page
    {
        private ManagementEntities _entities = new ManagementEntities();
        private Users employee = new Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            employee = new Users { Username = "KOka", Password = "dsa", Email = "banana", RoleID = 2 };
            var x = _entities.Roles.Select(p => new
            {
                p.IDRole,
                p.Role,
            }
            ).ToList();
            var users = _entities.Users;
            users.Add(employee);
            _entities.SaveChanges();
        }
    }
}