using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(20)]
        public string CustomerFirstName { get; set; }
        public string CustomerMiddleName { get; set; }
        [StringLength(20)]
        [Required]
        public string CustomerLastName { get; set; }
        [StringLength(50)]
        public string CustomerEmail { get; set; }
        [Required]
        [Range(9700000000,9899999999,ErrorMessage ="Invalid Phone Number")]
        public long CustomerPhone { get; set; }
        public virtual List<DetailsPurchases> DetailsPurchases { get; set; } = new List<DetailsPurchases>();
    }
}
