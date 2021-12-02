using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.IO;

using System.Net.Mail;


namespace TMS.CA
{
    public partial class CDocuments : System.Web.UI.Page
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
                                ddlClients.DataSource = dt;
                                ddlClients.DataTextField = "Name";
                                ddlClients.DataValueField = "ClientId";
                                ddlClients.DataBind();
                                ddlClients.Items.Insert(0, "Please Select");
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
        private void Reset()
        {
            txtDocumentName.Text = string.Empty;
            ddlClients.ClearSelection();
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = Path.GetFileName(FUPDocument.PostedFile.FileName);
                FileInfo fi = new FileInfo(filename);
                string extn = fi.Extension;
                string dynamicdocumentname = DateTime.Now.ToString("hhmmssffffff") + extn;
                FUPDocument.SaveAs(Server.MapPath("CDocuments/" + dynamicdocumentname));
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO ClientDocuments (ClientId, DocumentName,DocumentUrl) VALUES (@ClientId,@DocumentName,@DocumentUrl)"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@ClientId", ddlClients.SelectedValue);
                            cmd.Parameters.AddWithValue("@DocumentName", txtDocumentName.Text);
                            cmd.Parameters.AddWithValue("@DocumentUrl", dynamicdocumentname);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                BindData();
                Reset();
            }
            catch (Exception ex)
            {
                err.LogError(ex, ErrorPath);
                Response.Redirect("Error.aspx");
            }
        }
        protected void ddlClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            try
            {
                string dbConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                string htmldata = string.Empty;
                htmldata += "<table class='table table-bordered table-striped mt-3' id='commissionTable'>" +
                    "<thead>" +
                        "<tr>" +
                           "<th>No</th>" +
                               "<th>DocumentName</th>" + "<th>Action</th>" +
                        "</tr>" +
                    "</thead><tbody>";
                using (MySqlConnection con = new MySqlConnection(dbConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("Select * from ClientDocuments where ClientId = '" + ddlClients.SelectedValue + "'"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    int index = i + 1;
                                    htmldata += "<tr>" +
                                                    "<td>" + index + "</td>" +
                                                    "<td>" + dt.Rows[i]["DocumentName"] + "</td>" +
                                                    "<td><a href='CDocuments/" + dt.Rows[i]["DocumentUrl"] + "' target='_blank' class='btn btn-link text-theme p-1'><i class='fa fa-download'></i></a></td>" +
                                    "</tr>";
                                }
                            }
                        }
                    }
                }
                htmldata += "</tbody></table>";
                htmlDiv.InnerHtml = htmldata;
            }
            catch (Exception ex)
            {
                err.LogError(ex, ErrorPath);
                Response.Redirect("Error.aspx");
            }
        }
    }
}