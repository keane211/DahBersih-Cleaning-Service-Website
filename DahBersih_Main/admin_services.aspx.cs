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
    public partial class admin_services : System.Web.UI.Page
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



            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM ServiceType", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ServiceType.DataSource = dt;
                ServiceType.DataValueField = "ServiceTypeID";
                ServiceType.DataTextField = "ServiceTypeName";
                ServiceType.DataBind();
                con.Close();
            }
        }

        protected void AddServiceButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("addService.aspx");
        }

        protected void AddServiceTypeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("addServiceType.aspx");
        }

        private DataTable GetServiceData(int type)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            
            string query = "SELECT * FROM Service S INNER JOIN ServiceType T ON S.ServiceTypeID=T.ServiceTypeID WHERE S.ServiceTypeID=" + type;

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

        protected void ServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int type = Convert.ToInt32(ServiceType.SelectedItem.Value);

            DataTable serviceDT = this.GetServiceData(type);

            try
            {
                this.Description.Text = serviceDT.Rows[0]["Description"].ToString();
            }
            catch (Exception ex)
            {
                this.Description.Text = "Please add a service under this service type to view the service type information";
            }

            Description.Visible = true;
            EditServiceTypeButton.Visible = true;
            DeleteServiceTypeButton.Visible = true;

            StringBuilder htmlService = new StringBuilder();

            htmlService.Append("<table class=\"admin-item-table\">");
            htmlService.Append("<tr>");
            htmlService.Append("<th>Service ID</th>");
            htmlService.Append("<th>Size of Property</th>");
            htmlService.Append("<th>Price</th>");
            htmlService.Append("<th>Action</th>");
            htmlService.Append("</tr>");

            foreach (DataRow row in serviceDT.Rows)
            {
                htmlService.Append("<tr>");
                htmlService.Append("<td>" + row["ServiceID"] + "</td>");
                htmlService.Append("<td>" + row["Size"] + "</td>");
                htmlService.Append("<td>RM " + row["Price"] + "</td>");
                htmlService.Append("<td>" + "<a href=\"editService.aspx?serviceID=" + row["ServiceID"] + "\">Edit</a>" +
                    "<a onClick=\"return confirm('Delete Service?')\" href=\"deleteService.aspx?serviceID=" + row["ServiceID"] + "\">Delete</a>" + "</td>");
                htmlService.Append("</tr>");
            }

            htmlService.Append("</table>");

            ManageServicePlaceHolder.Controls.Add(new Literal { Text = htmlService.ToString() });
        }

        protected void EditServiceTypeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("editServiceType.aspx?serviceTypeID=" + ServiceType.SelectedItem.Value);
        }

        protected void DeleteServiceTypeButton_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "if(confirm(\"By clicking 'OK', the service type will be deleted along with the services belong to the type.\")){window.location=\"deleteServiceType.aspx?serviceTypeID=" + ServiceType.SelectedItem.Value + "\"}else{window.location=\"admin_services.aspx\"}", true);
        }
    }
}