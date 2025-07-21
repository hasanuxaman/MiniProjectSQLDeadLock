using System.ComponentModel.DataAnnotations;

namespace MiniProjectSQLDeadLock.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? ProductName { get; set; }

        public int Quantity { get; set; }

        // Navigation Property
        public ICollection<PurchaseRequest> PurchaseRequests { get; set; }
    }
}
