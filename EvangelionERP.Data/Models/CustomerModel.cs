using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvangelionERP.Models
{
    [Table(name:"tab_customer")]
    public class CustomerModel
    {
        public CustomerModel() { }
        public CustomerModel(int cod, string firstName, string lastName, string mobile, string email)
        {
            Cod = cod;
            FirstName = firstName;
            LastName = lastName;
            Mobile = mobile;
            Email = email;
        }

        [Key]
        public int Cod { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
