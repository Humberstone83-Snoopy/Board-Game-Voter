using BoardGameVoter.Models.Shared;

namespace BoardGameVoter.Repositorys.Shared
{
    public interface IRepositoryBase<T>
        where T : EntityBase
    {
        public Guid Add(T entity);
        public void Add(List<T> entityList);
        public void Delete(T entity);
        public void Delete(List<T> entityList);
        public List<T> GetAll();

        public T GetByID(int id);

        public List<T> GetByID(IEnumerable<int> idList);

        public T GetByUID(Guid uid);
        public void Update(T entity);

        public void Update(List<T> entityList);
    }
}
