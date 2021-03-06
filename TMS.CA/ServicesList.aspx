<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ServicesList.aspx.cs" Inherits="TMS.CA.ServicesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h5 class="mb-0"><strong>Services List</strong></h5>
    <span class="text-secondary">Home <i class="fa fa-angle-right"></i>&nbsp;Services List</span>
    <div class="mt-4 mb-4 p-3 bg-white border shadow-sm lh-sm">
        <div class="product-list">
            <div class="row border-bottom mb-4">
                <div class="col-sm-6 pt-2">
                    <h6 class="mb-4 bc-header">Services List</h6>
                </div>
                <div class="col-sm-6 text-right pb-6">
                    <a href="ServicesDetails.aspx?Action=Add" class="btn btn-round btn-theme"><i class="fa fa-plus"></i>Services Details</a>
                </div>
            </div>
            <div class="table-responsive product-list" id="htmlDiv" runat="server">
            </div>
        </div>
    </div>
</asp:Content>
