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

namespace Dahbersih.sln
{
    public partial class booking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (Session["role"].ToString() == "1")
            {
                Response.Redirect("adminMain.aspx");
            }

            StringBuilder htmlNavigation = new StringBuilder();

            htmlNavigation.Append("<li class=\"nav-item dropdown dahbersih-dropdown\">");
            htmlNavigation.Append("<a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"navbarDropdown\" role=\"button\" data-bs-toggle=\"dropdown\" aria-expanded=\"false\">" + Session["name"] + "</a>");
            htmlNavigation.Append("<ul class=\"dropdown-menu\" aria-labelledby=\"navbarDropdown\">");
            htmlNavigation.Append("<li><a class=\"dropdown-item\" href=\"editProfile.aspx\">Edit Profile</a></li>");
            htmlNavigation.Append("<li><a class=\"dropdown-item\" href=\"viewBooking.aspx\">View My Bookings</a></li>");
            htmlNavigation.Append("<li><hr class=\"dropdown-divider\"/></li>");
            htmlNavigation.Append("<li><a class=\"dropdown-item\" onclick=\"return confirm('Do you want to log out?')\" href=\"logout.aspx\">Log out</a></li></ul></li>");

            Navigation.Controls.Add(new Literal { Text = htmlNavigation.ToString() });

            if (!Page.IsPostBack)
            {
                DateTime minimumDate = DateTime.Now.AddDays(3);
                RangeValidatorDate.MinimumValue = minimumDate.ToString("dd/MM/yyyy");
                DateTime submitDate = DateTime.Now.AddDays(30);
                RangeValidatorDate.MaximumValue = submitDate.ToString("dd/MM/yyyy");

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM ServiceType", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ServiceType.DataSource = dt;
                ServiceType.DataTextField = "ServiceTypeName";
                ServiceType.DataValueField = "ServiceTypeID";
                ServiceType.DataBind();

                if (Request.QueryString["serviceTypeID"] != null)
                {
                    this.ServiceType.SelectedValue = Request.QueryString["serviceTypeID"];
                    ServiceType_SelectedIndexChanged(sender, e);
                }

                if (Session["serviceDate"] == null && Session["serviceTime"] == null && Session["price"] == null)
                {
                    string email = Session["email"].ToString();

                    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                    using (SqlConnection connection = new SqlConnection(constr))
                    {
                        using (SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE  Email = '" + email + "'"))
                        {
                            using (SqlDataAdapter sdaSession = new SqlDataAdapter())
                            {
                                command.Connection = connection;
                                sdaSession.SelectCommand = command;
                                using (DataTable dtSession = new DataTable())
                                {
                                    sdaSession.Fill(dtSession);

                                    foreach (DataRow row in dtSession.Rows)
                                    {
                                        string PhoneNumber = row["PhoneNumber"].ToString();
                                        string Address = row["Address"].ToString();
                                        string City = row["City"].ToString();
                                        string State = row["State"].ToString();
                                        string Postcode = row["Postcode"].ToString();

                                        this.PhoneNumber.Text = PhoneNumber;
                                        this.Address.Text = Address;
                                        this.City.Text = City;
                                        this.State.Text = State;
                                        this.Postcode.Text = Postcode;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    ServiceType.SelectedValue = this.Session["serviceTypeID"].ToString();
                    ServiceType_SelectedIndexChanged(sender, e);
                    Size.SelectedValue = this.Session["serviceID"].ToString();
                    ServiceDate.Text = this.Session["serviceDate"].ToString();
                    ServiceTime.Text = this.Session["serviceTime"].ToString();
                    Address.Text = Session["address"].ToString();
                    City.Text = Session["city"].ToString();
                    State.Text = Session["state"].ToString();
                    Postcode.Text = Session["postcode"].ToString();
                    PhoneNumber.Text = Session["phone"].ToString();
                    Price.Text = this.Session["price"].ToString();
                }
            }
            

        }
        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            this.Session["serviceTypeID"] = ServiceType.SelectedValue;
            this.Session["serviceType"] = ServiceType.SelectedItem.Text;
            this.Session["serviceID"] = Size.SelectedValue;
            this.Session["size"] = Size.SelectedItem.Text;
            this.Session["serviceDate"] = ServiceDate.Text;
            this.Session["serviceTime"] = ServiceTime.Text;
            this.Session["address"] = Address.Text;
            this.Session["city"] = City.Text;
            this.Session["state"] = State.Text;
            this.Session["postcode"] = Postcode.Text;
            this.Session["phone"] = PhoneNumber.Text;
            this.Session["price"] = Price.Text;

            Response.Redirect("confirmBooking.aspx");
        }
        protected void ServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Price.Text = "-";
            Size.Items.Clear();
            Size.Items.Add(new ListItem("- Please Select Size of Property -", "0"));
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Service INNER JOIN ServiceType ON Service.ServiceTypeID=ServiceType.ServiceTypeID WHERE Service.ServiceTypeID=" + ServiceType.SelectedValue, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Size.DataSource = dt;
            Size.DataTextField = "Size";
            Size.DataValueField = "ServiceID";
            Size.DataBind();
        }
        protected void Size_SelectedIndexChanged(object sender, EventArgs e)
        {
            Price.Text = "";

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Service WHERE ServiceID=" + Size.SelectedItem.Value, con))
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
                                this.Price.Text = row["Price"].ToString();
                            }
                        }
                    }
                }
            }
        }
    }
}