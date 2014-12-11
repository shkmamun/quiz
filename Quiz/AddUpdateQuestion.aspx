<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUpdateQuestion.aspx.cs" Inherits="Quiz.AddUpdateQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h4>
            <asp:Literal ID="ltPageTitle" runat="server" Text="Create New Question."></asp:Literal>
        </h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" ShowMessageBox="false" ShowSummary="true" />
        <asp:Panel ID="pnlConfimation" runat="server" Visible="false">

            <div class="isa_success">
                <i class="fa fa-check"></i>
                <asp:Label ID="lblMessage" runat="server" />
            </div>
        </asp:Panel>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlCategories" CssClass="col-md-2 control-label">Category <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-control" DataTextField="CategoryName" DataValueField="CategoryId">
                    <asp:ListItem Text="-Select-" Value="0" />
                </asp:DropDownList>

                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCategories" InitialValue="0"
                    CssClass="text-danger" ErrorMessage="The category field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlPriority" CssClass="col-md-2 control-label">Priority <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control">
                    <asp:ListItem Text="-Select-" Value="0" />
                    <asp:ListItem Text="1" Value="1" />
                    <asp:ListItem Text="2" Value="2" />
                    <asp:ListItem Text="3" Value="3" />
                    <asp:ListItem Text="4" Value="4" />
                    <asp:ListItem Text="5" Value="5" />
                    <asp:ListItem Text="6" Value="6" />
                    <asp:ListItem Text="7" Value="7" />
                    <asp:ListItem Text="8" Value="8" />
                    <asp:ListItem Text="9" Value="9" />
                    <asp:ListItem Text="10" Value="10" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlPriority" InitialValue="0"
                    CssClass="text-danger" ErrorMessage="The Priority field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlDifficulty" CssClass="col-md-2 control-label">Difficulty  <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlDifficulty" runat="server" CssClass="form-control">
                    <asp:ListItem Text="-Select-" Value="0" />
                    <asp:ListItem Text="Level 1" Value="1" />
                    <asp:ListItem Text="Level 2" Value="2" />
                    <asp:ListItem Text="Level 3" Value="3" />
                    <asp:ListItem Text="Level 4" Value="4" />
                    <asp:ListItem Text="Level 5" Value="5" />
                    <asp:ListItem Text="Level 6" Value="6" />
                    <asp:ListItem Text="Level 7" Value="7" />
                    <asp:ListItem Text="Level 8" Value="8" />
                    <asp:ListItem Text="Level 9" Value="9" />
                    <asp:ListItem Text="Level 10" Value="10" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlDifficulty" InitialValue="0"
                    CssClass="text-danger" ErrorMessage="The Difficulty field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtQuestion" CssClass="col-md-2 control-label">Question  <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtQuestion" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtQuestion" InitialValue="*"
                    CssClass="text-danger" ErrorMessage="The Question  field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtOptionA" CssClass="col-md-2 control-label">Option A <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtOptionA" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtOptionA" InitialValue="*"
                    CssClass="text-danger" ErrorMessage="The OptionA  field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtOptionB" CssClass="col-md-2 control-label">Option B <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtOptionB" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtOptionB" InitialValue="*"
                    CssClass="text-danger" ErrorMessage="The Priority  field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtOptionC" CssClass="col-md-2 control-label">Option C  <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtOptionC" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtOptionC" InitialValue="*"
                    CssClass="text-danger" ErrorMessage="The Option C  field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtOptionD" CssClass="col-md-2 control-label">Option D  <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtOptionD" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtOptionD" InitialValue="*"
                    CssClass="text-danger" ErrorMessage="The Option D   field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAnswer" CssClass="col-md-2 control-label">Answer  <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAnswer" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAnswer" InitialValue="*"
                    CssClass="text-danger" ErrorMessage="The Answer  field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtTimeLimit" CssClass="col-md-2 control-label">TimeLimit  <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtTimeLimit" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTimeLimit" InitialValue="*"
                    CssClass="text-danger" ErrorMessage="The TimeLimit  field is required." />
                <asp:CompareValidator ID="CompareFieldValidator1" runat="server"
                    ForeColor="Red"
                    ControlToValidate="txtTimeLimit"
                    ValueToCompare="0"
                    Type="Integer"
                    Operator="GreaterThanEqual"
                    ErrorMessage="Please enter a whole number zero or greater.">
                </asp:CompareValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="chkActive" CssClass="col-md-2 control-label">Active? </asp:Label>
            <div class="col-md-10">
                <asp:CheckBox runat="server" ID="chkActive" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="btn btn-default" ID="btnSubmit" />
            </div>
        </div>
    </div>
</asp:Content>
