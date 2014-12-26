<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="Quiz.Confirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding: 40px; z-index: 9999; display: block; border: 1px solid gray; margin-top: 50px;">

        <div runat="server" id="divError" visible="false">
            An unexpected <span style="font-size: medium; color=red">error</span> has occured in the server. Please try again.
        </div>

        <div runat="server" id="divSucess" visible="false">
            <span style="font-size: medium; color: blue">Your email has been verified successfully!</span>
            <br />
            <br />
            You can <a href="/Login.aspx">login</a> to the system now
 

        </div>

    </div>
</asp:Content>
