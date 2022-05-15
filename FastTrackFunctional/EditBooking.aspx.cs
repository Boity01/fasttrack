using FastTrackFront.Helpers;
using FastTrackFront.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FastTrackFront
{
    public partial class EditBooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                int index = Convert.ToInt32(Request.QueryString["Id"]);
                FastTrackEntities entities = new FastTrackEntities();
                Order order = entities.Orders.FirstOrDefault(x => x.Id == index);

                CollectionDate.Value = order.CollectionDate.ToString();
                Service.Value = order.OrderTypeId.ToString();
                Estimation.Value = order.Estimation;
                Location.Value = order.Location;
            }
        }

        protected void btnUPDATE_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(Request.QueryString["Id"]);
            FastTrackEntities entities = new FastTrackEntities();
            Order order = entities.Orders.FirstOrDefault(x => x.Id == index);

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
                order.CollectionDate = Convert.ToDateTime(collection_date);
                order.Location = location;
                order.OrderTypeId = Convert.ToInt32(service);
                order.Estimation = estimation;
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
