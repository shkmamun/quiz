using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UserInfo
    {
        public string LoginName { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        public int RoleId { set; get; }
    }
}
