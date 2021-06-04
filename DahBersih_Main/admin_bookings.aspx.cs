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
    public partial class admin_bookings : System.Web.UI.Page
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
                DisplayBooking("", "All", "", "PaymentDateTime", "DESC");
            }
        }

        private DataTable GetBookingData(string name, string status, string date, string type, string order)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            string statusQuery = "", dateQuery = "";

            if (date != "")
            {
                dateQuery = " AND B.ServiceDate = '" + date + "'";
            }

            if (status == "All")
            {
                statusQuery = " AND B.BookingStatus IN ('Pending', 'Completed')";
            }
            else
            {
                statusQuery = " AND B.BookingStatus IN ('" + status + "')";
            }
            
            string query = "SELECT DISTINCT *" +
                    "FROM Booking B INNER JOIN Users U ON B.Email=U.Email INNER JOIN Service S ON B.ServiceID=S.ServiceID INNER JOIN ServiceType T ON S.ServiceTypeID=T.ServiceTypeID" +
                    " WHERE U.Name LIKE '%" + name + "%'" + dateQuery + statusQuery + " ORDER BY " + type + " " + order;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
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

        public void DisplayBooking(string name, string status, string date, string type, string order)
        {
            DataTable bookingDT = this.GetBookingData(name, status, date, type, order);

            StringBuilder htmlBooking = new StringBuilder();

            foreach (DataRow row in bookingDT.Rows)
            {
                DateTime serviceDateDB = (DateTime)row["ServiceDate"];
                var serviceDate = serviceDateDB.ToString("MM/dd/yyyy");

                DateTime serviceTimeDB = DateTime.Parse(row["ServiceTime"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                string serviceTime = serviceTimeDB.ToString("HH:mm tt");

                htmlBooking.Append("<tr>");
                htmlBooking.Append("<td>" + row["BookingID"] + "</td>");
                htmlBooking.Append("<td>" + row["Name"] + "</td>");
                htmlBooking.Append("<td>" + row["Address"] + "</td>");
                htmlBooking.Append("<td>" + row["City"] + "</td>");
                htmlBooking.Append("<td>" + row["State"] + "</td>");
                htmlBooking.Append("<td>" + row["Postcode"] + "</td>");
                htmlBooking.Append("<td>" + row["PhoneNumber"] + "</td>");
                htmlBooking.Append("<td>" + row["ServiceTypeName"] + "</td>");
                htmlBooking.Append("<td>" + row["Size"] + "</td>");
                htmlBooking.Append("<td>" + serviceDate + "</td>");
                htmlBooking.Append("<td>" + serviceTime + "</td>");
                htmlBooking.Append("<td>" + row["PaymentDateTime"] + "</td>");
                htmlBooking.Append("<td>" + row["BookingStatus"] + "</td>");

                if (row["BookingStatus"].ToString() == "Pending")
                {
                    htmlBooking.Append("<td>" + "<a href=\"editBooking.aspx?bookingID=" + row["BookingID"] + "\">" + "Update to Complete</a>" + "</td>");
                }
                else
                {
                    htmlBooking.Append("<td>" + "</td>");
                }

                htmlBooking.Append("<tr>");
            }
            
            ManageBookingPlaceHolder.Controls.Add(new Literal { Text = htmlBooking.ToString() });
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string name = this.Name.Text;
            string status = this.BookingStatus.SelectedItem.Text;
            string date = this.ServiceDate.Text;
            string type = this.DateType.SelectedItem.Value;
            string order = this.Order.SelectedItem.Value;

            DisplayBooking(name, status, date, type, order);
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            this.Name.Text = "";
            this.BookingStatus.SelectedValue = "All";
            this.ServiceDate.Text = "";
            this.DateType.SelectedValue = "PaymentDateTime";
            this.Order.SelectedValue = "DESC";

            DisplayBooking("", "All", "", "PaymentDateTime", "DESC");
        }
    }
}