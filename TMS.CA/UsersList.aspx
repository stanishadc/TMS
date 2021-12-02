<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="TMS.CA.UsersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h5 class="mb-0"><strong>Users</strong></h5>
    <span class="text-secondary">Home <i class="fa fa-angle-right"></i>&nbsp;Users</span>
    <div class="mt-4 mb-4 p-3 bg-white border shadow-sm lh-sm">
        <div class="product-list">
            <div class="row border-bottom mb-4">
                <div class="col-sm-8 pt-2">
                    <h6 class="mb-4 bc-header">User Details</h6>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="form-group row">
                    <div class="col-sm-4 col-12">
                        <label for="recipient-name" class="col-form-label">Roles:<span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlRoles" runat="server" AutoPostBack="true" CssClass="custom-select">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-4 col-12">
                        <label for="recipient-name" class="col-form-label">Designations:<span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlDesignations" runat="server" AutoPostBack="true" CssClass="custom-select" OnSelectedIndexChanged="ddlDesignations_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDesignations" runat="server" ErrorMessage="Please Select Designations " ControlToValidate="ddlDesignations" InitialValue="0" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-4 col-12">
                        <label for="recipient-name" class="col-form-label">Employees:<span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlEmployee" AutoPostBack="true" runat="server" CssClass="custom-select">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-4 col-12">
                        <label for="recipient-name" class="col-form-label">UserName:<span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtUserName" AutoPostBack="true" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="Please Enter UserName" ControlToValidate="txtUserName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-4 col-12">
                        <label for="recipient-name" class="col-form-label">Password:<span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Please Enter Password" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-4 col-12">
                        <label for="message-text" class="col-form-label">Status:<span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="custom-select">
                            <asp:ListItem Value="Active">Active</asp:ListItem>
                            <asp:ListItem Value="InActive">InActive</asp:ListItem>
                        </asp:DropDownList>
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
    <div class="mt-4 mb-4 p-3 bg-white border shadow-sm lh-sm">
        <div class="product-list">
            <div class="row border-bottom mb-4">
                <div class="col-sm-8 pt-2">
                    <h6 class="mb-4 bc-header">Users</h6>
                </div>
            </div>
            <div class="table-responsive product-list" id="htmlDiv" runat="server">
            </div>
        </div>
    </div>
</asp:Content>
