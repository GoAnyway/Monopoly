using Database.Entities.GameEntities;
using Database.Entities.GameEntities.GameBoardObjects;
using Database.Entities.GameEntities.GameBoardObjects.PropertyEntities;
using Database.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class MonopolyContext : DbContext
    {
        public MonopolyContext(DbContextOptions<MonopolyContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cell>().HasData(CellSeed.GetCellsToSeed());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<GameCreation> CreatedGames { get; set; }
        public DbSet<MonopolyGame> ActiveGames { get; set; }
        public DbSet<Cell> Cells { get; set; }
    }
}