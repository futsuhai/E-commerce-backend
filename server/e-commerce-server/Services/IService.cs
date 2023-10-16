public interface IService<T> where T : class
{
    public Task<IList<T>> GetAll();

    public Task<T> Get(int id);

    public Task Delete(int id);

    public Task Create(int id, T item);

    public Task Update(T item);
}