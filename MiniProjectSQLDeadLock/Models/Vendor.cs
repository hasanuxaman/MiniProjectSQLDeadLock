using System.ComponentModel.DataAnnotations;

namespace MiniProjectSQLDeadLock.Models
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string VendorName { get; set; }

        // Navigation Property
        public ICollection<PurchaseRequest> PurchaseRequests { get; set; }
    }
}
