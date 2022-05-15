using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastTrackFront.Helpers
{
    public class SessionHelper
    {
        public static void Logout(dynamic session, dynamic response)
        {
            session["User"] = null;

            response.Redirect("Login.aspx");
        }
    }
}