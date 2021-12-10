using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;

namespace TMS.CA
{
    public partial class UsersList : System.Web.UI.Page
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
                        BindDesignations();
                        BindRoles();
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
        private void BindRoles()
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Roles"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                ddlRoles.DataSource = dt;
                                ddlRoles.DataTextField = "Name";
                                ddlRoles.DataValueField = "RoleId";
                                ddlRoles.DataBind();
                                ddlRoles.Items.Insert(0, "Please Select");
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
        private void BindDesignations()
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
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
                                ddlDesignations.DataSource = dt;
                                ddlDesignations.DataTextField = "Name";
                                ddlDesignations.DataValueField = "DesignationId";
                                ddlDesignations.DataBind();
                                ddlDesignations.Items.Insert(0, "Please Select");
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
        private void DeleteRecord(string Id)
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Users WHERE UserId = @UserId"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@UserId", Id);
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
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Users where UserId=@UserId"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@UserId", Id);
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    txtUserName.Text = dt.Rows[0]["UserName"].ToString();
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
                htmldata += "<table class='table table-bordered table-striped mt-3' id='usersList'>" +
                    "<thead>" +
                        "<tr>" +
                            "<th>No</th>" +
                             "<th>Designation</th>" +
                             "<th>UserName</th>" +
                            "<th>Status</th>" +

                            "<th class='align-middle text-center'>Action</th>" +
                        "</tr>" +
                    "</thead><tbody>";
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("Select usr.*,dsg.Name as Designation from Users AS usr INNER JOIN Designations AS dsg ON usr.DesignationId = dsg.DesignationId"))
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
                                                    "<td>" + index + "</td>";
                                    htmldata += "<td>" + dt.Rows[i]["Designation"] + "</td>";
                                    htmldata += "<td>" + dt.Rows[i]["UserName"] + "</td>";
                                    if (dt.Rows[i]["Status"].ToString() == "1")
                                    {
                                        htmldata += "<td>Active</td>";
                                    }
                                    else
                                    {
                                        htmldata += "<td>InActive</td>";
                                    }
                                    htmldata += "<td class='align-middle text-center'>" +
                                    "<a href=UsersList.aspx?Id=" + dt.Rows[i]["UserId"] + "&Action=Edit class='btn btn-link text-theme p-1'><i class='fa fa-pencil'></i></button>" +
                                    "<a href=UsersList.aspx?Id=" + dt.Rows[i]["UserId"] + "&Action=Delete class='btn btn-link text-danger p-1'><i class='fas fa-trash'></i></button>" +
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
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            ddlDesignations.ClearSelection();
            ddlStatus.SelectedValue = "Active";
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
                string Password = txtPassword.Text.Trim();
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
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Users (DesignationId,RoleId,UserName,Password,Status) VALUES (@DesignationId,@RoleId,@UserName,@Password,@Status)"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@DesignationId", ddlDesignations.SelectedValue);
                            cmd.Parameters.AddWithValue("@RoleId", ddlRoles.SelectedValue);
                            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                            cmd.Parameters.AddWithValue("@Status", Status);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                BindData();
                BindDesignations();
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
                string Password = txtPassword.Text.Trim();
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
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE Users SET DesignationId=@DesignationId,RoleId=@RoleId,UserName=@UserName,Password=@Password,Status=@Status WHERE UserId = @UserId"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {

                            cmd.Parameters.AddWithValue("@DesignationId", ddlDesignations.SelectedValue);
                            cmd.Parameters.AddWithValue("@RoleId", ddlRoles.SelectedValue);
                            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                            cmd.Parameters.AddWithValue("@Status", Status);
                            cmd.Parameters.AddWithValue("@UserId", Request.QueryString["Id"]);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                BindData();
                BindDesignations();
            }
            catch (Exception ex)
            {
                err.LogError(ex, ErrorPath);
                Response.Redirect("Error.aspx");
            }
        }
    }
}