<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ServicesDetails.aspx.cs" Inherits="TMS.CA.ServicesDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h5 class="mb-0"><strong>Services Details</strong></h5>
    <span class="text-secondary">Dashboard <i class="fa fa-angle-right"></i>&nbsp;Services Details</span>
    <div class="mt-4 mb-4 p-3 bg-white border shadow-sm lh-sm">
        <div class="product-list">
            <div class="row border-bottom mb-4">
                <div class="col-sm-8 pt-2">
                    <h6 class="mb-4 bc-header">Services Details</h6>
                </div>
                <div class="col-sm-4 text-right pb-3">
                    <a href="ServicesList.aspx" class="btn btn-round btn-theme"><i class="fa fa-list"></i>&nbsp;Service List</a>
                </div>
            </div>


            <div class="col-sm-12">
                <div class="row mt-4">
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Category<span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="custom-select" AutoPostBack="true" ValidationGroup="P" >
                                </asp:DropDownList>
                            </div>
                             <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Service Name<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control form-control-primary" placeholder="Name"></asp:TextBox>
                               <%-- <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Please Enter Name" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>
                              <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Status<span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="custom-select">
                                    <asp:ListItem Value="Active">Active</asp:ListItem>
                                    <asp:ListItem Value="InActive">InActive</asp:ListItem>
                                </asp:DropDownList>
                                 <%-- <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ErrorMessage="Please Select Status" ControlToValidate="ddlStatus" InitialValue="0" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
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
