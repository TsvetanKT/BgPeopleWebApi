namespace BgPeopleWebApi.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using BgPeopleWebApi.Models;

    public interface IBgPeopleDbContext
    {
        IDbSet<BgPersonModel> BgPeople { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
