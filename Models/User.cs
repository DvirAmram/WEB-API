using System.ComponentModel.DataAnnotations;

namespace DivChatWEBAPI.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string SrcImg { get; set; }

        [Required]
        public List<Chat> chats { get; set; }

    }
}
