using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [Table("SalesRepresentative")]
    public class SalesRepresentativeEntity
    {
        [Key]
        public int SalesRepId { get; set; }
        
        [Column(TypeName = "varchar(200)")]
        public required string Name { get; set; }

        [Column(TypeName = "varchar(200)")]
        public required string Email { get; set; }
        
        public required long PhoneNumber { get; set; }

        [ForeignKey("Region")]
        public int RegionId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("Platform")]
        public int PlatformId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        //Navigation Property 
        public ProductEntity Product { get; set; }
        public RegionEntity Region { get; set; }
        public PlatformEntity Platform { get; set; }
    }
}
