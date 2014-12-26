<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Quiz._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>QUIZ STATUS</h2>

        <div>
            Currently Running Quiz
            <table>
                <tr>
                    <th>Quiz Id</th>
                    <th>Quiz Type</th>
                    <th>Time Limit (min.)</th>
                    <th>Status</th>
                </tr>
                <tr>
                    <td>1</td>
                    <td>Weekly</td>
                    <td>10</td>
                    <td>Taken</td>
                </tr>
                <tr>
                    <td>1</td>
                    <td>Hourly</td>
                    <td>10</td>
                    <td>Taken</td>
                </tr>
            </table>
        </div>


    </div>

    <div class="row">
    </div>

</asp:Content>
