using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.UpadateProject
{
    public class UpdateProjectCommandHandle : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        
        public UpdateProjectCommandHandle(IProjectRepository projectRepository)
        {
           
            _projectRepository = projectRepository;
        }
        
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            project.Update(request.Title, request.Description, request.TotalCost);
            await _projectRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}