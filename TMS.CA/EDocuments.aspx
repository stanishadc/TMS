﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EDocuments.aspx.cs" Inherits="TMS.CA.EDocuments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h5 class="mb-0"><strong>Employees Documents</strong></h5>
    <span class="text-secondary">Dashboard <i class="fa fa-angle-right"></i>&nbsp;Employee Documents</span>
    <div class="mt-4 mb-4 p-3 bg-white border shadow-sm lh-sm">
        <div class="product-list">
            <div class="row border-bottom mb-4">
                <div class="col-sm-8 pt-2">
                    <h6 class="mb-4 bc-header">Employee Documents</h6>
                </div>
                <div class="col-sm-4 text-right pb-3">
                    <a href="EmployeesList.aspx" class="btn btn-round btn-theme"><i class="fa fa-list"></i>&nbsp;Employees List</a>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="row mt-4">
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Employee<span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlEmployees" runat="server" CssClass="custom-select" OnSelectedIndexChanged="ddlEmployees_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Select Document<span class="text-danger">*</span></label>
                                <asp:FileUpload ID="FUPDocument" runat="server" />
                            </div>
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Document Name<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtDocumentName" runat="server" CssClass="form-control form-control-primary" placeholder="DocumentName"></asp:TextBox>
                               <%-- <asp:RequiredFieldValidator ID="rfvDocumentName" runat="server" ErrorMessage="Please Select Document" ControlToValidate="txtDocumentName" InitialValue="-1" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-4 col-12">
                                <asp:Button ID="btnSubmit" runat="server" Text="Upload" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="table-responsive product-list" id="htmlDiv" runat="server">
        </div>
    </div>
</asp:Content>
