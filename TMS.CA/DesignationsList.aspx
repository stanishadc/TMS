<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="DesignationsList.aspx.cs" Inherits="TMS.CA.DesignationsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <span class="text-secondary">Home <i class="fa fa-angle-right"></i>&nbsp;Designations</span>
     <div class="mt-4 mb-4 p-3 bg-white border shadow-sm lh-sm">
        <div class="product-list">
            <div class="row border-bottom mb-4">
                <div class="col-sm-8 pt-2">
                    <h6 class="mb-4 bc-header">Designation Details</h6>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="form-group row">
                         <div class="col-sm-4 col-12">
                            <label for="recipient-name" class="col-form-label">Designation Name:<span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
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
                    <h6 class="mb-4 bc-header">Designations</h6>
                </div>
            </div>
            <div class="table-responsive product-list" id="htmlDiv" runat="server">               
            </div>
        </div>
    </div>
</asp:Content>
