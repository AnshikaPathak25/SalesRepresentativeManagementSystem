using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [Table("Product")]
    public class ProductEntity
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName = "varchar(200)")]
        public required string ProductName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public required string ProductCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
