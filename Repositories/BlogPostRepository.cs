using APIKubernetsAndDocker.Context;
using APIKubernetsAndDocker.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace APIKubernetsAndDocker.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogContext _context;
        private readonly DbSet<BlogPost> _dataset;
        public BlogPostRepository(BlogContext blogContext)
        {
            _context = blogContext;
            _dataset = _context.Set<BlogPost>();
        }

        public async Task<bool> CreateAsync(BlogPost blogPost)
        {
            try
            {
                _dataset.Add(blogPost);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(id));
            if (data != null)
            {
                try
                {
                    _dataset.Remove(data);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return false;
        }

        public async Task<List<BlogPost>> GetAsync()
        {
            return await _dataset.AsNoTracking().ToListAsync();
        }

        public async Task<BlogPost> GetByIdAsync(int id)
        {
            return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<bool> UpdateAsync(BlogPost blogPost)
        {
            var data = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(blogPost.Id));
            if (data != null)
            {
                try
                {
                    _context.Entry(data).CurrentValues.SetValues(blogPost);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return false;
        }
    }
}
