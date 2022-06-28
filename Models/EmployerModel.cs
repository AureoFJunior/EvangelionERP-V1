using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcsCrudV1.Models
{
    [Table(name:"tab_employer")]
    public class EmployerModel
    {
        [Key]
        public int Cod { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
    }
}
