using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string EmailId { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
