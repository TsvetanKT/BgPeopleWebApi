namespace BgPeopleWebApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BgPeopleWebApi.Data.Migrations;
    using BgPeopleWebApi.Models;

    using BgPersonGeneratorSpace;

    public class BgPeopleDbContext : DbContext, IBgPeopleDbContext
    {
        public BgPeopleDbContext()
            : base("BgPeopleConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BgPeopleDbContext, Configuration>());
            this.Generator = new BgPersonGenerator(convertToEnglish: false, unique: false);
        }

        public BgPersonGenerator Generator { get; set; }

        public virtual IDbSet<BgPersonModel> BgPeople { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public BgPerson GeneratePerson()
        {
            return this.Generator.GetRandomPerson();
        }

        public List<BgPerson> GeneratePeople(int numberOfPeople)
        {
            return this.Generator.GenerateRandomPeople(numberOfPeople);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
