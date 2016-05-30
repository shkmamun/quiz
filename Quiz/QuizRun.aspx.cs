using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quiz
{
    public partial class QuizRun : System.Web.UI.Page
    {
        string refCode = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                refCode = Convert.ToString(Request.QueryString["RefCode"]);
                hdnRefCode.Value = refCode;

                if (!string.IsNullOrWhiteSpace(refCode))
                {
                    GetNextQuestion(refCode);
                }
            }
        }
        protected void Next_Click(object sender, EventArgs e)
        {
         //   refCode = Convert.ToString(Request.QueryString["RefCode"]);
            refCode = hdnRefCode.Value;

            if (!string.IsNullOrWhiteSpace(refCode))
            {
                SaveAnswer(refCode);

                GetNextQuestion(refCode);
            }
        }
        protected void Finish_Click(object sender, EventArgs e)
        {
            refCode = hdnRefCode.Value;
            if (!string.IsNullOrWhiteSpace(refCode))
            {
                SaveAnswer(refCode);
                
            }
            //Response.Redirect("/About");
            QuizCompleted();
        }
        private void SaveAnswer(string refCode)
        {
            int questionId = Convert.ToInt32(hdnQuestionId.Value);
            int TimeTaken = 0;
            int ContestId = Convert.ToInt32(hdnContestId.Value);           
        
            string answer = string.Empty;
            if (rdlQuestions.SelectedIndex > -1)
            {
                answer = rdlQuestions.SelectedValue;
            }

            Answer obj = new Answer();
            obj.RefCode = refCode;
            obj.QuestionId = questionId;
            obj.ProgrammeId = ContestId;
            obj.AnswerText = answer;
            obj.TimeTaken = TimeTaken;

            DBGateway db = new DBGateway();
            int result = db.InsertAnswer(obj);

        }
        private void GetNextQuestion(string refCode)
        {
            DBGateway db = new DBGateway();
            Question obj = db.GetNextQuestion(refCode);
            if(obj.QuestionId>0)
            {
                hdnQuestionId.Value = obj.QuestionId.ToString();
                hdnTimeLimit.Value = obj.TimeLimit.ToString();
                hdnContestId.Value = obj.ContestId.ToString();

                lblQuestion.Text = string.Format("Q-{0}) ",obj.CurrAnsNo) + obj.QuestionText;
                ListItem item1 = new ListItem(obj.OptionA,obj.OptionA);
                ListItem item2 = new ListItem(obj.OptionB, obj.OptionB);
                ListItem item3 = new ListItem(obj.OptionC, obj.OptionC);
                ListItem item4 = new ListItem(obj.OptionD, obj.OptionD);

                rdlQuestions.Items.Clear();
                rdlQuestions.Items.Add(item1);
                rdlQuestions.Items.Add(item2);
                rdlQuestions.Items.Add(item3);
                rdlQuestions.Items.Add(item4);
                rdlQuestions.DataBind();

                if(obj.CurrAnsNo == obj.NumOfQuestion)
                {
                    btnNext.Visible = false;
                    btnFinish.Visible = true;
                }

            }
            else
            {
                QuizCompleted();
            }
        }
        private void QuizCompleted()
        {
            divFinish.Visible = true;
            divQuiz.Visible = false;
        }
    }
}