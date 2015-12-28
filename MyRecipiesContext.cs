using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipies
{
    class MyRecipiesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Recipe> Recipies { get; set; }
        public DbSet<RecipeItem> RecipeItems { get; set; }
        public DbSet<FriendList> FriendLists { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendList>()
                        .HasRequired(m => m.User)
                        .WithMany(t => t.Users)
                        .HasForeignKey(m => m.UserId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<FriendList>()
                        .HasRequired(m => m.Friend)
                        .WithMany(t => t.Friends)
                        .HasForeignKey(m => m.FriendId)
                        .WillCascadeOnDelete(false);
        }
    }
}
