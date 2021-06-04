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
    public partial class editService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null || Session["role"].ToString() == "0")
            {
                Response.Redirect("main.aspx");
            }

            if (Request.QueryString["serviceID"] == null)
            {
                Response.Redirect("admin_services.aspx");
            }

            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["serviceID"]);

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand command = new SqlCommand("SELECT * FROM ServiceType", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                ServiceType.DataSource = dataTable;
                ServiceType.DataBind();


                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                string query = "SELECT * FROM Service WHERE ServiceID=" + id;

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
                                    string ServiceID = row["ServiceID"].ToString();
                                    string ServiceTypeID = row["ServiceTypeID"].ToString();

                                    string size = row["Size"].ToString().Replace(" sq.ft", ""); // size = "From 'minSize' to 'maxSize'"
                                    int between = size.IndexOf(" to "); // get starting index number of the string
                                    string MinSize = size.Substring(5, between - 5); // including index 5, get 3 character
                                    string MaxSize = size.Substring(between + 4); // get all character starting from index 12

                                    string Price = row["Price"].ToString();

                                    // display variables value in form
                                    this.IDHiddenField.Value = ServiceID;
                                    this.ServiceType.SelectedValue = ServiceTypeID;
                                    this.MinSize.Text = MinSize;
                                    this.MaxSize.Text = MaxSize;
                                    this.Price.Text = Price;
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

                string query = "UPDATE Service SET ServiceTypeID=@ServiceTypeID, Size=@Size, Price=@Price WHERE ServiceID=@ServiceID";

                string size = "From " + MinSize.Text + " sq.ft to " + MaxSize.Text + " sq.ft";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ServiceID", IDHiddenField.Value);
                cmd.Parameters.AddWithValue("@ServiceTypeID", ServiceType.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Size", size);
                cmd.Parameters.AddWithValue("@Price", Price.Text);

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