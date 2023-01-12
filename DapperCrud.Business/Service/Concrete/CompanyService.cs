using DapperCrud.Business.Service.Discrete;
using DapperCrud.Data.Model;
using DapperCrud.DataAccess.Repository.Discrete;

namespace DapperCrud.Business.Service.Concrete
{
    public class CompanyService : IService<Company>
    {
        private readonly IRepository<Company> _repository;
        public CompanyService(IRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Company>> Get()
        {
            return await _repository.Get();
        }

        public async Task<Company> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task Create(Company company)
        {
            await _repository.Create(company);
        }

        public async Task Update(Company company)
        {
            await _repository.Update(company);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
