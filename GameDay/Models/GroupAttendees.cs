namespace GameDay.Models
{
    public class GroupAttendees
    {
        public int Id { get; set; }
        public virtual Group Group { get; set; }
        public UserData UserAttendeen { get; set; }
    }
}
