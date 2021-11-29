using System;
using System.Net.Mail;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace TMS.CA
{
    public partial class EmailRequest : System.Web.UI.Page
    {
        ErrorFile err = new ErrorFile();
        string ErrorPath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorPath = Server.MapPath("ErrorLog.txt");
            try
            {
                if (Session["UserId"] != null)
                {
                    if (!IsPostBack)
                    {
                        BindClients();
                    }
                }
                else
                {
                    Response.Redirect("~/Index.aspx");
                }
            }

            catch (Exception ex)
            {
                err.LogError(ex, ErrorPath);
                Response.Redirect("Error.aspx");
            }
        }

        private void BindClients()
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT ClientId,Name FROM Clients"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                ddlClient.DataSource = dt;
                                ddlClient.DataTextField = "Name";
                                ddlClient.DataValueField = "ClientId";
                                ddlClient.DataBind();
                                ddlClient.Items.Insert(0, "Please Select");
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
        protected void btnEmailSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(txtemail.Text);
                mail.From = new MailAddress("dccode15@gmail.com");
                mail.Subject = txtsub.Text;
                mail.Body = Request.Form["txtmsg"];
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("dccode15@gmail.com", "Test@123");
                smtp.EnableSsl = true;

                smtp.Send(mail);
                lblmsg.Text = "Mail Send .......";
            }
            catch (Exception ex)
            {
                err.LogError(ex, ErrorPath);
                Response.Redirect("Error.aspx");
            }
        }
    }
}