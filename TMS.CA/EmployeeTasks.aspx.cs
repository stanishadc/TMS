using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;

namespace TMS.CA
{
    public partial class EmployeeTasks : System.Web.UI.Page
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
        protected void ddlEmployees_SelectedIndexChanged(object sender, EventArgs e)
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
                    using (MySqlCommand cmd = new MySqlCommand("Select empt.*,ser.Name as Services from EmployeeTasks AS empt INNER JOIN Services AS ser ON empt.ServiceId = ser.ServiceId where empt.EmployeeId='" + ddlEmployees.SelectedValue + "'"))
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
                                                    "<td>" + dt.Rows[i]["Services"] + "</td>";

                                    htmldata += "<td class='align-middle text-center'>" +
                                    "<a href=EmployeeTasks.aspx?Id=" + dt.Rows[i]["EmployeeTaskId"] + "&Action=Delete class='btn btn-link text-danger p-1'><i class='fas fa-trash'></i></button>" +
                                "</td>" +
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
        private void DeleteRecord(string Id)
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM EmployeeTasks WHERE EmployeeTaskId=@EmployeeTaskId"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@EmployeeTaskId", Id);
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
            try
            {
                int ClientId = Convert.ToInt32(ddlClient.SelectedValue);
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(databaseConnection))

                {
                    using (MySqlCommand cmd = new MySqlCommand("Select clis.*,ser.Name as Services from ClientServices AS clis INNER JOIN Services AS ser ON clis.ServiceId = ser.ServiceId where ClientId='" + ClientId + "'"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                ddlService.DataSource = dt;
                                ddlService.DataTextField = "Services";
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
        protected void ddlService_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ServiceId = Convert.ToInt32(ddlService.SelectedValue);
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(databaseConnection))

                {
                    using (MySqlCommand cmd = new MySqlCommand("Select emps.*,emp.Name as Employee from EmployeeServices AS emps INNER JOIN Employees AS emp ON emps.EmployeeId = emp.EmployeeId where ServiceId='" + ServiceId + "'"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                ddlEmployees.DataSource = dt;
                                ddlEmployees.DataTextField = "Employee";
                                ddlEmployees.DataValueField = "EmployeeId";
                                ddlEmployees.DataBind();
                                ddlEmployees.Items.Insert(0, "Please Select");
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
            txtDescription.Text = string.Empty;
            ddlService.ClearSelection();
            ddlClient.ClearSelection();
            ddlEmployees.ClearSelection();
            ddlStatus.SelectedValue = "Pending";
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;

                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO EmployeeTasks (ServiceId,ClientId,EmployeeId,Description,CreatedDate,UpdatedDate,Status,StartDate,EndDate) VALUES (@ServiceId,@ClientId,@EmployeeId,@Description,@CreatedDate,@UpdatedDate,@Status,@StartDate,@EndDate)"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@ServiceId", ddlService.SelectedValue);
                            cmd.Parameters.AddWithValue("@ClientId", ddlClient.SelectedValue);
                            cmd.Parameters.AddWithValue("@EmployeeId", ddlEmployees.SelectedValue);
                            cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedValue);
                            cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@StartDate", txtStartDate.Text.Trim());
                            cmd.Parameters.AddWithValue("@EndDate", txtEndDate.Text.Trim());
                            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                Reset();
            }
            catch (Exception ex)
            {
                err.LogError(ex, ErrorPath);
                Response.Redirect("Error.aspx");
            }
        }
    }
}