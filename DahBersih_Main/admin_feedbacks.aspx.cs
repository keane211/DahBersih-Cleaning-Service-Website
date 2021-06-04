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
    public partial class admin_feedbacks : System.Web.UI.Page
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



            if (!IsPostBack)
            {
                DisplayFeedback("", "All", "All", "DESC");
            }
        }
        private DataTable GetFeedbackData(string comment, string status, string type, string order)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            string statusQuery = "", typeQuery = "";

            if (status == "All")
            {
                statusQuery = " AND Status IN ('Pending', 'Approved')";
            }
            else
            {
                statusQuery = " AND Status IN ('" + status + "')";
            }

            if (type == "Anonymous")
            {
                typeQuery = " AND Name IN ('Anonymous')";
            }
            else if (type == "Customers")
            {
                typeQuery = " AND Name NOT IN ('Anonymous')";
            }

            string query = "SELECT * FROM Feedback WHERE Comment LIKE '%" + comment + "%'" + statusQuery + typeQuery + " ORDER BY EntryTime " + order;

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
        public void DisplayFeedback(string comment, string status, string type, string order)
        {
            DataTable feedbackDT = this.GetFeedbackData(comment, status, type, order);

            String action = "";

            StringBuilder htmlFeedback = new StringBuilder();

            foreach (DataRow row in feedbackDT.Rows)
            {
                htmlFeedback.Append("<tr>");
                htmlFeedback.Append("<td>" + row["Name"] + "</td>");
                htmlFeedback.Append("<td>" + row["Email"] + "</td>");
                htmlFeedback.Append("<td>" + row["Comment"] + "</td>");
                htmlFeedback.Append("<td>" + row["EntryTime"] + "</td>");
                htmlFeedback.Append("<td>" + row["Status"] + "</td>");

                if (row["Status"].ToString() == "Pending")
                {
                    action = "Approve";
                }
                else // if (row["Status"].ToString() == "Approved")
                {
                    action = "Disapprove";
                }

                htmlFeedback.Append("<td>" + "<a href=\"editFeedback.aspx?feedbackID=" + row["FeedbackID"] + "&action=" + action + "\">" + action + "</a>" + "</td>");
                htmlFeedback.Append("<tr>");
            }

            ManageFeedbackPlaceHolder.Controls.Add(new Literal { Text = htmlFeedback.ToString() });
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string comment = this.Comment.Text;
            string status = this.Status.SelectedItem.Value;
            string type = this.Type.SelectedItem.Value;
            string order = this.Order.SelectedItem.Value;

            DisplayFeedback(comment, status, type, order);
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            this.Comment.Text = "";
            this.Status.SelectedValue = "All";
            this.Type.SelectedValue = "All";
            this.Order.SelectedValue = "DESC";

            DisplayFeedback("", "All", "All", "DESC");
        }
    }
}