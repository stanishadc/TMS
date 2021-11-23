using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;

namespace TMS.CA
{
    public partial class ClientServices : System.Web.UI.Page
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
                        if (Request.QueryString["Action"] == "Delete")
                        {
                            DeleteRecord(Request.QueryString["Id"]);
                        }

                        BindClients();
                        BindCategory();
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
        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
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
                                 //"<th>Category </th>" +
                                 "<th>Service Name </th>" +
                        "</tr>" +
                    "</thead><tbody>";
                using (MySqlConnection con = new MySqlConnection(dbConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("Select * from ClientServices where ClientId = '" + ddlClient.SelectedValue + "'"))

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
                                    htmldata += "<tr> " +
                                                    "<td>" + index + "</td>" +
                                                    "<td>" + dt.Rows[i]["ServiceId"] + "</td>";

                                    htmldata += "<td class='align-middle text-center'>" +
                                    "<a href=ClientServices.aspx?Id=" + dt.Rows[i]["ClientServiceId"] + "&Action=Delete class='btn btn-link text-danger p-1'><i class='fas fa-trash'></i></button>" +
                                "</td></tr>";
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
        private void DeleteRecord(string Id)
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM ClientServices WHERE ClientServiceId=@ClientServiceId"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@ClientServiceId", Id);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
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
        private void BindCategory()
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Category"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                ddlCategory.DataSource = dt;
                                ddlCategory.DataTextField = "Name";
                                ddlCategory.DataValueField = "CategoryId";
                                ddlCategory.DataBind();
                                ddlCategory.Items.Insert(0, "Please Select");
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
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(databaseConnection))

                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Services Where CategoryId =" + CategoryId))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                ddlService.DataSource = dt;
                                ddlService.DataTextField = "Name";
                                ddlService.DataValueField = "ServiceId";
                                ddlService.DataBind();
                                ddlService.Items.Insert(0, "Please Select");
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;

                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO ClientServices (CategoryId,ServiceId,ClientId,Description,CreatedDate,UpdatedDate) VALUES (@CategoryId, @ServiceId,@ClientId,@Description,@CreatedDate,UpdatedDate)"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@ClientId", ddlClient.SelectedValue);
                            cmd.Parameters.AddWithValue("@CategoryId", ddlCategory.SelectedValue);
                            cmd.Parameters.AddWithValue("@ServiceId", ddlService.SelectedValue);
                            cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
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