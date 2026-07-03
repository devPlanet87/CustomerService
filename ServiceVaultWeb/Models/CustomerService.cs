using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceVaultWeb.Models
{
    /// <summary>
    /// Represents a customer service record.
    /// </summary>
    [Table("CustomerServices")]
    public class CustomerService
    {
        [Key]
        public int CustomerServiceId { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        // Navigation property for the customer (optional)
        public CustomerInfo? Customer { get; set; }

        [Display(Name = "Mobile Number")]
        [StringLength(15)]
        public string? MobileNumber { get; set; }

        [StringLength(250)]
        public string? Location { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        // Navigation property for the product (optional)
        public Product? Product { get; set; }

        [Display(Name = "Product Details")]
        public string? ProductsDetail { get; set; }

        [Display(Name = "Image Path")]
        [StringLength(250)]
        public string? ProductOrWarrantyImage { get; set; }

        public string? Remarks { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        [StringLength(50)]
        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        [StringLength(50)]
        public string? UpdatedBy { get; set; }
    }
}
