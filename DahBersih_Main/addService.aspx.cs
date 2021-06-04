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
    public partial class addService : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM ServiceType", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ServiceType.DataSource = dt;
                ServiceType.DataBind();
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                con.Open();

                string query = "INSERT INTO Service (ServiceTypeID, Size, Price) VALUES (@ServiceTypeID, @Size, @Price)";

                string size = "From " + MinSize.Text + " sq.ft to " + MaxSize.Text + " sq.ft";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ServiceTypeID", Convert.ToInt32(ServiceType.SelectedItem.Value));
                cmd.Parameters.AddWithValue("@Size", size);
                cmd.Parameters.AddWithValue("@Price", Convert.ToInt32(Price.Text));

                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Service Added Successfully !')</script>");

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