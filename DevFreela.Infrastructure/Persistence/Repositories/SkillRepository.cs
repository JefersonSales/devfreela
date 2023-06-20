using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DevFreela.Core.Dtos;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly string _connectionString;
        public SkillRepository( IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }
        public async Task<List<SkillDTO>> GetAllAsync()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            await using var _ = sqlConnection.ConfigureAwait(false);
            sqlConnection.Open();
            var script = "SELECT Id, Description FROM Skills";
            var skills = await sqlConnection.QueryAsync<SkillDTO>(script);
            return skills.ToList();
        }
    }
}