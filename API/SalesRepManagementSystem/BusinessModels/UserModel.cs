using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public string FullName { get; set; }

        public string Role { get; set; }
    }
}
