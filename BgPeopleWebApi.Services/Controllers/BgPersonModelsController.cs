namespace BgPeople.Services.Controllers
{  
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using System.Web.Http.Description;
    using BgPeopleWebApi.Data;
    using BgPeopleWebApi.Models;

    [EnableCors(origins: "*", headers: "*", methods: "*")]// TODO
    public class BgPersonModelsController : ApiController
    {
        private BgPeopleDbContext db = new BgPeopleDbContext();

        // GET: api/BgPersonModel
        public IQueryable<BgPersonModel> GetBgPersonModels()
        {
            return this.db.BgPeople;
        }

        // GET: api/BgPersonModels/5
        [ResponseType(typeof(BgPersonModel))]
        public IHttpActionResult GetBgPersonModels(int id)
        {
            BgPersonModel searchedPerson = this.db.BgPeople.Find(id);
            if (searchedPerson == null)
            {
                return this.NotFound();
            }

            return this.Ok(searchedPerson);
        }

        // PUT: api/BgPersonModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBgPersonModel(int id, BgPersonModel editedPerson)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != editedPerson.Id)
            {
                return this.BadRequest();
            }

            this.db.Entry(editedPerson).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.BgPersonModelExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BgPersonModels
        [ResponseType(typeof(BgPersonModel))]
        public IHttpActionResult PostBgPersonModel(BgPersonModel newPerson)
        {
            if (!ModelState.IsValid || newPerson == null)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                this.db.BgPeople.Add(newPerson);
                this.db.SaveChanges();

                return this.CreatedAtRoute("DefaultApi", new { id = newPerson.Id }, newPerson);
            }
        }

        public IHttpActionResult PostRange(RangeModel range)
        {
            if (range.NumberOfPeople <= 0)
            {
                return this.BadRequest();
            }

            this.db.Generator.MinAge = range.MinAge;
            this.db.Generator.MaxAge = range.MaxAge;
            this.db.Generator.Unique = range.Unique;
            this.db.Generator.ConvertToEnglish = range.Language;

            // For testing purposes
            Stopwatch stopWatch = new Stopwatch();
            Stopwatch save = new Stopwatch();

            var people = this.db.GeneratePeople(range.NumberOfPeople);
            stopWatch.Start();

            this.db.Configuration.AutoDetectChangesEnabled = false;
            for (int i = 0; i < people.Count; i++)
            {
                var p = people[i];
                BgPersonModel converted = new BgPersonModel(p.FirstName, p.MiddleName, p.LastName, p.IsMale, p.BirthDay.Date, p.City, p.PhoneNumber, p.EGN);
                this.db.BgPeople.Add(converted);
                if (i % 100 == 0)
                {
                    save.Start();
                    this.db.SaveChanges();
                    save.Stop();
                }
            }

            save.Start();
            this.db.SaveChanges();
            save.Stop();
            this.db.Configuration.AutoDetectChangesEnabled = true;

            stopWatch.Stop();
            var timeSpent = stopWatch.Elapsed.TotalMilliseconds;
            var timeSave = save.Elapsed.TotalMilliseconds;

            return this.Ok(timeSpent);
        }

        // DELETE: api/BgPersonModels/5
        [ResponseType(typeof(BgPersonModel))]
        public IHttpActionResult DeleteBgPersonModel(int id)
        {
            BgPersonModel searchedPerson = this.db.BgPeople.Find(id);
            if (searchedPerson == null)
            {
                return this.NotFound();
            }

            this.db.BgPeople.Remove(searchedPerson);
            this.db.SaveChanges();

            return this.Ok(searchedPerson);
        }

        public IHttpActionResult DeleteAll()
        {
            foreach (var person in this.db.BgPeople)
            {
                this.db.BgPeople.Remove(person);
            }

            this.db.SaveChanges();

            return this.Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool BgPersonModelExists(int id)
        {
            return this.db.BgPeople.Count(e => e.Id == id) > 0;
        }
    }
}