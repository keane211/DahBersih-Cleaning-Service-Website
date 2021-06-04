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
    public partial class editFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null || Session["role"].ToString() == "0")
            {
                Response.Redirect("main.aspx");
            }

            if (Request.QueryString["feedbackID"] == null)
            {
                Response.Redirect("admin_feedbacks.aspx");
            }

            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["feedbackID"]);
                string status = "";

                if (Request.QueryString["action"] == "Approve")
                {
                    status = "Approved";
                }
                else
                {
                    status = "Pending";
                }

                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                    con.Open();

                    string query = "UPDATE Feedback SET Status=@Status WHERE FeedbackID=@FeedbackID";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@FeedbackID", id);
                    cmd.Parameters.AddWithValue("@Status", status);

                    cmd.ExecuteNonQuery();

                    ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert('Feedback Status Updated');window.location.href='admin_feedbacks.aspx'", true);

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