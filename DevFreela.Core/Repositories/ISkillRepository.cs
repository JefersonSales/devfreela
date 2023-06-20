using System.Collections.Generic;
using System.Threading.Tasks;
using DevFreela.Core.Dtos;

namespace DevFreela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<SkillDTO>> GetAllAsync();
    }
}