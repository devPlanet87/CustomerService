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
    }
}
