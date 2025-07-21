using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace MiniProjectSQLDeadLock.Models
{
    public class PurchaseRequest
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int VendorId { get; set; }

        public int Qty { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }  // e.g., Pending, Approved, Rejected

        // Navigation Properties
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("VendorId")]
        public Vendor Vendor { get; set; }
    }
}
