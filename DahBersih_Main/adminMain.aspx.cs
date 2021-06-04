using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DahBersih
{
    public partial class adminMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (Session["role"].ToString() == "0")
            {
                Response.Redirect("main.aspx");
            }

            StringBuilder htmlNavigation = new StringBuilder();

            htmlNavigation.Append("<li class=\"nav-item dropdown dahbersih-dropdown\">");
            htmlNavigation.Append("<a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"navbarDropdown\" role=\"button\" data-bs-toggle=\"dropdown\" aria-expanded=\"false\">" + Session["name"] + "</a>");
            htmlNavigation.Append("<ul class=\"dropdown-menu\" aria-labelledby=\"navbarDropdown\">");
            htmlNavigation.Append("<li><a class=\"dropdown-item\" href=\"editProfileAdmin.aspx\">Change Password</a></li>");
            htmlNavigation.Append("<li><hr class=\"dropdown-divider\"/></li>");
            htmlNavigation.Append("<li><a class=\"dropdown-item\" onclick=\"return confirm('Do you want to log out?')\" href=\"logout.aspx\">Log out</a></li></ul></li>");

            Navigation.Controls.Add(new Literal { Text = htmlNavigation.ToString() });

            if (!this.IsPostBack)
            {
                
            }
        }
    }
}