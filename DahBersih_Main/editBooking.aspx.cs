using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DahBersih
{
    public partial class editBooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null || Session["role"].ToString() == "0")
            {
                Response.Redirect("main.aspx");
            }

            if (Request.QueryString["bookingID"] == null)
            {
                Response.Redirect("admin_bookings.aspx");
            }

            if (!IsPostBack)
            {
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["bookingID"]);

                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                    con.Open();

                    string query = "UPDATE Booking SET BookingStatus=@BookingStatus WHERE BookingID=@BookingID";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@BookingID", id);
                    cmd.Parameters.AddWithValue("@BookingStatus", "Completed");

                    cmd.ExecuteNonQuery();

                    ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert('Booking Status Updated');window.location.href='admin_bookings.aspx'", true);

                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error occurred. Please try again later.')</script>");
                }
            }
        }
    }
}