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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // get input value
            string userEmail = this.Email.Text;
            string userPassword = this.Password.Text;

            // store user information from database
            string email = "";
            string name = "";
            int role = 0;

            string url = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            con.Open();

            string query = "SELECT * FROM Users WHERE Email='" + userEmail + "' AND Password='" + userPassword + "'";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            cmd.ExecuteNonQuery();

            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    // assign user information from database to variable
                    email = row["Email"].ToString();
                    name = row["Name"].ToString();
                    role = Convert.ToInt32(row["Role"]);
                }

                // session created if login successful
                this.Session["email"] = email;
                this.Session["name"] = name;
                this.Session["role"] = role;

                if (role == 1) // if user is admin
                {
                    url = "adminMain.aspx";
                    ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert ('Login Successful.'); window.location.href = '" + url + "';", true);
                }
                else if (role == 0) // if user is customer
                {
                    url = "main.aspx";
                    ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert ('Login Successful.'); window.location.href = '" + url + "';", true);
                }
            }
            else
            {
                // login not successful
                Response.Write ("<script> alert ('Incorrect Email or Password') </script>");
            }

            con.Close();
        }
    }
}