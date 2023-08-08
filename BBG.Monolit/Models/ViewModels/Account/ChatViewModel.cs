using BBG.Monolit.Models.Entities.Users;
using System.Collections.Generic;

namespace BBG.Monolit.Models.ViewModels.Account
{
    public class ChatViewModel
    {
        public User You { get; set; }
        public User Recipient { get; set; }
        public List<Message> History { get; set; }
        public MessageViewModel NewMessage { get; set; }
        public ChatViewModel() 
        { 
            NewMessage = new MessageViewModel();
        }

    }
}
