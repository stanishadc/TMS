using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;

namespace TMS.CA
{
    public partial class ServicesList : System.Web.UI.Page
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
                        BindData();
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
        private void DeleteRecord(string Id)
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Services WHERE ServiceId = @ServiceId"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@ServiceId", Id);
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
        private void BindData()
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                string htmldata = string.Empty;
                htmldata += "<table class='table table-bordered table-striped mt-3' id='ServicesList'>" +
                    "<thead>" +
                        "<tr>" +
                            "<th>No</th>" +
                            "<th>Category Name</th>" +
                            "<th>Service Name</th>" +
                            "<th>Status</th>" +
                            "<th class='align-middle text-center'>Action</th>" +
                        "</tr>" +
                    "</thead><tbody>";
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("Select ser.*,cat.Name as Category from Services AS ser INNER JOIN Category AS cat ON ser.CategoryId = cat.CategoryId "))
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
                                                      "<td>" + dt.Rows[i]["Category"] + "</td>"+
                                                      "<td>" + dt.Rows[i]["Name"] + "</td>";


                                    if (dt.Rows[i]["Status"].ToString() == "1")
                                    {
                                        htmldata += "<td>Active</td>";
                                    }
                                    else
                                    {
                                        htmldata += "<td>InActive</td>";
                                    }
                                    htmldata += "<td class='align-middle text-center'>" +
                                    "<a href=ServicesDetails.aspx?Id=" + dt.Rows[i]["ServiceId"] + "&Action=Edit class='btn btn-link text-theme p-1'><i class='fa fa-pencil'></i></button>" +
                                    "<a href=ServicesList.aspx?Id=" + dt.Rows[i]["ServiceId"] + "&Action=Delete class='btn btn-link text-danger p-1'><i class='fas fa-trash'></i></button>" +
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
    }
}