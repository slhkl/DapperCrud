namespace DapperCrud.Business.Service.Discrete
{
    public interface IService<T> where T : class
    {
        public Task<IEnumerable<T>> Get();
        public Task<T> Get(int id);
        public Task Create(T entity);
        public Task Update(T entity);
        public Task Delete(int id);
    }
}
