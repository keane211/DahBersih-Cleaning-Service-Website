using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DahBersih
{
    public partial class editServiceType : System.Web.UI.Page
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
                String id = Request.QueryString["serviceTypeID"]; // retrieve id value from URL
                int ID = Convert.ToInt32(id); // convert id into integer as received id is string

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                string query = "SELECT * FROM ServiceType WHERE ServiceTypeID=" + ID;

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
                                foreach (DataRow row in dt.Rows)
                                {
                                    // assign values in database into variables
                                    string ServiceTypeID = row["ServiceTypeID"].ToString();
                                    string ServiceTypeName = row["ServiceTypeName"].ToString();
                                    string Description = row["Description"].ToString();

                                    // display variables value in form
                                    this.IDHiddenField.Value = ServiceTypeID;
                                    this.ServiceTypeName.Text = ServiceTypeName;
                                    this.Description.Text = Description;
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                con.Open();

                string query = "UPDATE ServiceType SET ServiceTypeName=@ServiceTypeName, Description=@Description WHERE ServiceTypeID=@ServiceTypeID";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ServiceTypeID", IDHiddenField.Value);
                cmd.Parameters.AddWithValue("@ServiceTypeName", ServiceTypeName.Text);
                cmd.Parameters.AddWithValue("@Description", Description.Text);

                cmd.ExecuteNonQuery();

                ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert('Service Type Updated.');window.location.href='admin_services.aspx'", true);

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error occurred. Please try again later.')</script>");
            }
        }
    }
}