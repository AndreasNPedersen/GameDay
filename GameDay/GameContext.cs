using GameDay.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDay
{
    public class GameContext : DbContext
    {
        public DbSet<UserData> UserData { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupAttendees> GroupAttendees { get; set; }
        public DbSet<GroupOwner> GroupOwner { get; set; }

        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {

        }

     
    }
}
