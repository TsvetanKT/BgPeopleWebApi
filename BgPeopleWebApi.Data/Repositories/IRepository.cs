namespace BgPeopleWebApi.Data.Repositories
{
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        void Add(T entry);

        void Update(T entry);

        void Delete(T entry);

        void Detach(T entry);

        void SaveChanges();
    }
}
