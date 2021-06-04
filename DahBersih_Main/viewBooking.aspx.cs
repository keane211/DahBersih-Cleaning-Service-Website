using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DahBersih
{
    public partial class viewBooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("login.aspx");
            }

            StringBuilder htmlNavigation = new StringBuilder();

            htmlNavigation.Append("<li class=\"nav-item dropdown dahbersih-dropdown\">");
            htmlNavigation.Append("<a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"navbarDropdown\" role=\"button\" data-bs-toggle=\"dropdown\" aria-expanded=\"false\">" + Session["name"] + "</a>");
            htmlNavigation.Append("<ul class=\"dropdown-menu\" aria-labelledby=\"navbarDropdown\">");
            htmlNavigation.Append("<li><a class=\"dropdown-item\" href=\"editProfile.aspx\">Edit Profile</a></li>");
            htmlNavigation.Append("<li><a class=\"dropdown-item\" href=\"viewBooking.aspx\">View My Bookings</a></li>");
            htmlNavigation.Append("<li><hr class=\"dropdown-divider\"/></li>");
            htmlNavigation.Append("<li><a class=\"dropdown-item\" onclick=\"return confirm('Do you want to log out?')\" href=\"logout.aspx\">Log out</a></li></ul></li>");

            Navigation.Controls.Add(new Literal { Text = htmlNavigation.ToString() });

            if (!IsPostBack)
            {
                DataTable dataTable = this.GetBookingData();

                StringBuilder htmlString = new StringBuilder();

                foreach (DataRow row in dataTable.Rows)
                {
                    DateTime serviceDateDB = (DateTime)row["ServiceDate"];
                    var serviceDate = serviceDateDB.ToString("dd/MM/yyyy");

                    DateTime serviceTimeDB = DateTime.Parse(row["ServiceTime"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                    string serviceTime = serviceTimeDB.ToString("HH:mm tt");

                    htmlString.Append("<div class=\"box\">");
                    htmlString.Append("<h3>" + row["ServiceTypeName"] + " " + "(" + row["BookingID"] + ")" + "</h3>");
                    htmlString.Append("Size:<br />" + row["Size"] + "<br /><br />");
                    htmlString.Append("Service Date and Time:<br />" + serviceDate + " " + "-" + " " + serviceTime + "<br /><br />");
                    htmlString.Append("Address:<br />" + row["Address"] + ", " + row["City"] + ", " + row["State"] + ", " + row["Postcode"] + "<br /><br />");
                    htmlString.Append("Phone Number:<br />" + row["PhoneNumber"] + "<br /><br />");
                    htmlString.Append("Payment Date and Time:<br />" + row["PaymentDateTime"] + "<br /><br />");
                    htmlString.Append("Booking Status:<br />" + row["BookingStatus"] + "<br /><br />");

                    htmlString.Append("</div>");
                }
                
                BookingPlaceHolder.Controls.Add(new Literal { Text = htmlString.ToString() });
            }
        }

        private DataTable GetBookingData()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT * " +
                    "FROM Booking B INNER JOIN Users U ON B.Email=U.Email INNER JOIN Service S ON B.ServiceID=S.ServiceID INNER JOIN ServiceType T ON S.ServiceTypeID=T.ServiceTypeID" +
                    " WHERE B.Email='" + Session["email"] + "' ORDER BY BookingID DESC"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
    }
}