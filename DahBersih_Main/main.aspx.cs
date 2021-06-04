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

namespace Dahbersih.sln
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                StringBuilder htmlLanding = new StringBuilder();
                StringBuilder htmlNavigation = new StringBuilder();

                if (Session.IsNewSession == true || Session["role"] == null)
                {
                    htmlLanding.Append("<a class=\"btn btn-primary dahbersih-book-btn\" href=\"login.aspx\">Book Now</a>");

                    htmlNavigation.Append("<li class=\"nav-item d-flex\"><a class=\"nav-link m-auto\" href=\"login.aspx\">Login</a></li>");
                    htmlNavigation.Append("<li class=\"nav-item d-flex\"><a class=\"nav-link m-auto\" href=\"register.aspx\">Register</a></li>");
                }
                else
                {
                    if (Session["role"].ToString() == "1")
                    {
                        Response.Redirect("adminMain.aspx");
                    }

                    htmlLanding.Append("<a class=\"btn btn-primary dahbersih-book-btn\" href=\"booking.aspx\">Book Now</a>");

                    htmlNavigation.Append("<li class=\"nav-item dropdown dahbersih-dropdown\">");
                    htmlNavigation.Append("<a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"navbarDropdown\" role=\"button\" data-bs-toggle=\"dropdown\" aria-expanded=\"false\">" + Session["name"] + "</a>");
                    htmlNavigation.Append("<ul class=\"dropdown-menu\" aria-labelledby=\"navbarDropdown\">");
                    htmlNavigation.Append("<li><a class=\"dropdown-item\" href=\"editProfile.aspx\">Edit Profile</a></li>");
                    htmlNavigation.Append("<li><a class=\"dropdown-item\" href=\"viewBooking.aspx\">View My Bookings</a></li>");
                    htmlNavigation.Append("<li><hr class=\"dropdown-divider\"/></li>");
                    htmlNavigation.Append("<li><a class=\"dropdown-item\" onclick=\"return confirm('Do you want to log out?')\" href=\"logout.aspx\">Log out</a></li></ul></li>");

                    Email.Text = Session["email"].ToString();
                    Email.Enabled = false;
                }

                LandingSession.Controls.Add(new Literal { Text = htmlLanding.ToString() });
                Navigation.Controls.Add(new Literal { Text = htmlNavigation.ToString() });

                //if (Session.IsNewSession == false && Session["role"] == null)
                //{
                //    if (Session["role"].ToString() == "1")
                //    {
                //        Response.Redirect("adminMain.aspx");
                //    }

                //    htmlLanding.Append("<a class=\"btn btn-primary dahbersih-book-btn\" href=\"booking.aspx\">Book Now</a>");

                //    htmlNavigation.Append("<li class=\"nav-item dropdown dahbersih-dropdown\">");
                //    htmlNavigation.Append("<a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"navbarDropdown\" role=\"button\" data-bs-toggle=\"dropdown\" aria-expanded=\"false\">" + Session["name"] + "</a>");
                //    htmlNavigation.Append("<ul class=\"dropdown-menu\" aria-labelledby=\"navbarDropdown\">");
                //    htmlNavigation.Append("<li><a class=\"dropdown-item\" href=\"editProfile.aspx\">Edit Profile</a></li>");
                //    htmlNavigation.Append("<li><a class=\"dropdown-item\" href=\"viewBooking.aspx\">View My Bookings</a></li>");
                //    htmlNavigation.Append("<li><hr class=\"dropdown-divider\"/></li>");
                //    htmlNavigation.Append("<li><a class=\"dropdown-item\" onclick=\"return confirm('Do you want to log out?')\" href=\"logout.aspx\">Log out</a></li></ul></li>");

                //    Email.Text = Session["email"].ToString();
                //    Email.Enabled = false;
                //}
                //else
                //{
                //    htmlLanding.Append("<a class=\"btn btn-primary dahbersih-book-btn\" href=\"login.aspx\">Book Now</a>");

                //    htmlNavigation.Append("<li class=\"nav-item d-flex\"><a class=\"nav-link m-auto\" href=\"login.aspx\">Login</a></li>");
                //    htmlNavigation.Append("<li class=\"nav-item d-flex\"><a class=\"nav-link m-auto\" href=\"register.aspx\">Register</a></li>");
                //}





                DataTable feedbackDT = this.GetFeedbackData();
                StringBuilder htmlFeedback = new StringBuilder();

                foreach (DataRow row in feedbackDT.Rows)
                {
                    htmlFeedback.Append("<div class=\"slider-content__item image-1\">");
                    htmlFeedback.Append("<div class=\"review-item\">");
                    htmlFeedback.Append("<h5 class=\"mb-3\">" + row["Name"] + "</h5>");
                    htmlFeedback.Append("<p><i>\"" + row["Comment"] + "\"</i></p>");
                    htmlFeedback.Append("</div>");
                    htmlFeedback.Append("</div>");

                }
                
                FeedbackSection.Controls.Add(new Literal { Text = htmlFeedback.ToString() });



                DataTable serviceTypeDT = this.GetServiceTypeData();
                StringBuilder htmlService = new StringBuilder();

                foreach (DataRow row in serviceTypeDT.Rows)
                {
                    htmlService.Append("<div class=\"service-item d-inline-flex mt-5 mb-5\">");
                    htmlService.Append("<img src=\"images/" + row["ImageName"] + "\" width=\"300\" height=\"360\"  alt=\"Residential Cleaning Picture\"/>");
                    htmlService.Append("<div class=\"service-item-content\">");
                    htmlService.Append("<h5><b>" + row["ServiceTypeName"] +"</b></h5>");
                    htmlService.Append("<p>" + row["Description"] + "</p>");

                    DataTable serviceDT = this.GetServiceData(Convert.ToInt32(row["ServiceTypeID"]));

                    htmlService.Append("<table class=\"service-item-table\">");
                    htmlService.Append("<tr>");
                    htmlService.Append("<th>Size</th>");
                    htmlService.Append("<th>Price</th>");

                    foreach (DataRow r in serviceDT.Rows)
                    {
                        htmlService.Append("</tr>");
                        htmlService.Append("<tr>");
                        htmlService.Append("<td>" + r["Size"] + "</td>");
                        htmlService.Append("<td>RM" + r["Price"] + "</td>");
                        htmlService.Append("</tr>");
                    }

                    htmlService.Append("</table>");
                    
                    if (Session.IsNewSession == false)
                    {
                        htmlService.Append("<a href=\"booking.aspx?serviceTypeID=" + row["ServiceTypeID"] + "\" class=\"btn btn-primary dahbersih-login-btn mt-4\">Book Now</a>");
                    }
                    else
                    {
                        htmlService.Append("<a href=\"login.aspx\" class=\"btn btn-primary dahbersih-login-btn mt-4\">Book Now</a>");
                    }

                    htmlService.Append("</div>");
                    htmlService.Append("</div>");
                    
                }
                
                ServicesSection.Controls.Add(new Literal { Text = htmlService.ToString() });
            }
        }
        private DataTable GetFeedbackData()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Feedback WHERE Status='Approved'"))
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
        private DataTable GetServiceData(int id)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Service INNER JOIN ServiceType ON Service.ServiceTypeID = ServiceType.ServiceTypeID WHERE Service.ServiceTypeID=" + id))
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
        private DataTable GetServiceTypeData()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ServiceType"))
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

        protected void FeedbackSubmitButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                con.Open();
                string query = "INSERT INTO Feedback (Name, Email, Comment, Status, EntryTime) VALUES (DEFAULT, @Email, @Comment, DEFAULT, @EntryTime)";

                if (Session["email"] != null)
                {
                    query = "INSERT INTO Feedback (Name, Email, Comment, Status, EntryTime) VALUES (@Name, @Email, @Comment, DEFAULT, @EntryTime)";
                }

                SqlCommand cmd = new SqlCommand(query, con);

                if (Session["email"] != null)
                {
                    cmd.Parameters.AddWithValue("@Name", Session["name"]);
                }

                cmd.Parameters.AddWithValue("@Email", Email.Text);
                cmd.Parameters.AddWithValue("@Comment", Comment.Text);
                cmd.Parameters.AddWithValue("@EntryTime", DateTime.Now);

                cmd.ExecuteNonQuery();
                
                ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert ('We Appretiate Your Feedback.Thank You!'); window.location.href = 'main.aspx';", true);

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error occurred. Please try again later.')</script>");
            }
        }
    }
}