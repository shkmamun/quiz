using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Contest
    {
        public int ContestId { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public int NumOfQuestion { set; get; }
        public int TimeLimit { set; get; }
        public bool IsActive { set; get; }

        public int Status { set; get; }
    }
}
