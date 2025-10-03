using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VariableMobileShop
{
    public partial class login : System.Web.UI.Page
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

        protected void login1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Register where Username ='" + username.Text + "' and Password ='" + password.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    string u = dr["Username"].ToString();
                    string p = dr["Password"].ToString();
                    if (u == username.Text && p == password.Text)
                    {
                        Session["user"] = username.Text;
                        Response.Redirect("default.aspx");

                    }
                    else
                    {
                        Response.Write("<script>alert('Username and Password  note Match')</script>");
                        username.Focus();
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Username and Password  note Match')</script>");
                username.Text = "";
                password.Text = "";
                username.Focus();
            }

        }
    }
}