using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceVaultWeb.Models
{
    [Table("CustomerInfo")]
    public class CustomerInfo
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; } = null!;

        [StringLength(50)]
        public string? NickName { get; set; }

        [StringLength(20)]
        public string? MobileNumber { get; set; }

        [StringLength(20)]
        public string? AlternateNumber { get; set; }

        [StringLength(250)]
        public string? Address { get; set; }

        [StringLength(100)]
        public string? Relationship { get; set; }

        public string? Notes { get; set; }

        [StringLength(250)]
        public string? ImagePath { get; set; }

        [StringLength(250)]
        public string? MapLocation { get; set; }

        public DateTime? CreatedDateTime { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
