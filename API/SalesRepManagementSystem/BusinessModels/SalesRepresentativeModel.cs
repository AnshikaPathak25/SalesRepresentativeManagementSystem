using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class SalesRepresentativeModel
    {
        public int SalesRepId { get; set; }

        [Required(ErrorMessage = "Sales Representative Name is required.")]
        public required string Name { get; set; }

        public string? Product { get; set; }
        public string? Platform { get; set; }
        public string? Region { get; set; }
        public int ProductId { get; set; }
        public int PlatformId { get; set; }
        public int RegionId { get; set; }
        public decimal SaleAmount { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public required string Email { get; set; }
        public required long PhoneNumber { get; set; }

    }
}
