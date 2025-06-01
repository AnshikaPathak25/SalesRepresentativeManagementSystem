using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient.DataClassification;

namespace DataAccessLayer.Entities
{
    [Table("SalesPerformance")]
    public class SalesPerformanceEntity
    {
        [Key]
        public int Id { get; set; }
        public int SalesRepId { get; set; }
        public int SaleAmount { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
