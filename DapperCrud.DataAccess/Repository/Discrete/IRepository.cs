namespace DapperCrud.DataAccess.Repository.Discrete
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
