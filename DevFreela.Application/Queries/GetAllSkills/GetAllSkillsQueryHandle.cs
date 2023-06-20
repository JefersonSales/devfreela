using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Dtos;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandle : IRequestHandler<GetAllSkillsQuery, List<SkillDTO>>
    {
        private readonly ISkillRepository _skillRepository;
        public GetAllSkillsQueryHandle(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<List<SkillDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken) =>  await _skillRepository.GetAllAsync();
    }
}