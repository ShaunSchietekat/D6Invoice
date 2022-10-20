using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D6Invoice.Models
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemId { get; set; }

        [ForeignKey("Invoice")]
        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; private set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; } = String.Empty;

        [Required]
        public bool Taxed { get; set; } = false;

        [Required]
        public decimal Amount { get; set; }
    }
}
