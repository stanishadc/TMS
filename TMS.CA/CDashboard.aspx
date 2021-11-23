<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CDashboard.aspx.cs" Inherits="TMS.CA.CDashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--dashboard widget-->
    <h5 class="mb-0"><strong>Dashboard</strong></h5>
    <div class="mt-4 mb-4 p-3 bg-white border shadow-sm lh-sm">
        <div class="product-list">
            <div class="col-sm-12">
                <div class="row mt-4">
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <div class="col-sm-8 col-12">
                                <h6 class="mb-4 bc-header">ClientsPerYear Graph</h6>
                                <%-- <div class="piechart"></div>--%>
                                <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>
                                <body>
                                    <canvas id="myChart1" style="width: 80%; max-width: 1000px"></canvas>
                                    <script>
                                        var xValues = [2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020, 2021];
                                        var yValues = [7, 8, 8, 9, 9, 9, 10, 11, 14, , 14, 15];
                                        new Chart("myChart1", {
                                            type: "line",
                                            data: {
                                                labels: xValues,
                                                datasets: [{
                                                    fill: false,
                                                    lineTension: 0,
                                                    backgroundColor: "rgba(0,0,255,1.0)",
                                                    borderColor: "rgba(0,0,255,0.1)",
                                                    data: yValues
                                                }]
                                            },
                                            options: {
                                                legend: { display: false },
                                                scales: {
                                                    yAxes: [{ ticks: { min: 6, max: 16 } }],
                                                }
                                            }
                                        });
                                    </script>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-6 col-12">
                                <h6 class="mb-4 bc-header">Bar Chart</h6>
                                <canvas id="myChart" style="width: 50%; max-width: 1000px"></canvas>
                                <script>
                                    var xValues = ["Italy", "France", "Spain", "USA"];
                                    var yValues = [55, 49, 44, 24, 15];
                                    var barColors = ["red", "green", "blue", "orange"];

                                    new Chart("myChart", {
                                        type: "bar",
                                        data: {
                                            labels: xValues,
                                            datasets: [{
                                                backgroundColor: barColors,
                                                data: yValues
                                            }]
                                        },
                                        options: {
                                            legend: { display: false },
                                            title: {
                                                display: true,
                                                text: "Clients in Countries"
                                            }
                                        }
                                    });
                                </script>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
