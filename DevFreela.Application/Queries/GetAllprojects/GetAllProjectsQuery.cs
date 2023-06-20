using System.Collections.Generic;
using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetAllprojects
{
    public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
    {
        public GetAllProjectsQuery(string query)
        {
            this.query = query;
        }

        public string query { get; set; }
    }
}