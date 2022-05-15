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
    public partial class RegisterCompany : System.Web.UI.Page
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


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = Name.Value;
            string description = Description.Value;
            string registration = RegistrationNumber.Value;

            bool errorFound = false;

            if (name == "")
            {
                NameError.Visible = true;
                errorFound = true;
            }
            else
            {
                NameError.Visible = false;
            }
            if (description == "")
            {
                DescriptionError.Visible = true;
                errorFound = true;
            }
            else
            {
                DescriptionError.Visible = false;
            }
            if (registration == "")
            {
                RegistrationNumberError.Visible = true;
                errorFound = true;
            }
            else
            {
                RegistrationNumberError.Visible = false;
            }

            if (!errorFound)
            {
                FastTrackEntities entities = new FastTrackEntities();
                Company company = new Company()
                {
                    Name = name,
                    Description = description,
                    RegistrationNumber = Convert.ToInt32(registration),
                    DateTimeCreated = DateTime.Now
                };
                entities.Companies.Add(company);
                entities.SaveChanges();
                Response.Redirect("Companies.aspx");
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