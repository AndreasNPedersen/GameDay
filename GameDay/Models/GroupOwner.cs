namespace GameDay.Models
{
    public class GroupOwner
    {
        public int Id { get; set; }
        public Group group { get; set; }
        public UserData userOwner { get; set; }
    }
}
