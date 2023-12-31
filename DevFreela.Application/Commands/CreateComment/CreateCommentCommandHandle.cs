using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandle : IRequestHandler<CreateCommentCommand, Unit>
    {
       private readonly ICommentRepository _commentRepository;

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);
            await _commentRepository.AddAsync(comment);
            return Unit.Value;
        }
    }
}