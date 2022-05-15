using FastTrackFront.Helpers;
using FastTrackFront.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FastTrackFront
{
    public partial class Index : System.Web.UI.Page
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

            string rootPath = Server.MapPath("~/Templates/");

            FastTrackEntities entities = new FastTrackEntities();

            List<Company> companies = entities.Companies.ToList();

            string content = "";

            foreach (Company company in companies)
            {
                content += File.ReadAllText(rootPath + "CompanyGrid.html").Replace("{{Name}}", company.Name).Replace("{{Id}}", company.Id.ToString());
            }

            companiesGrid.InnerHtml = content;
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