<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="RolesList.aspx.cs" Inherits="TMS.CA.RolesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h5 class="mb-0"><strong>Roles</strong></h5>
    <span class="text-secondary">Home <i class="fa fa-angle-right"></i>&nbsp;Roles</span>
    <div class="mt-4 mb-4 p-3 bg-white border shadow-sm lh-sm">
        <div class="product-list">
            <div class="row border-bottom mb-4">
                <div class="col-sm-8 pt-2">
                    <h6 class="mb-4 bc-header">Roles</h6>
                </div>
                <div class="col-sm-4 text-right pb-3">
                    <button type="button" class="btn btn-theme" data-toggle="modal" data-target="#RoleModal" data-whatever="@mdo"><i class="fa fa-plus"></i>Add Role</button>
                </div>
            </div>
            <div class="table-responsive product-list" id="htmlDiv" runat="server">
            </div>
        </div>
    </div>
    <div class="modal fade" id="RoleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">New Role</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div>
                        <div class="form-group">
                            <label for="recipient-name" class="col-form-label">Name:</label>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Please Enter Name" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="message-text" class="col-form-label">Status:</label>
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="custom-select">
                                <asp:ListItem Value="Active">Active</asp:ListItem>
                                <asp:ListItem Value="InActive">InActive</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSubmit" runat="server" Text="Add" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-primary" Visible="false" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
