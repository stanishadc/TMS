<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EmployeeTasksList.aspx.cs" Inherits="TMS.CA.EmployeeTasksList" %>
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
                    <a href="EmployeeTasks.aspx" class="btn btn-round btn-theme"><i class="fa fa-list"></i>&nbsp;AddEmployeesTasks</a>
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
                        </div>
                </div>
            </div>
        </div>
        <div class="table-responsive product-list" id="htmlDiv" runat="server">
        </div>
    </div>
</asp:Content>
