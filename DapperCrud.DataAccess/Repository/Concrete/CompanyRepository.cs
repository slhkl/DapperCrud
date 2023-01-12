using Dapper;
using DapperCrud.Data.Model;
using DapperCrud.DataAccess.Repository.Discrete;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DapperCrud.DataAccess.Repository.Concrete
{
    public class CompanyRepository : BaseRepository, IRepository<Company>
    {
        public CompanyRepository(IConfiguration configuration) : base(configuration) { }
        public async Task<IEnumerable<Company>> Get()
        {
            var query = "SELECT * FROM Companies";

            using (var connection = CreateConnection())
                return await connection.QueryAsync<Company>(query);

        }

        public async Task<Company> Get(int id)
        {
            var query = "SELECT * FROM Companies WHERE Id=@Id";
            using (var connection = CreateConnection())
                return await connection.QuerySingleOrDefaultAsync<Company>(query, new { id });
        }

        public async Task Create(Company company)
        {
            var query = "INSERT INTO Companies (CompanyName, CompanyAddress, Country, GlassdoorRating) VALUES (@CompanyName, @CompanyAddress, @Country, @GlassdoorRating)";

            var parameters = new DynamicParameters();
            parameters.Add("CompanyName", company.CompanyName, DbType.String);
            parameters.Add("CompanyAddress", company.CompanyAddress, DbType.String);
            parameters.Add("Country", company.Country, DbType.String);
            parameters.Add("GlassdoorRating", company.GlassdoorRating, DbType.Int32);

            using (var connection = CreateConnection())
                await connection.ExecuteAsync(query, parameters);
        }

        public async Task Update(Company company)
        {
            var query = "UPDATE Companies SET CompanyName = @CompanyName, CompanyAddress = @CompanyAddress, Country = @Country, GlassdoorRating = @GlassdoorRating WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", company.Id, DbType.Int32);
            parameters.Add("CompanyName", company.CompanyName, DbType.String);
            parameters.Add("CompanyAddress", company.CompanyAddress, DbType.String);
            parameters.Add("Country", company.Country, DbType.String);
            parameters.Add("GlassdoorRating", company.GlassdoorRating, DbType.Int32);

            using (var connection = CreateConnection())
                await connection.ExecuteAsync(query, parameters);
        }

        public async Task Delete(int id)
        {
            var query = "DELETE FROM Companies WHERE Id = @Id";
            using (var connection = CreateConnection())
                await connection.ExecuteAsync(query, new { id });
        }
    }
}
