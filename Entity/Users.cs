using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Users
    {

        public Int32 UserId { get; set; }

        public String LoginId { get; set; }

        public String Password { get; set; }

        public Int32 RoleId { get; set; }

        public String UserName { get; set; }

        public String EmailAddress { get; set; }

        public String Phone { get; set; }

        public DateTime CreatedDate { get; set; }        

        public String RoleName { get; set; }
 
    }
}
