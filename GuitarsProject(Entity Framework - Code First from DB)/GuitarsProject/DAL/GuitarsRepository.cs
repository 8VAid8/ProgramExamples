using System.Collections.Generic;
using System.Linq;

namespace GuitarsProject.DAL
{
    public class GuitarsRepository : IRepository<Guitar>
    {
        GuitarContext db;
        public GuitarsRepository()
        {
            db = new GuitarContext();
        }

        public void Create(int id, string brand, string model, string color, decimal price)
        {
            Guitar creatingGuitar = new Guitar
            {
                Id = id,
                Brand = brand,
                Model = model,
                Color = color,
                Price = price
            };
            db.Guitars.Add(creatingGuitar);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Guitar deletingGuitar = db.Guitars.Where(g => g.Id == id).FirstOrDefault();
            db.Guitars.Remove(deletingGuitar);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Guitar> Get()
        {
            return db.Guitars;
        }

        public void Update(int id, string brand, string model, string color, decimal price)
        {
            Guitar updatingGuitar = db.Guitars.Where(g => g.Id == id).FirstOrDefault();
            updatingGuitar.Brand = brand;
            updatingGuitar.Model = model;
            updatingGuitar.Color = color;
            updatingGuitar.Price = price;
            db.SaveChanges();
        }
    }
}
