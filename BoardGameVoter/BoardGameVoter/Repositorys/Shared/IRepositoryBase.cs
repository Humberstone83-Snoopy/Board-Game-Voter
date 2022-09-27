using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.Shared;

namespace BoardGameVoter.Repositorys.Shared
{
    public interface IRepositoryBase<E, L>
        where E : EntityBase
        where L : RepositoryLoadOptions, new()
    {
        public E? Add(E entity);
        public IEnumerable<E>? Add(IEnumerable<E> entityList);
        public bool Delete(E entity);
        public bool Delete(IEnumerable<E> entityList);
        public IEnumerable<E> GetAll();
        public E? GetByID(int id);
        public IEnumerable<E> GetByID(IEnumerable<int> idList);
        public E? GetByUID(Guid uid);
        public bool Update(E entity);
        public bool Update(IEnumerable<E> entityList);
    }
}
