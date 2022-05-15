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
    public partial class Register : System.Web.UI.Page
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


        public ActionResult Create()
        {
            return View();
        }


        private ActionResult View()
        {
            throw new NotImplementedException();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string first_name = FirstName.Value;
            string last_name = LastName.Value;
            string email = Email.Value;
            string cell_number = CellNumber.Value;
            string password = Password.Value;
            string passwordConfirm = ConfirmPassword.Value;

            bool errorFound = false;

            if (first_name == "")
            {
                FirstNameError.Visible = true;
                errorFound = true;
            }
            else
            {
                FirstNameError.Visible = false;
            }
            if (last_name == "")
            {
                LastNameError.Visible = true;
                errorFound = true;
            }
            else
            {
                LastNameError.Visible = false;
            }
            if (email == "")
            {
                EmailError.Visible = true;
                errorFound = true;
            }
            else
            {
                EmailError.Visible = false;
            }
            if (cell_number == "")
            {
                CellNumberError.Visible = true;
                errorFound = true;
            }
            else
            {
                CellNumberError.Visible = false;
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
            if (password != passwordConfirm)
            {
                ConfirmPasswordError.Visible = true;
                errorFound = true;
            }
            else
            {
                ConfirmPasswordError.Visible = false;
            }

            if (!errorFound)
            {
                FastTrackEntities entities = new FastTrackEntities();
                if(entities.Users.Where(x => x.Email.ToLower() == email.ToLower() || cell_number.ToLower() == x.CellNumber.ToLower()).ToList().Count == 0)
                {
                    entities.Users.Add(new Models.User()
                    {
                        FirstName = first_name,
                        LastName = last_name,
                        Email = email,
                        CellNumber = cell_number,
                        Password = password,
                        DateTimeCreated = DateTime.Now
                    });
                    entities.SaveChanges();

                    Session["User"] = entities.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());

                    Response.Redirect("Index.aspx");
                }
                else
                {
                    AlreadyRegisteredError.Visible = true;
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