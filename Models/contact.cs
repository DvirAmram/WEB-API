using System.ComponentModel.DataAnnotations;

namespace DivChatWEBAPI.Models
{
    public class contact
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }

        [Key]
        public string server { get; set; }

        public string last { get; set; }

        public DateTime? lastdate { get; set; }

    }
}
