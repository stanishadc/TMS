using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;

namespace TMS.CA
{
    public partial class DesignationsList : System.Web.UI.Page
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
                        if (Request.QueryString["Action"] == "Edit")
                        {
                            btnSubmit.Visible = false;
                            btnUpdate.Visible = true;
                            BindDataById(Request.QueryString["Id"]);
                        }
                        else if (Request.QueryString["Action"] == "Delete")
                        {
                            DeleteRecord(Request.QueryString["Id"]);
                        }
                        else
                        {
                            btnSubmit.Visible = true;
                            btnUpdate.Visible = false;
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
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Designations WHERE DesignationId = @DesignationId"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@DesignationId", Id);
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
        private void BindDataById(string Id)
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Designations where DesignationId=@DesignationId"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@DesignationId", Id);
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    txtName.Text = dt.Rows[0]["Name"].ToString();
                                    if (dt.Rows[0]["Status"].ToString() == "1")
                                    {
                                        ddlStatus.SelectedValue = "Active";
                                    }
                                    else
                                    {
                                        ddlStatus.SelectedValue = "InActive";
                                    }
                                    Page.ClientScript.RegisterStartupScript(GetType(), "ntmtch", "ShowDepartmentModal();", true);
                                }
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
        private void BindData()
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                string htmldata = string.Empty;
                htmldata += "<table class='table table-bordered table-striped mt-3' id='departmentsList'>" +
                    "<thead>" +
                        "<tr>" +
                            "<th>No</th>" +
                            "<th>Designation Name</th>" +
                            "<th>Status</th>" +
                            "<th class='align-middle text-center'>Action</th>" +
                        "</tr>" +
                    "</thead><tbody>";
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Designations"))
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
                                    "<a href=DesignationsList.aspx?Id=" + dt.Rows[i]["DesignationId"] + "&Action=Edit class='btn btn-link text-theme p-1'><i class='fa fa-pencil'></i></button>" +
                                    "<a href=DesignationsList.aspx?Id=" + dt.Rows[i]["DesignationId"] + "&Action=Delete class='btn btn-link text-danger p-1'><i class='fas fa-trash'></i></button>" +
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
        private void Reset()
        {
            txtName.Text = string.Empty;
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
                string Name = txtName.Text.Trim();
                bool Status = true;
                if (ddlStatus.SelectedValue == "Active")
                {
                    Status = true;
                }
                else
                {
                    Status = false;
                }
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Designations (Name,Status) VALUES (@Name, @Status)"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Status", Status);
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                string Name = txtName.Text.Trim();
                bool Status = true;
                if (ddlStatus.SelectedValue == "Active")
                {
                    Status = true;
                }
                else
                {
                    Status = false;
                }
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE Designations SET Name = @Name, Status = @Status WHERE DesignationId = @DesignationId"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@DesignationId", Request.QueryString["Id"]);
                            cmd.Parameters.AddWithValue("@Name", Name);
                            cmd.Parameters.AddWithValue("@Status", Status);

                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                BindData();
            }
            catch (Exception ex)
            {
                err.LogError(ex, ErrorPath);
                Response.Redirect("Error.aspx");
            }
        }
    }
}