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
    public partial class admin_customers : System.Web.UI.Page
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
                DisplayCustomer("", "All", "ASC");
            }
        }
        private DataTable GetCustomerData(string name, string state, string order)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            string stateQuery = "";

            if (state == "All")
            {
                stateQuery = " AND State in ('Kuala Lumpur', 'Selangor')";
            }
            else
            {
                stateQuery = " AND State in ('" + state + "')";
            }

            string query = "SELECT * FROM Users WHERE Role = 0 AND Name LIKE '%" + name + "%'" + stateQuery + " ORDER BY Name " + order;

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
        public void DisplayCustomer(string name, string state, string order)
        {
            DataTable customerDT = this.GetCustomerData(name, state, order);

            StringBuilder htmlCustomer = new StringBuilder();

            foreach (DataRow row in customerDT.Rows)
            {
                htmlCustomer.Append("<tr>");
                htmlCustomer.Append("<td>" + row["Name"] + "</td>");
                htmlCustomer.Append("<td>" + row["Email"] + "</td>");
                htmlCustomer.Append("<td>" + row["Password"] + "</td>");
                htmlCustomer.Append("<td>" + row["PhoneNumber"] + "</td>");
                htmlCustomer.Append("<td>" + row["Address"] + "</td>");
                htmlCustomer.Append("<td>" + row["City"] + "</td>");
                htmlCustomer.Append("<td>" + row["State"] + "</td>");
                htmlCustomer.Append("<td>" + row["Postcode"] + "</td>");
                htmlCustomer.Append("<tr>");
            }
            
            ViewCustomerPlaceHolder.Controls.Add(new Literal { Text = htmlCustomer.ToString() });
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string name = this.Name.Text;
            string state = this.State.SelectedItem.Text;
            string order = this.Order.SelectedItem.Value;

            DisplayCustomer(name, state, order);
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            this.Name.Text = "";
            this.State.SelectedItem.Value = "All";
            this.Order.SelectedItem.Value = "ASC";

            DisplayCustomer("", "All", "ASC");
        }
    }
}