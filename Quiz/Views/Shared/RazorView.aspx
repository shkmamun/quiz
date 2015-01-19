<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial((string) ViewBag._ViewName); %>
</asp:Content>