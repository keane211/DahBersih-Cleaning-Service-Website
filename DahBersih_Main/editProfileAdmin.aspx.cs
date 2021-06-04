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
    public partial class editProfileAdmin : System.Web.UI.Page
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

                                    this.Email.Text = Email;
                                    this.Name.Text = Name;
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
                SqlConnection constr = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                constr.Open();

                string query1 = "SELECT * FROM Users WHERE Email='" + Email.Text + "'";

                SqlCommand command = new SqlCommand(query1, constr);

                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                command.ExecuteNonQuery();

                if (dt.Rows.Count > 0)
                {
                    if(OldPassword.Text == dt.Rows[0]["Password"].ToString())
                    {
                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                        con.Open();

                        string query = "UPDATE Users SET Email=@Email, Name=@Name, Password=@Password WHERE Email=@Email";

                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@Email", Email.Text);
                        cmd.Parameters.AddWithValue("@Name", Name.Text);
                        cmd.Parameters.AddWithValue("@Password", Password.Text);

                        cmd.ExecuteNonQuery();

                        this.Session["email"] = Email.Text;
                        this.Session["name"] = Name.Text;

                        ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert('Password Updated Successfully! You will be redirected to the main page.');window.location.href='adminMain.aspx'", true);

                        con.Close();
                    }
                    else
                    {
                        Response.Write("<script>alert('Incorrect Old Password. Please try again.')</script>");
                    }
                    
                }

                constr.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error occurred. Please try again later.')</script>");
            }
        }

        protected void PasswordLengthValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Page.IsValid)
            {
                if (args.Value.Length < 8 || args.Value.Length > 16)
                    args.IsValid = false;
                else
                    args.IsValid = true;
            }
        }
    }
}