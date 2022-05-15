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
    public partial class EditCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                int index = Convert.ToInt32(Request.QueryString["Id"]);
                FastTrackEntities entities = new FastTrackEntities();
                Company company = entities.Companies.FirstOrDefault(x => x.Id == index);
                Name.Value = company.Name;
                Description.Value = company.Description;
                RegistrationNumber.Value = company.RegistrationNumber.ToString();
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(Request.QueryString["Id"]);
            FastTrackEntities entities = new FastTrackEntities();
            Company company = entities.Companies.FirstOrDefault(x => x.Id == index);

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
                company.Name = name;
                company.Description = description;
                company.RegistrationNumber = Convert.ToInt32(registration);
                company.DateTimeCreated = DateTime.Now;
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