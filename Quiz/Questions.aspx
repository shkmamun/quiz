<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Questions.aspx.cs" Inherits="Quiz.Questions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Questions</h3>
    <asp:Panel ID="pnlQuestions" runat="server">
        <fieldset>
            <legend>Search Questions</legend>
            <table>
                <tr>
                    <td>Category</td>
                    <td>
                        <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-control" DataTextField="CategoryName" DataValueField="CategoryId">
                            <asp:ListItem Text="-Select-" Value="0" />
                        </asp:DropDownList></td>
                    <td>Priority</td>
                    <td>

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
                    </td>
                    <td>Difficulty</td>
                    <td>
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
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Question</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtQuestion" CssClass="form-control" />
                    </td>
                    <td>Active</td>
                    <td>
                        <asp:DropDownList ID="ddlActive" runat="server" CssClass="form-control">
                            <asp:ListItem Text="-Select-" Value="0" />
                            <asp:ListItem Text="True" Value="True" />
                            <asp:ListItem Text="False" Value="False" />
                        </asp:DropDownList></td>

                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button runat="server" OnClick="btnSubmit_Click" Text="Search" CssClass="btn btn-default" ID="btnSubmit" /> 
                    <asp:Button runat="server"  Text="Add" CssClass="btn btn-default" ID="btnAdd" PostBackUrl="~/AddUpdateQuestion.aspx" /></td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>
    <asp:GridView ID="gvwQuestions" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" AllowPaging="true" PageSize="8" OnPageIndexChanging="gvwQuestions_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <div class="button"></div>
                    <asp:ImageButton ID="imgUpdate" runat="server" ImageUrl="~/Content/Images/edit.png" Width="20" Height="20" OnClick="imgUpdate_Click" CommandArgument='<%# Eval("QuestionId") %>' />
                    <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/Content/Images/delete.png" Width="20" Height="20" OnClick="imgDelete_Click" CommandArgument='<%# Eval("QuestionId") %>' OnClientClick="return confirm('Are you sure you want to delete this quesiton?');" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("CategoryName") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Difficulty">
                <ItemTemplate>
                    <asp:Label ID="lblDifficultyLevel" runat="server" Text='<%# Eval("DifficultyLevel") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Priority">
                <ItemTemplate>
                    <asp:Label ID="lblPriority" runat="server" Text='<%# Eval("Priority") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Question">
                <ItemTemplate>
                    <asp:Label ID="lblQuestionText" runat="server" Text='<%# Eval("QuestionText") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="OptionA">
                <ItemTemplate>
                    <asp:Label ID="lblOptionA" runat="server" Text='<%# Eval("OptionA") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="OptionB">
                <ItemTemplate>
                    <asp:Label ID="lblOptionB" runat="server" Text='<%# Eval("OptionB") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="OptionC">
                <ItemTemplate>
                    <asp:Label ID="lblOptionC" runat="server" Text='<%# Eval("OptionC") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="OptionD">
                <ItemTemplate>
                    <asp:Label ID="lblOptionD" runat="server" Text='<%# Eval("OptionD") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Answer">
                <ItemTemplate>
                    <asp:Label ID="lblAnswerText" runat="server" Text='<%# Eval("AnswerText") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Time">
                <ItemTemplate>
                    <asp:Label ID="lblTimeLimit" runat="server" Text='<%# Eval("TimeLimit") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active?">
                <ItemTemplate>
                    <asp:Label ID="lblIsActive" runat="server" Text='<%# Eval("IsActive") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
