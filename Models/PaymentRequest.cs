using System.ComponentModel.DataAnnotations;

namespace PaymentRequestsApp.Models
{
    public class PaymentRequest
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(100)]
        public string RequesterName { get; set; } = string.Empty;

        [Required, Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required, RegularExpression("MXN|USD")]
        public string Currency { get; set; } = "MXN";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [StringLength(200)]
        public string? Description { get; set; }
    }
}
