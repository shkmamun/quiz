using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public  class Question
    {
        public Int32 QuestionId { get; set; }

        public Int32 CategoryId { get; set; }

        public Int32 Priority { get; set; }

        public Int32 DifficultyLevel { get; set; }

        public String QuestionText { get; set; }

        public String OptionA { get; set; }

        public String OptionB { get; set; }

        public String OptionC { get; set; }

        public String OptionD { get; set; }

        public String AnswerText { get; set; }

        public Int32 TimeLimit { get; set; }

        public Boolean IsActive { get; set; }

        public string CategoryName { get; set; }

        public int CurrAnsNo { get; set; }

        public int NumOfQuestion { get; set; }

        public int ContestId { get; set; }
    }
}
