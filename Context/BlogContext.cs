using APIKubernetsAndDocker.Models;
using Microsoft.EntityFrameworkCore;

namespace APIKubernetsAndDocker.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
