using APIKubernetsAndDocker.Models;
using System;

namespace APIKubernetsAndDocker.Repositories
{
    public interface IBlogPostRepository
    {
        Task<List<BlogPost>> GetAsync();
        Task<BlogPost> GetByIdAsync(int id);
        Task<bool> CreateAsync(BlogPost blogPost);
        Task<bool> UpdateAsync(BlogPost blogPost);
        Task<bool> DeleteAsync(int id);
    }
}
