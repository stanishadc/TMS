using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;

namespace TMS.CA
{
    public partial class EmployeeDetails : System.Web.UI.Page
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
                        else
                        {
                            btnSubmit.Visible = true;
                            btnUpdate.Visible = false;
                        }
                        BindDesignations();
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
        private void BindDataById(string Id)
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Employees where EmployeeId=@EmployeeId"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@EmployeeId", Request.QueryString["Id"]);
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    txtEmployeeNo.Text = dt.Rows[0]["EmployeeNo"].ToString();
                                    txtName.Text = dt.Rows[0]["Name"].ToString();
                                    ddlDesignations.SelectedValue = dt.Rows[0]["DesignationId"].ToString();
                                    txtDateOfJoin.Text = dt.Rows[0]["DateOfJoin"].ToString();
                                    txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                                    ddlGender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                                    if (dt.Rows[0]["Status"].ToString() == "1")
                                    {
                                        ddlStatus.SelectedValue = "Active";
                                    }
                                    else
                                    {
                                        ddlStatus.SelectedValue = "InActive";
                                    }
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
        private void Reset()
        {
            txtEmployeeNo.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDateOfJoin.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtAddress.Text = string.Empty;
            ddlDesignations.ClearSelection();
            ddlGender.SelectedValue = "0";
            ddlStatus.SelectedValue = "Active";
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
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
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE Employees set EmployeeNo=@EmployeeNo, Name=@Name,DesignationId=@DesignationId,DateOfJoin=@DateOfJoin,Gender=@Gender,Mobile=@Mobile,Address=@Address,Status=@Status,CreatedDate=@CreatedDate,UpdatedDate=@UpdatedDate where EmployeeId=@EmployeeId"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@EmployeeId", Request.QueryString["Id"]);
                            cmd.Parameters.AddWithValue("@EmployeeNo", txtEmployeeNo.Text.Trim());
                            cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@DesignationId", ddlDesignations.SelectedValue);
                            cmd.Parameters.AddWithValue("@DateOfJoin", txtDateOfJoin.Text);
                            cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                            cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                            cmd.Parameters.AddWithValue("@Status", Status);
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
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
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Employees (EmployeeNo,Name,DesignationId,DateOfJoin,Gender,Mobile,Address,Status,CreatedDate,UpdatedDate) VALUES (@EmployeeNo,@Name,@DesignationId,@DateOfJoin,@Gender,@Mobile,@Address,@Status,@CreatedDate,@UpdatedDate)"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@EmployeeNo", txtEmployeeNo.Text.Trim());
                            cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@DesignationId", ddlDesignations.SelectedValue);
                            cmd.Parameters.AddWithValue("@DateOfJoin", txtDateOfJoin.Text);
                            cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                            cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                            cmd.Parameters.AddWithValue("@Status", Status);
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