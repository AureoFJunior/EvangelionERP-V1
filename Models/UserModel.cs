using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcsCrudV1.Models
{
    [Table(name: "tab_user")]
    public class UserModel
    {
        [Key]
        public int Cod { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public string ProfilePicture { get; set; }
        public string PublicIdPicture { get; set; }
        public byte? isLogged { get; set; }
    }
}
