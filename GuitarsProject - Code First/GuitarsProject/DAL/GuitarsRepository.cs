using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace GuitarsProject.DAL
{
    public class GuitarsRepository : IRepository<Guitar>
    {
        GuitarContext db;
        public GuitarsRepository()
        {
            db = new GuitarContext();
        }

        public void Create(Guitar guitar)
        {
            db.Guitars.Add(guitar);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Guitar deletingGuitar = db.Guitars.Where(g => g.GuitarId == id).FirstOrDefault();
            db.Guitars.Remove(deletingGuitar);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<Guitar> Get()
        {
            return db.Guitars
                .Include(x => x.Body)
                .Include(x => x.Neck)
                .Include(x => x.Pickups)
                .Include(x => x.Strings)
                .ToList();
        }

        public Guitar Get(int id)
        {
            return db.Guitars
                .Where(g => g.GuitarId == id)
                .Include(x => x.Body)
                .Include(x => x.Neck)
                .Include(x => x.Pickups)
                .Include(x => x.Strings)
                .Include(x => x.Type)
                .FirstOrDefault();
        }

        public void Update(Guitar guitar)
        {
            Guitar updatingGuitar = db.Guitars
                .Where(g => g.GuitarId == guitar.GuitarId)
                .FirstOrDefault();
            updatingGuitar = guitar;
            db.SaveChanges();
        }
    }
}
