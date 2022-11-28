using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class DetailsPurchases
    {
        [Key]
        [Required]
        public int DetailsId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [StringLength(40)]
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Range(1,10,ErrorMessage ="Range must be between 1 and 10")]
        public int QTY { get; set; }
        public int TotalPrice { get; set; }

    }
}
