using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dahbersih.sln
{
    public partial class confirmBooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null || Session["role"].ToString() == "1")
            {
                Response.Redirect("adminMain.aspx");
            }

            if (Session["serviceType"] == null)
            {
                Response.Redirect("booking.aspx");
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
                ServiceType.Text = Session["serviceType"].ToString();
                Size.Text = Session["size"].ToString();
                ServiceDate.Text = Session["serviceDate"].ToString();
                ServiceTime.Text = Session["serviceTime"].ToString();
                Address.Text = Session["address"].ToString();
                City.Text = Session["city"].ToString();
                State.Text = Session["state"].ToString();
                Postcode.Text = Session["postcode"].ToString();
                PhoneNumber.Text = Session["phone"].ToString();
                Price.Text = "RM " + Session["price"].ToString();
            }
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                string query = "INSERT INTO Booking (Email, ServiceID, ServiceDate, ServiceTime, BookingStatus, PaymentDateTime) VALUES (@Email, @ServiceID, @ServiceDate, @ServiceTime, DEFAULT, @PaymentDateTime)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Email", Session["email"].ToString());
                cmd.Parameters.AddWithValue("@ServiceID", Convert.ToInt32(Session["serviceID"]));
                cmd.Parameters.AddWithValue("@ServiceDate", DateTime.Parse(Session["serviceDate"].ToString()).Date);
                cmd.Parameters.AddWithValue("@ServiceTime", DateTime.ParseExact(Session["serviceTime"].ToString(), "HH:mm", CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@PaymentDateTime", DateTime.Now);

                cmd.ExecuteNonQuery();

                ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert('Booking Confirmed and Payment Done.');window.location.href='viewBooking.aspx'", true);

                con.Close();

                this.Session.Remove("serviceTypeID");
                this.Session.Remove("serviceType");
                this.Session.Remove("serviceID");
                this.Session.Remove("size");
                this.Session.Remove("serviceDate");
                this.Session.Remove("serviceTime");
                this.Session.Remove("address");
                this.Session.Remove("city");
                this.Session.Remove("state");
                this.Session.Remove("postcode");
                this.Session.Remove("phone");
                this.Session.Remove("price");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error occurred. Please try again later.')</script>");
            }
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("booking.aspx");
        }
    }
}