using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web;
namespace TMS.CA
{
    public partial class Index : System.Web.UI.Page
    {
        ErrorFile err = new ErrorFile();
        string ErrorPath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorPath = Server.MapPath("ErrorLog.txt");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("select usr.UserId, rol.Name from Roles as rol, Users as usr where rol.RoleId=usr.RoleId and UserName='" + txtUsername.Text.Trim() + "' and Password='" + txtPassword.Text.Trim() + "'"))
                    {
                        cmd.Connection = con;
                        con.Open();
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string userId = reader["UserId"].ToString();
                            string Name = reader["Name"].ToString();
                            if (Name == "Admin")
                            {
                                Session["UserId"] = userId;
                                Session["Role"] = Name;
                                Response.Redirect("~/CDashboard.aspx", false);
                                HttpContext.Current.ApplicationInstance.CompleteRequest();
                            }
                            else if (Name == "Employee")
                            {
                                Session["UserId"] = userId;
                                Session["Role"] = Name;
                                Response.Redirect("~/CDashboard.aspx", false);
                                HttpContext.Current.ApplicationInstance.CompleteRequest();
                            }
                            else if (Name == "Client")
                            {
                                Session["UserId"] = userId;
                                Session["Role"] = Name;
                                Response.Redirect("~/CDashboard.aspx", false);
                                HttpContext.Current.ApplicationInstance.CompleteRequest();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                err.LogError(ex, ErrorPath);
                Response.Redirect("Error.aspx");
            }
        }
    }
}