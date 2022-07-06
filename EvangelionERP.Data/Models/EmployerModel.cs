using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvangelionERP.Models
{
    [Table(name:"tab_employer")]
    public class EmployerModel
    {
        public EmployerModel() { }
        public EmployerModel(int cod, string firstName, string lastName, string mobile, int salary, string email)
        {
            Cod = cod;
            FirstName = firstName;
            LastName = lastName;
            Mobile = mobile;
            Salary = salary;
            Email = email;
        }

        [Key]
        public int Cod { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
    }
}
