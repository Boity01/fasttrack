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
    public partial class Bookings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataBind();
            }
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

            PopulateTable();
        }
        protected void GridView1_PageIndexChanging(object sender , GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            PopulateTable();
        }

        protected void Editbtn_Click(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "DeleteRow")
            {
                GridView1.PageIndex = 0;
                int index = Convert.ToInt32(e.CommandArgument);
                FastTrackEntities entities = new FastTrackEntities();
                Order order = entities.Orders.FirstOrDefault(x => x.Id == index);
                entities.Orders.Remove(order);
                entities.SaveChanges();
                PopulateTable();
            }
            if (e.CommandName == "EditRow")
            {
                Response.Redirect("EditBooking.aspx?Id=" + e.CommandArgument);
            }
        }

        public void PopulateTable()
        {
            FastTrackEntities entities = new FastTrackEntities();
            GridView1.DataSource = entities.Orders.Select(x => new
            {
                BookingID = x.Id,
                Name = x.User.FirstName + " " + x.User.LastName,
                Company = x.Company.Name,
                Location = x.Location,
                Type = x.OrderType.Description,
                Estimation = x.Estimation,
                CollectionDate = x.CollectionDate,
                DateCreated = x.DateTimeCreated
            }).ToList();
            GridView1.DataBind();
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