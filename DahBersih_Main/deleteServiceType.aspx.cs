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
    public partial class deleteServiceType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null || Session["role"].ToString() == "0")
            {
                Response.Redirect("main.aspx");
            }

            if (Request.QueryString["serviceTypeID"] == null)
            {
                Response.Redirect("admin_services.aspx");
            }

            if (!IsPostBack)
            {
                try
                {
                    int ServiceTypeID = Convert.ToInt32(Request.QueryString["serviceTypeID"]);

                    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                    connection.Open();
                    string query = "DELETE FROM Service WHERE ServiceTypeID=" + ServiceTypeID + ";DELETE FROM ServiceType WHERE ServiceTypeID=" + ServiceTypeID;


                    SqlCommand command = new SqlCommand(query, connection);
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