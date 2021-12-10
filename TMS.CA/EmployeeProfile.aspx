<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EmployeeProfile.aspx.cs" Inherits="TMS.CA.EmployeeProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h5 class="mb-0"><strong>Employee Profile</strong></h5>
    <span class="text-secondary">Dashboard <i class="fa fa-angle-right"></i>&nbsp;Employee Profile</span>
    <div class="mt-4 mb-4 p-3 bg-white border shadow-sm lh-sm">
        <div class="product-list">
            <div class="row border-bottom mb-4">
                <div class="col-sm-8 pt-2">
                  <%--  <h6 class="mb-4 bc-header"><strong>lb1.Text</strong></h6>--%>
                      <asp:Label ID="lb1Text" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="form-group row">
                    <div class="col-sm-4 col-12">
                        <label for="validationCustom01">Name : </label>
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-4 col-12">
                        <label for="validationCustom01">Address : </label>
                        <asp:Label ID="lbladdress" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-4 col-12">
                        <label for="validationCustom01">DateOfJoin : </label>
                        <asp:Label ID="lblDateOfJoin" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-4 col-12">
                        <label for="validationCustom01">Mobile : </label>
                        <asp:Label ID="lblMobile" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <h6>Tasks Assigned for you</h6>
    <div class="table-responsive product-list" id="htmlDiv" runat="server">
    </div>
</asp:Content>
