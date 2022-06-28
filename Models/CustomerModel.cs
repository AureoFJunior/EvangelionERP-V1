using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvangelionERP.Models
{
    [Table(name:"tab_customer")]
    public class CustomerModel
    {
        [Key]
        public int Cod { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
