using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.DeleteProjectCommand
{
    public class DeleteProjectCommandHandle : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly IProjectRepository _projectRepository;

        public DeleteProjectCommandHandle(DevFreelaDbContext dbContext, IProjectRepository projectRepository)
        {
            _dbContext = dbContext;
            _projectRepository = projectRepository;
        }
        
        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            project.Cancel();
           await _projectRepository.SaveChangeAsync();
           return Unit.Value;
        }
    }
}