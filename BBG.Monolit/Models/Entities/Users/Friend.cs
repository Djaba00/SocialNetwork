namespace BBG.Monolit.Models.Entities.Users
{
    public class Friend
    {
        public int Id { get; set; }
        public MappingProfile UsdrId { get; set; }
        public User User { get; set; }
        public string CurrentFriendId { get; set; }
        public User Currentfriend { get; set; }
    }
}
