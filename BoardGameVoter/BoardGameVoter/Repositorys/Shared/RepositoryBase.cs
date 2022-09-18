using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.Shared;

namespace BoardGameVoter.Repositorys.Shared
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : EntityBase
    {

        private DbContextBase<T> __DBContext;

        public RepositoryBase(DbContextBase<T> dbContext)
        {
            __DBContext = dbContext;
        }

        public Guid Add(T entity)
        {
            if (entity == null) { throw new ArgumentNullException("Entity can not be null", nameof(entity)); }
            try
            {
                if (entity.UID == Guid.Empty)
                {
                    entity.UID = Guid.NewGuid();
                }

                __DBContext.Data.Add(entity);
                __DBContext.SaveChanges();
                return entity.UID;
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public void Add(List<T> entityList)
        {
            __DBContext.Data.AddRange(entityList);
            __DBContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            __DBContext.Data.Remove(entity);
            __DBContext.SaveChanges();
        }

        public void Delete(List<T> entityList)
        {
            __DBContext.Data.RemoveRange(entityList);
            __DBContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return __DBContext.Data.ToList();
        }

        public T GetByID(int id)
        {
            return __DBContext.Data.Find(id);
        }

        public List<T> GetByID(IEnumerable<int> idList)
        {
            return __DBContext.Data.Where(entity => idList.Contains(entity.ID)).ToList();
        }

        public T GetByUID(Guid uid)
        {
            return __DBContext.Data.FirstOrDefault(entity => entity.UID.CompareTo(uid) == 0);
        }

        public void Update(T entity)
        {
            __DBContext.Update(entity);
            __DBContext.SaveChanges();
        }

        public void Update(List<T> entityList)
        {
            foreach (T entity in entityList)
            {
                __DBContext.Update(entity);
            }
            __DBContext.SaveChanges();
        }

        internal DbContextBase<T> DBContext { get => __DBContext; }
    }
}
