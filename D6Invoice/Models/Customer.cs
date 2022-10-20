using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D6Invoice.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        [StringLength(150)]
        public string CustomerName { get; set; }
        [StringLength(150)]
        public string CompanyName { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        [StringLength(150)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Email { get; set; }

        public bool IsDeleted { get; set; }


    }
}
