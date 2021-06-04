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
    public partial class addServiceType : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                
            }
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                con.Open();

                string query = "INSERT INTO ServiceType (ServiceTypeName, Description, ImageName) VALUES (@ServiceTypeName, @Description, DEFAULT)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ServiceTypeName", ServiceTypeName.Text);
                cmd.Parameters.AddWithValue("@Description", Description.Text);

                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Service Type Added Successfully')</script>");

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }

            Response.Redirect("admin_services.aspx");
        }
    }
}