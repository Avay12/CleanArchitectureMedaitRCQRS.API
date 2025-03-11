using CleanArchitectureMedaitRCQRS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureMedaitRCQRS.Domain.Repository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllAsync();
        Task<Blog> GetByIdAsync();
        Task<Blog> CreateAsync(Blog blog);
        Task<int> UpdateAsync();
        Task<int> DeleteAsync();
    }
}
