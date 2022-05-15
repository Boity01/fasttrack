using FastTrackFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastTrackFront.Helpers
{
    public class MenuObject
    {
        public string ID { get; set; }
        public dynamic Object { get; set; }
    }
    public static class MenuHelper
    {
        
        public static void Menu(User user, List<MenuObject> menus)
        {
            foreach (var item in menus)
            {
                if(user == null)
                {
                    if(item.ID == "LogoutMenu")
                    {
                        item.Object.Visible = false;
                    }
                    if (item.ID == "CompaniesMenu")
                    {
                        item.Object.Visible = false;
                    }                    
                    if (item.ID == "AccountsMenu")
                    {
                        item.Object.Visible = false;
                    }                  
                    if (item.ID == "BookingsMenu")
                    {
                        item.Object.Visible = false;
                    }                    
                    if (item.ID == "RegisterCompayMenu")
                    {
                        item.Object.Visible = false;
                    }
                }
                else
                {
                    if (item.ID == "LoginMenu")
                    {
                        item.Object.Visible = false;
                    }                   
                    if (item.ID == "RegisterMenu")
                    {
                        item.Object.Visible = false;
                    }
                }
            }
        }
    }
}