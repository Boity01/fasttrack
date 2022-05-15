using FastTrackFront.Helpers;
using FastTrackFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FastTrackFront
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["User"];

            List<MenuObject> menus = new List<MenuObject>()
            {
                new MenuObject()
                {
                    ID = "HomeMenu",
                    Object = HomeMenu
                },
                new MenuObject()
                {
                    ID = "CompaniesMenu",
                    Object = CompaniesMenu
                },
                new MenuObject()
                {
                    ID = "AccountsMenu",
                    Object = AccountsMenu
                },
                new MenuObject()
                {
                    ID = "BookingsMenu",
                    Object = BookingsMenu
                },
                new MenuObject()
                {
                    ID = "RegisterCompayMenu",
                    Object = RegisterCompayMenu
                },
                new MenuObject()
                {
                    ID = "RegisterMenu",
                    Object = RegisterMenu
                },
                new MenuObject()
                {
                    ID = "LoginMenu",
                    Object = LoginMenu
                },
                new MenuObject()
                {
                    ID = "LogoutMenu",
                    Object = LogoutMenu
                }
            };

            MenuHelper.Menu(user, menus);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = Email.Value;
            string password = Password.Value;

            bool errorFound = false;

            if (email == "")
            {
                EmailError.Visible = true;
                errorFound = true;
            }
            else
            {
                EmailError.Visible = false;
            }
            if (password == "")
            {
                PasswordError.Visible = true;
                errorFound = true;
            }
            else
            {
                PasswordError.Visible = false;
            }

            if (!errorFound)
            {
                FastTrackEntities entities = new FastTrackEntities();
                User user = entities.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == password);
                if (user != null)
                {
                    Session["User"] = user;
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    InvalidDetails.Visible = true;
                }
            }
        }

        protected void homeLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
        protected void accountsLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Accounts.aspx");
        }
        protected void bookingsLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Bookings.aspx");
        }
        protected void registerCompanyLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterCompany.aspx");
        }
        protected void registerLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
        protected void loginLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void companiesLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Companies.aspx");
        }
        protected void logoutLink_Click(object sender, EventArgs e)
        {
            SessionHelper.Logout(Session, Response);
        }
    }
}