using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VariableMobileShop
{
    public partial class register : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VariableMobileShop\VariableMobileShop\App_Data\VMDB.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        protected void signup_Click(object sender, EventArgs e)
        {
            string nw = newusername.Text;

            SqlCommand cmd1 = new SqlCommand("select * from Register where Username ='" + nw + "' ", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            if (dr1.HasRows == false)
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Register(Username,Email,Password) values('" + newusername.Text + "','" + newemail.Text + "','" + newpassword.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                newusername.Text = "";
                newemail.Text = "";
                newpassword.Text = "";
                cpass.Text = "";

                Response.Write("<script>alert('Thanks For Signing up!')</script>");
                Response.Redirect("login.aspx");
            }
            else
            {
                newusername.Focus();
                usl.Enabled = true;
                usl.Visible = true;

            }
        }

        protected void login1_Click(object sender, EventArgs e)
        {

        } 
    }
}