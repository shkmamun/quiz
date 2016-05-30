using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Answer
    {
        public Int32 Id { get; set; }

        public Int32 ParticipantId { get; set; }

        public Int32 ProgrammeId { get; set; }

        public Int32 AnswerNo { get; set; }

        public Int32 QuestionId { get; set; }

        public String AnswerText { get; set; }

        public Boolean IsCorrect { get; set; }

        public DateTime ExamDateTime { get; set; }

        public Int32 TimeTaken { get; set; }

        public String RefCode { get; set; }
    }
}
