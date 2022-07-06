using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvangelionERP.Models
{
    [Table(name: "tab_user")]
    public class UserModel
    {
        public UserModel() { }
        public UserModel(int cod, string fullName, string userName, string password, string mobile, string email, string userType, string profilePicture, string publicIdPicture, byte? ISLogged)
        {
            Cod = cod;
            FullName = fullName;
            UserName = userName;
            Password = password;
            Mobile = mobile;
            Email = email;
            UserType = userType;
            ProfilePicture = profilePicture;
            PublicIdPicture = publicIdPicture;
            isLogged = ISLogged;
        }

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
