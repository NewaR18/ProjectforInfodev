using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        [StringLength(50)]
        [Required]
        public string ProductCategory { get; set; }
        [Required]
        public int ProductWeight { get; set; }
        [Required]
        public DateTime ProductManufacturedDate { get; set; }
        [Required]
        public DateTime ProductExpiryDate { get; set; }
        [Required]
        public int ProductPrice { get; set; }
    }
}
