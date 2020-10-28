using Database.Entities;
using Database.Entities.GameBoardObjects.Property;
using Database.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class MonopolyContext : DbContext
    {
        public MonopolyContext(DbContextOptions<MonopolyContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<GameState> GameStates { get; set; }
        public DbSet<Property> Properties { get; set; }
    }
}