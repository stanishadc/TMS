using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;

namespace TMS.CA
{
    public partial class ClientDetails : System.Web.UI.Page
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
        private void BindDataById(string Id)
        {
            try
            {
                string databaseConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(databaseConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Clients where ClientId=@ClientId"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@ClientId", Request.QueryString["Id"]);
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    txtName.Text = dt.Rows[0]["Name"].ToString();
                                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                                    txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
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
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtAddress.Text = string.Empty;
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
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE Clients set Name=@Name,Mobile=@Mobile,Email=@Email,Status=@Status,Address=@Address,CreatedDate=@CreatedDate,UpdatedDate=@UpdatedDate where ClientId=@ClientId"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@ClientId", Request.QueryString["Id"]);
                            cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
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
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Clients (Name,Mobile,Email,Address,Status,CreatedDate,UpdatedDate) VALUES (@Name,@Mobile,@Email,@Address,@Status,@CreatedDate,@UpdatedDate)"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {

                            cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
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