using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Configuration;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString);
            conn.Open();
            string checkuser = "select count(*) from [Users] where Username= '"+ TextBox3.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (temp == 1)
            {
                Response.Write("User already exists");
            }
            conn.Close();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString);
        conn.Open();
        string checkuser = "select count(*) from [Users] where Username= '" + TextBox3.Text + "'";
        SqlCommand com = new SqlCommand(checkuser, conn);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        if (temp == 1)
        {
            Response.Write("User already exists");
        }
        else
        {
            string insertquery = "insert into [Users] (Username, Password, Email) values (@username, @password, @email)";
            SqlCommand com2 = new SqlCommand(insertquery, conn);
            com2.Parameters.AddWithValue("@username", TextBox3.Text);
            com2.Parameters.AddWithValue("@password", TextBox2.Text);
            com2.Parameters.AddWithValue("@email", TextBox1.Text);
            com2.ExecuteNonQuery();
        }
        conn.Close();
    }

    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}