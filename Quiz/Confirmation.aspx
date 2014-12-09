<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="Quiz.Confirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding: 40px; z-index: 9999; display: block; border: 1px solid gray; margin-top: 50px;">

        <div runat="server" id="divError" visible="false">
            An unexpected <span style="font-size: medium; color=red">error</span> has occured in the server. Please try again.
        </div>

        <div runat="server" id="divNotStarted" visible="false">
            The quizz has not started yet. Quiz will start on
            <asp:Label runat="server" ID="lblStartDate"></asp:Label>
        </div>

        <div runat="server" id="divEnd" visible="false">
            The quizz has has been over on
            <asp:Label runat="server" ID="lblEndDate"></asp:Label>
        </div>

        <div runat="server" id="divUnIdentified" visible="false">
            Sorry! The system could not able to identified your credential.
        </div>
        <div runat="server" id="divFinish" visible="false">
            You have already <span style="font-size: medium; color=green">finished</span> the quiz.
        </div>

        <div runat="server" id="divQuiz" visible="false">
            Thank you for choosing the quiz competation.
            <br />
            You are going to answer
            <asp:Label runat="server" ID="lblNumOfQuestion"></asp:Label>
            questions.
            <br />
            Please click on start button to  <span style="font-size: medium; color=green">strart</span> the quiz. If you want to participate later please click  <span style="font-size: medium; color=red">Cancel</span> button.
            <br />
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button  ID="btnStart" runat="server" OnClick="Start_Click" Text="Start" CssClass="btn btn-default" />
                    <asp:Button ID="btnCancel" OnClick="Cancel_Click" runat="server" Text="Cancel" CssClass="btn btn-default" />

                </div>
            </div>

        </div>
        <a href="#" onclick="self.close()">Close this window  </a>
    </div>
</asp:Content>
