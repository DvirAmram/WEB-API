using System.ComponentModel.DataAnnotations;

namespace DivChatWEBAPI.Models
{
    public class message
    {
        [Key]
        public int id { get; set; } 
        public string content { get; set; }   

        public DateTime created { get; set; }

        public bool sent { get; set; }
    }
}
