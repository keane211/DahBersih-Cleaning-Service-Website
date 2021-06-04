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
    public partial class deleteService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null || Session["role"].ToString() == "0")
            {
                Response.Redirect("main.aspx");
            }

            if (Request.QueryString["ServiceID"] == null)
            {
                Response.Redirect("admin_services.aspx");
            }

            if (!IsPostBack)
            {
                try
                {
                    int ServiceID = Convert.ToInt32(Request.QueryString["ServiceID"]);

                    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                    string query = "DELETE FROM Service WHERE ServiceID=" + ServiceID;

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    command.ExecuteNonQuery();

                    Response.Redirect("admin_services.aspx");

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error occurred. Please try again later.')</script>");
                }
            }
        }
    }
}