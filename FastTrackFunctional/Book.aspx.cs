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
    public partial class Book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["User"];

            if (user == null)
                Response.Redirect("Register.aspx");

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
        
        protected void btnBook_Click(object sender, EventArgs e)
        {
            string collection_date = CollectionDate.Value;
            string service = Service.Value;
            string location = Location.Value;
            string estimation = Estimation.Value;

            bool errorFound = false;

            if (collection_date == "")
            {
                CollectionDateError.Visible = true;
                errorFound = true;
            }
            else
            {
                CollectionDateError.Visible = false;
            }
            if (service == "")
            {
                ServiceError.Visible = true;
                errorFound = true;
            }
            else
            {
                ServiceError.Visible = false;
            }
            if (location == "")
            {
                LocationError.Visible = true;
                errorFound = true;
            }
            else
            {
                LocationError.Visible = false;
            }
            if (estimation == "")
            {
                EstimationError.Visible = true;
                errorFound = true;
            }
            else
            {
                EstimationError.Visible = false;
            }

            if (!errorFound)
            {
                User user = (User)Session["User"];

                FastTrackEntities entities = new FastTrackEntities();
                entities.Orders.Add(new Order()
                {
                    CompanyId = Convert.ToInt32(Request.QueryString["Id"]),
                    UserId = user.Id,
                    OrderTypeId = Convert.ToInt32(service),
                    DateTimeCreated = DateTime.Now,
                    CollectionDate = Convert.ToDateTime(collection_date),
                    Location = location,
                    Estimation = estimation
                });
                entities.SaveChanges();

                Response.Redirect("Bookings.aspx");
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