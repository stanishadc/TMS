using System;
using System.Collections;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;


namespace TMS.CA
{
    public partial class EmployeeProfile : System.Web.UI.Page
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
        private void BindData()
        {
            string dbConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(dbConnection))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from Employees where Employees.UserId='" + Session["UserId"] + "'"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                lblName.Text = dt.Rows[0]["Name"].ToString();
                                lbladdress.Text = dt.Rows[0]["Address"].ToString();
                                lblDateOfJoin.Text = dt.Rows[0]["DateOfJoin"].ToString();
                                lblMobile.Text = dt.Rows[0]["Mobile"].ToString();
                                BindEmpployeeTasks(dt.Rows[0]["EmployeeId"].ToString());
                            }
                        }
                    }
                }
            }
        }
        private void BindEmpployeeTasks(string EmployeeId)
        {
            try
            {
                string dbConnection = ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
                string htmldata = string.Empty;
                htmldata += "<table class='table table-bordered table-striped mt-3' id='commissionTable'>" +
                    "<thead>" +
                        "<tr>" +
                           "<th>No</th>" +
                                  "<th>Client Name </th>" +
                                 "<th>Service Name </th>" +
                                   "<th>Status</th>" +

                        "</tr>" +
                    "</thead><tbody>";
                using (MySqlConnection con = new MySqlConnection(dbConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("Select empt.*,ser.Name as Services from EmployeeTasks AS empt INNER JOIN Services AS ser ON empt.ServiceId = ser.ServiceId where empt.EmployeeId='" + EmployeeId + "'"))
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
                                                       "<td>" + dt.Rows[i]["ClientId"] + "</td>" +
                                                      "<td>" + dt.Rows[i]["Services"] + "</td>";


                                    if (dt.Rows[i]["Status"].ToString() == "P")
                                    {
                                        htmldata += "<td>Pending</td>";
                                    }
                                    else if (dt.Rows[i]["Status"].ToString() == "C")
                                    {
                                        htmldata += "<td>Completed</td>";
                                    }

                                    else
                                    {
                                        htmldata += "<td>Requested Client</td>";
                                    }

                                    htmldata += "<td class='align-middle text-center'>" +
                                          "<a href=EmployeeTasks.aspx?Id=" + dt.Rows[i]["ServiceId"] + "&Action=Edit class='btn btn-link text-theme p-1'><i class='fa fa-pencil'></i></button>" +
                                    "<a href=EmployeeTasksList.aspx?Id=" + dt.Rows[i]["EmployeeTaskId"] + "&Action=Delete class='btn btn-link text-danger p-1'><i class='fas fa-trash'></i></button>" +
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
    }
}