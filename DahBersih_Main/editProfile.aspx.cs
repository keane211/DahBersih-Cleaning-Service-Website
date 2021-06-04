using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace DahBersih
{
    public partial class editProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (Session["role"].ToString() == "1")
            {
                Response.Redirect("adminMain.aspx");
            }

            if (!IsPostBack)
            {
                StringBuilder htmlNavigation = new StringBuilder();

                htmlNavigation.Append("<li class=\"nav-item dropdown dahbersih-dropdown\">");
                htmlNavigation.Append("<a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"navbarDropdown\" role=\"button\" data-bs-toggle=\"dropdown\" aria-expanded=\"false\">" + Session["name"] + "</a>");
                htmlNavigation.Append("<ul class=\"dropdown-menu\" aria-labelledby=\"navbarDropdown\">");
                htmlNavigation.Append("<li><a class=\"dropdown-item\" href=\"editProfile.aspx\">Edit Profile</a></li>");
                htmlNavigation.Append("<li><a class=\"dropdown-item\" href=\"viewBooking.aspx\">View My Bookings</a></li>");
                htmlNavigation.Append("<li><hr class=\"dropdown-divider\"/></li>");
                htmlNavigation.Append("<li><a class=\"dropdown-item\" onclick=\"return confirm('Do you want to log out?')\" href=\"logout.aspx\">Log out</a></li></ul></li>");

                Navigation.Controls.Add(new Literal { Text = htmlNavigation.ToString() });



                string email = Session["email"].ToString();

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE  Email = '" + email + "'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);

                                foreach (DataRow row in dt.Rows)
                                {
                                    string Email = row["Email"].ToString();
                                    string Name = row["Name"].ToString();
                                    string Password = row["Password"].ToString();
                                    string PhoneNumber = row["PhoneNumber"].ToString();
                                    string Address = row["Address"].ToString();
                                    string City = row["City"].ToString();
                                    string State = row["State"].ToString();
                                    string Postcode = row["Postcode"].ToString();

                                    this.Email.Text = Email;
                                    this.Name.Text = Name;
                                    this.Password.Text = Password;
                                    this.Phone.Text = PhoneNumber;
                                    this.Address.Text = Address;
                                    this.City.Text = City;
                                    this.State.SelectedValue = State;
                                    this.Postcode.Text = Postcode;
                                }
                            }
                        }
                    }
                }

            }
        }
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                con.Open();

                string query = "UPDATE Users SET Name=@Name, Password=@Password, PhoneNumber=@PhoneNumber, Address=@Address, City=@City, State=@State, Postcode=@Postcode WHERE Email=@Email";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Email", Email.Text);
                cmd.Parameters.AddWithValue("@Name", Name.Text);
                cmd.Parameters.AddWithValue("@Password", Password.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", Phone.Text);
                cmd.Parameters.AddWithValue("@Address", Address.Text);
                cmd.Parameters.AddWithValue("@City", City.Text);
                cmd.Parameters.AddWithValue("@State", State.SelectedValue);
                cmd.Parameters.AddWithValue("@Postcode", Postcode.Text);

                cmd.ExecuteNonQuery();

                this.Session["name"] = Name.Text;

                ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert('Profile Updated Successfully!');window.location.href='editProfile.aspx'", true);

                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error occurred. Please try again later.')</script>");
            }
        }
    }
}