using System.ComponentModel.DataAnnotations;

namespace DivChatWEBAPI.Models
{
    public class Chat
    {
         [Key]
         public contact contact { get; set; }

         public List<message> messages { get; set; }
    }
}
