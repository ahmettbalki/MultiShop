using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentContext  : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1436;initial Catalog=MultiShopCommentDb;User=sa;Password=35129144144aB.;TrustServerCertificate=True;");
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
