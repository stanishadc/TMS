<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ClientServices.aspx.cs" Inherits="TMS.CA.ClientServices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h5 class="mb-0"><strong>Client Services</strong></h5>
    <span class="text-secondary">Dashboard <i class="fa fa-angle-right"></i>&nbsp;Client Services</span>
    <div class="mt-4 mb-4 p-3 bg-white border shadow-sm lh-sm">
        <div class="product-list">
            <div class="row border-bottom mb-4">
                <div class="col-sm-8 pt-2">
                    <h6 class="mb-4 bc-header">Client Services</h6>
                </div>
                <div class="col-sm-4 text-right pb-3">
                    <a href="ClientServicesList.aspx" class="btn btn-round btn-theme"><i class="fa fa-list"></i>&nbsp;ClientServicesList</a>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="row mt-4">
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Client Name<span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="true" CssClass="custom-select" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Category<span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" CssClass="custom-select" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                </asp:DropDownList>

                            </div>
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Service<span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlService" runat="server" CssClass="custom-select" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-4 col-12">
                                <label for="validationCustom01">Description<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-primary" placeholder="Description"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-4 col-12">
                                <asp:Button ID="btnSubmit" runat="server" Text="Add" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
                                  <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-danger" />
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
