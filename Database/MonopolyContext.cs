using Database.Entities.GameEntities;
using Database.Entities.GameEntities.GameBoardObjects.Property;
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
        public DbSet<GameCreation> CreatedGames { get; set; }
        public DbSet<MonopolyGame> ActiveGames { get; set; }
        public DbSet<Property> Properties { get; set; }
    }
}