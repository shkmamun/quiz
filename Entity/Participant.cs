using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Participant
    {
        public Int32 ParticipantId { get; set; }

        public String RefCode { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Gender { get; set; }

        public String Address { get; set; }

        public String City { get; set; }

        public String Phone { get; set; }

        public String Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Int32 Age { get; set; }

        public String Profession { get; set; }

        public String Organization { get; set; }

        public String Password { get; set; }

        public String IPAddress { get; set; }

        public String Device { get; set; }

        public Boolean IsActive { get; set; }

        public string Platform { get; set; }


    }
}
