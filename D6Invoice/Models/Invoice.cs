using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D6Invoice.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; private set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        
        [Required]
        [StringLength(50)]
        public string InvoiceNo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; } = DateTime.Now;

        public virtual List<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

        public string Comment { get; set; }

        public bool IsDeleted { get; set; }


    }
}
