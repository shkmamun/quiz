<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuizRun.aspx.cs" Inherits="Quiz.QuizRun" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField runat="server" ID="hdnQuestionId" />
    <asp:HiddenField runat="server" ID="hdnRefCode" />
    <asp:HiddenField runat="server" ID="hdnTimeLimit" />
    <asp:HiddenField runat="server" ID="hdnContestId" />

    <div runat="server" id="divQuiz" style="padding: 40px; z-index: 9999; display: block; border: 1px solid gray; margin-top: 50px; max-width: 600px;">

        <asp:Label runat="server" ID="lblQuestion"></asp:Label>
        <br />
        <div style="margin-left: 30px; margin-top: 10px; font-weight: normal;">
            <asp:RadioButtonList runat="server" ID="rdlQuestions" >
            </asp:RadioButtonList>
        </div>
        <br />
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="btnNext" runat="server" OnClick="Next_Click" Text="Next" CssClass="btn btn-default" />
                <asp:Button ID="btnFinish" OnClick="Finish_Click" Visible="false" runat="server" Text="Finish" CssClass="btn btn-default" />

            </div>
        </div>
    </div>
    <div runat="server" id="divFinish" style="padding: 40px; z-index: 9999; display: block; border: 1px solid gray; margin-top: 50px; max-width: 600px;" visible="false">
        <span style ="font-weight:bold;font-size:medium;color:green">Congratulation! you have successfully finished your quiz.</span>
    </div>
</asp:Content>
