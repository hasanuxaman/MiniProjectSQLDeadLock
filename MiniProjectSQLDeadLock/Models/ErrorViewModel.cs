using System.ComponentModel.DataAnnotations;

namespace MiniProjectSQLDeadLock.Models
{
    public class ErrorViewModel
    {
        [Key]
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
