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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length < 8 || args.Value.Length > 16)
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length != 5)
                args.IsValid = false;
            else
                args.IsValid = true;
        }
        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length < 10 || args.Value.Length > 11)
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                con.Open();

                string query = "SELECT * FROM Users WHERE Email='" + Email.Text + "'";

                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                cmd.ExecuteNonQuery();

                if (dt.Rows.Count > 0)
                {
                    Response.Write("<script>alert('Email already registered. Please use another email.')</script>");
                }
                else
                {
                    SqlConnection constr = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                    constr.Open();

                    string query2 = "INSERT INTO Users (Email, Name, Password, PhoneNumber, Address, City, State, Postcode, Role) VALUES (@Email, @Name, @Password, @PhoneNumber, @Address, @City, @State, @Postcode, DEFAULT)";

                    SqlCommand command = new SqlCommand(query2, constr);

                    command.Parameters.AddWithValue("@Email", Email.Text);
                    command.Parameters.AddWithValue("@Name", Name.Text);
                    command.Parameters.AddWithValue("@Password", Password.Text);
                    command.Parameters.AddWithValue("@PhoneNumber", Phone.Text);
                    command.Parameters.AddWithValue("@Address", Address.Text);
                    command.Parameters.AddWithValue("@City", City.Text);
                    command.Parameters.AddWithValue("@State", State.SelectedValue);
                    command.Parameters.AddWithValue("@Postcode", Postcode.Text);

                    command.ExecuteNonQuery();

                    Response.Redirect("login.aspx");

                    constr.Close();
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error occurred. Please try again later.')</script>");
            }
        }


    }
}