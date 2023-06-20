using MediatR;

namespace DevFreela.Application.Commands
{
    public class StartProject : IRequest<Unit>
    {
        public StartProject(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}