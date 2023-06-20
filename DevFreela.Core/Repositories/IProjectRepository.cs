using System.Collections.Generic;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        public Task<List<Project>> GetAllAsync();
        
        public Task<Project> GetDetailsByIdAsync(int id);
        
         Task AddAsync(Project project);

         Task StartAsync(Project project);
         
         Task SaveChangeAsync();

         public Task<Project> GetByIdAsync(int id);
    }
}