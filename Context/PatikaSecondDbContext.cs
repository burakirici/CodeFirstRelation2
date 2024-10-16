using CodeFirstRelation2.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstRelation2.Context
{
    public class PatikaSecondDbContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=BURAK\SQLEXPRESS; Database=PatikaCodeFirstDb2; TrustServerCertificate=true; trusted_connection=true;");
            base.OnConfiguring(optionsBuilder);
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserEntity>()
                                .HasOne(u => u.UserPost)
                                .WithMany(p => p.Posts)
                                .HasForeignKey(p => p.UserPostId);
                                
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<PostEntity> Posts => Set<PostEntity>();
        public DbSet<UserEntity> Users => Set<UserEntity>();
    }
}
