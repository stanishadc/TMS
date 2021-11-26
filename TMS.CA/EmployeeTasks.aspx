<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EmployeeTasks.aspx.cs" Inherits="TMS.CA.EmployeeTasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h5 class="mb-0"><strong>Employees Tasks</strong></h5>
    <span class="text-secondary">Dashboard <i class="fa fa-angle-right"></i>&nbsp;Employee  Tasks</span>
    <div class="mt-4 mb-4 p-3 bg-white border shadow-sm lh-sm">
        <div class="product-list">
            <div class="row border-bottom mb-4">
                <div class="col-sm-8 pt-2">
                    <h6 class="mb-4 bc-header">Employee Tasks</h6>
                </div>
                <div class="col-sm-4 text-right pb-3">
                    <a href="EmployeeTasksList.aspx" class="btn btn-round btn-theme"><i class="fa fa-list"></i>&nbsp;EmployeesTaskList</a>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="row mt-4">
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Employee<span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlEmployees" runat="server" AutoPostBack="true" CssClass="custom-select" OnSelectedIndexChanged="ddlEmployees_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Client Name<span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="true" CssClass="custom-select" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Service<span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlService" runat="server" CssClass="custom-select" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">TaskStartDate<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control form-control-primary" placeholder="StartDate" TextMode="Date"></asp:TextBox>
                                <%--  <asp:RequiredFieldValidator ID="rfvDateOfJoin" runat="server" ErrorMessage="Please Enter DateOfJoin" ControlToValidate="txtDateOfJoin" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">TaskEndDate<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control form-control-primary" placeholder="DateOfJoin" TextMode="Date"></asp:TextBox>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter DateOfJoin" ControlToValidate="txtDateOfJoin" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Task Status<span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="custom-select">
                                    <asp:ListItem Value="P">Pending</asp:ListItem>
                                    <asp:ListItem Value="C">Completed</asp:ListItem>
                                      <asp:ListItem Value="R">Requested Client</asp:ListItem>
                                </asp:DropDownList>
                                <%-- <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ErrorMessage="Please Select Status" ControlToValidate="ddlStatus" InitialValue="0" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 col-12">
                                <label for="validationCustom01">Description<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-primary" placeholder="Description"></asp:TextBox>
                                <%-- <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Please Enter Name" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-4 col-12">
                            <asp:Button ID="btnSubmit" runat="server" Text="Add" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="table-responsive product-list" id="htmlDiv" runat="server">
        </div>
    </div>
</asp:Content>
