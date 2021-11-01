<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="TMS.CA.EmployeeDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h5 class="mb-0"><strong>Employees Details</strong></h5>
    <span class="text-secondary">Dashboard <i class="fa fa-angle-right"></i>&nbsp;Employee Details</span>
    <div class="mt-4 mb-4 p-3 bg-white border shadow-sm lh-sm">
        <div class="product-list">
            <div class="row border-bottom mb-4">
                <div class="col-sm-8 pt-2">
                    <h6 class="mb-4 bc-header">Employee Details</h6>
                </div>
                <div class="col-sm-4 text-right pb-3">
                    <a href="EmployeeList.aspx" class="btn btn-round btn-theme"><i class="fa fa-list"></i>&nbsp;Employees List</a>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="row mt-4">
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Designation<span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlDesignations" runat="server" CssClass="custom-select" AutoPostBack="true" ValidationGroup="P" >
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Employee No<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtEmployeeNo" runat="server" CssClass="form-control form-control-primary" placeholder="EmployeeNo"></asp:TextBox>
                               <%-- <asp:RequiredFieldValidator ID="rfvEmployeeNo" runat="server" ErrorMessage="Please Enter EmployeeNo" ControlToValidate="txtEmployeeNo" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>
                             <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Full Name<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control form-control-primary" placeholder="Name"></asp:TextBox>
                               <%-- <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Please Enter Name" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                        <div class="form-group row">
                              <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Mobile<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control form-control-primary" placeholder="Mobile"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="rfvMobile" runat="server" ErrorMessage="Please Enter Mobile" ControlToValidate="txtMobile" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Date of Join<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtDateOfJoin" runat="server" CssClass="form-control form-control-primary" placeholder="DateOfJoin" TextMode="Date"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDateOfJoin" runat="server" ErrorMessage="Please Enter DateOfJoin" ControlToValidate="txtDateOfJoin" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Gender<span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="custom-select">
                                     <asp:ListItem Value="0">Gender</asp:ListItem>
                                    <asp:ListItem Value="M">Male</asp:ListItem>
                                    <asp:ListItem Value="F">Female</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-8 col-12">
                                <label for="validationCustom01">Address<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control form-control-primary" placeholder="Address"></asp:TextBox>
                            </div>
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Status<span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="custom-select">
                                    <asp:ListItem Value="Active">Active</asp:ListItem>
                                    <asp:ListItem Value="InActive">InActive</asp:ListItem>
                                </asp:DropDownList>
                                  <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ErrorMessage="Please Select Status" ControlToValidate="ddlStatus" InitialValue="0" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-4 col-12">
                                <asp:Button ID="btnSubmit" runat="server" Text="Add" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-primary" Visible="false" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-danger" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
