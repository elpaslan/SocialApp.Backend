using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp.Backend.Webapi.Dtos
{
    public class MessageForCreateDto
    {
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string Text { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
