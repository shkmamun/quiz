<%@ Page Title="Register" Language="C#" MasterPageFile="~/UnAuth.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Quiz.Register" %>

<%@ Register Src="~/Controls/wcDOB.ascx" TagPrefix="uc1" TagName="wcDOB" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtEmail.ClientID%>").blur(function () {
              //  checkUserName();
            });
        });
        function checkUserName() {
            var email = $("#<%=txtEmail.ClientID%>").val();
            var hasUser = false;
            $.ajax({
                type: "POST",
                async:false,
                url: "Register.aspx/IsUserNameAvailable",
                data: JSON.stringify({ userName: email }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                   
                    if (data.hasOwnProperty('d')) hasUser = data.d;
                    else hasUser = data;
                   
                },
                failure: function (response) {
                    alert(response.d);
                }
            });

            return hasUser;
        }
        function ValidateOnClient(source, arguments) {
           
            var hasUser = checkUserName();
           
            if (hasUser) {
                arguments.IsValid = false;
            }
        }
 
    </script>

    <h2><%: Title %>.</h2>

    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" ShowMessageBox="false" ShowSummary="true" />
        <asp:Panel ID="pnlConfimation" runat="server" Visible="false">

            <div class="isa_success">
                <i class="fa fa-check"></i>
                <asp:Label ID="lblMessage" runat="server" />
            </div>
        </asp:Panel>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Email <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />

                <asp:CustomValidator ID="CustomValidator1" runat="server"
                    OnServerValidate="IsUserNameValid"
                    ClientValidationFunction="ValidateOnClient"
                    ControlToValidate="txtEmail"
                    ErrorMessage="This email address already exists. Please try another one."
                     CssClass="text-danger"
                    display="Dynamic">
                </asp:CustomValidator>

                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                    CssClass="text-danger" ErrorMessage="The email field is required."
                    display="Dynamic" />

                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1"
                    runat="server" CssClass="text-danger"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="txtEmail"
                    ErrorMessage="Input valid email address!"
                     >
                </asp:RegularExpressionValidator>
            </div>
        </div>
               
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger"  ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtFirstName" CssClass="col-md-2 control-label">First Name <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName" InitialValue="*"
                    CssClass="text-danger" ErrorMessage="The first name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtLastName" CssClass="col-md-2 control-label">Last Name <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastName"
                    CssClass="text-danger" ErrorMessage="The last name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlGender" CssClass="col-md-2 control-label">Gender <span class="mendatory"> (*)</span></asp:Label>


            <div class="col-md-10">
                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlGender" InitialValue="0"
                    CssClass="text-danger" ErrorMessage="The gender field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="wcDOB" CssClass="col-md-2 control-label">Date of Birth<span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <uc1:wcDOB runat="server" ID="wcDOB" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAddress" CssClass="col-md-2 control-label">Address <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress"
                    CssClass="text-danger" ErrorMessage="The address field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtCity" CssClass="col-md-2 control-label">City <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCity" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCity"
                    CssClass="text-danger" ErrorMessage="The city field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPhone" CssClass="col-md-2 control-label">Phone <span class="mendatory"> (*)</span></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPhone"
                    CssClass="text-danger" ErrorMessage="The phone field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtProfession" CssClass="col-md-2 control-label">Profession</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtProfession" CssClass="form-control" />

            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtOrganization" CssClass="col-md-2 control-label">Organization</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtOrganization" CssClass="form-control" />

            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateParticipant_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
