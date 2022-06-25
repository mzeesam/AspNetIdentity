using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CreateUser : System.Web.UI.Page
    {
        static UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
        UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

        static RoleStore<IdentityRole> sStore = new RoleStore<IdentityRole>();
        static RoleManager<IdentityRole> rManager = new RoleManager<IdentityRole>(sStore);

        protected void Page_Load(object sender, EventArgs e)
        {
            lblOutput.ForeColor = System.Drawing.Color.Black;
            if (!IsPostBack)
            {

                LoadRoles();
            }
        }

        private void LoadRoles()
        {
            var roles = rManager.Roles.ToList();
            RolesList.Items.Clear();
            foreach (var role in roles)
            {
                var item = new ListItem(role.Name, role.Id);
                RolesList.Items.Add(item);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            var user = new IdentityUser
            {
                UserName = UserNameTextBox.Text,
                Email = EmailTextBox.Text
            };

            var IdentityResult = manager.Create(user, PasswordTextBox.Text);
            if (IdentityResult.Succeeded)
            {
                lblOutput.Text = $"{user.UserName} user has been created.";
            }
            else
            {
                lblOutput.Text = IdentityResult.Errors.ToList()[0];
                lblOutput.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var user = manager.FindByEmail(TextBox1.Text);

            if (user != null)
            {
                lblOutput.Text = $"User found: {user.UserName}";

                //display roles
                //foreach (var item in roles)
                //    {
                //        lblOutput.Text += item.Name + "<br />";
                //    }
            }
        }

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            var roles = rManager.Roles.ToList();
            var nRole = new IdentityRole() { Id = (roles.Count() + 1).ToString(), Name = txtRoleName.Text };
            var iResult = new IdentityResult();
            iResult = rManager.Create(nRole);
            if (iResult.Succeeded)
            {
                lblOutput.Text = $"{nRole.Name} role has been created.";
                txtRoleName.Text = null;
            }
            else
            {
                lblOutput.Text = iResult.Errors.ToList()[0];
                lblOutput.ForeColor = System.Drawing.Color.Red;
            }
            LoadRoles();
        }

        protected void btnAssignUser_Click(object sender, EventArgs e)
        {
            var user = manager.FindByEmail(TextBox1.Text);

            if (user != null)
            {
                foreach (ListItem item in RolesList.Items)
                {
                    if (item.Selected)
                    {
                        var nRole = rManager.FindByName(item.Text);
                        if (nRole != null)
                        {
                            if (!manager.IsInRole(user.Id, nRole.Name))
                            {
                                manager.AddToRole(user.Id, nRole.Name);
                            }
                        }
                    }
                }
            }

        }
    }
}