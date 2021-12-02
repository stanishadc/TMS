<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EmailRequest.aspx.cs" Inherits="TMS.CA.EmailRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h5 class="mb-0"><strong>Email Details</strong></h5>
    <span class="text-secondary">Home <i class="fa fa-angle-right"></i>&nbsp;Email</span>
    <div class="mt-4 mb-4 p-3 bg-white border shadow-sm lh-sm">
        <div class="product-list">
            <div class="row border-bottom mb-4">
                <div class="col-sm-8 pt-2">
                    <h6 class="mb-4 bc-header">Email Details</h6>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="form-group row">
                    <div class="col-sm-4 col-12">
                        <label for="validationCustom01">Client Name<span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="true" CssClass="custom-select">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-4 col-12">
                        <label for="recipient-name" class="col-form-label">Email:<span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Please Enter Email" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-4 col-12">
                        <label for="recipient-name" class="col-form-label">Title:<span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtsub" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-4 col-12">
                        <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:FileUpload ID="fileUploader" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-12 col-md-6 col-lg-6">
                        <asp:Label ID="Label3" runat="server" Text="Enter Message"></asp:Label>
                    </div>
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <textarea id="txtmsg" class="form-control" cols="20" rows="5" name="txtmsg"></textarea>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-4 col-12">
                        <asp:Button ID="btnEmailSend" runat="server" CssClass="btn btn-success" Text="Send Mail" OnClick="btnEmailSend_Click" />
                          <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-danger" />
                    </div>
                </div>
                <asp:Label ID="lblmsg" runat="server" Style="color: blue;" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
