using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarsProject.DAL
{
    public class GuitarsRepository : IRepository<Guitar>
    {
        GuitarContext db;

        #region PrivateMethods

        private static Guitar GetYamahaPacifica012()
        {
            Guitar yamahaPacifica12 = new Guitar();
            yamahaPacifica12.Body = new Body
            {
                Wood = "агатис",
                Cover = true
            };
            yamahaPacifica12.Brand = "Yamaha";
            yamahaPacifica12.Color = Color.White;
            yamahaPacifica12.Model = "012";
            yamahaPacifica12.Neck = new Neck()
            {
                Wood = "клен",
                FretsCount = 22
            };
            yamahaPacifica12.Pickups = new List<Pickup>()
            {
                new Pickup() {Color = Color.White, Type = Type.Humbucker},
                new Pickup() {Color = Color.White, Type = Type.Single},
                new Pickup() {Color = Color.White, Type = Type.Single}
            };
            yamahaPacifica12.Strings = new List<GuitarString>()
            {
                new GuitarString() {Metal = "никель", Gauge = "Light"},
                new GuitarString() {Metal = "никель", Gauge = "Light"},
                new GuitarString() {Metal = "никель", Gauge = "Light"},
                new GuitarString() {Metal = "никель", Gauge = "Light"},
                new GuitarString() {Metal = "никель", Gauge = "Light"},
                new GuitarString() {Metal = "никель", Gauge = "Light"}
            };
            yamahaPacifica12.Type = GuitarType.Stratocaster;

            return yamahaPacifica12;
        }

        private static Guitar GetGibsonLesPaul()
        {
            Guitar gibsonLesPaul = new Guitar();
            gibsonLesPaul.Body = new Body
            {
                Wood = "Фигурный структурный клён",
                Cover = true
            };
            gibsonLesPaul.Brand = "Gibson";
            gibsonLesPaul.Color = Color.OrangeRed;
            gibsonLesPaul.Model = "True Historic 1959 Les Paul VCS Aged";
            gibsonLesPaul.Neck = new Neck()
            {
                Wood = "Махагони",
                FretsCount = 22
            };
            gibsonLesPaul.Pickups = new List<Pickup>()
            {
                new Pickup() {Color = Color.Silver, Type = Type.Humbucker},
                new Pickup() {Color = Color.Silver, Type = Type.Humbucker}
            };
            gibsonLesPaul.Strings = new List<GuitarString>()
            {
                new GuitarString() {Metal = "никель", Gauge = "Medium"},
                new GuitarString() {Metal = "никель", Gauge = "Medium"},
                new GuitarString() {Metal = "никель", Gauge = "Medium"},
                new GuitarString() {Metal = "никель", Gauge = "Medium"},
                new GuitarString() {Metal = "никель", Gauge = "Medium"},
                new GuitarString() {Metal = "никель", Gauge = "Medium"}
            };
            gibsonLesPaul.Type = GuitarType.LesPaul;

            return gibsonLesPaul;
        }

        private static Guitar GetFenderStratocaster()
        {
            Guitar fenderStrat = new Guitar();
            fenderStrat.Body = new Body
            {
                Wood = "ольха",
                Cover = true
            };
            fenderStrat.Brand = "Fender";
            fenderStrat.Color = Color.Black;
            fenderStrat.Model = "Standard Stratocaster HSS";
            fenderStrat.Neck = new Neck()
            {
                Wood = "клён",
                FretsCount = 21
            };
            fenderStrat.Pickups = new List<Pickup>()
            {
                new Pickup() {Color = Color.Yellow, Type = Type.Humbucker},
                new Pickup() {Color = Color.Yellow, Type = Type.Single},
                new Pickup() {Color = Color.Yellow, Type = Type.Single}
            };
            fenderStrat.Strings = new List<GuitarString>()
            {
                new GuitarString() {Metal = "никель", Gauge = "Light"},
                new GuitarString() {Metal = "никель", Gauge = "Light"},
                new GuitarString() {Metal = "никель", Gauge = "Light"},
                new GuitarString() {Metal = "никель", Gauge = "Light"},
                new GuitarString() {Metal = "никель", Gauge = "Light"},
                new GuitarString() {Metal = "никель", Gauge = "Light"}
            };
            fenderStrat.Type = GuitarType.Stratocaster;

            return fenderStrat;
        }

        #endregion

        public GuitarsRepository(GuitarContext context)
        {
            db = context;
            if (db.Guitars.Count() == 0)
            {
                db.Guitars.Add(GetYamahaPacifica012());
                db.Guitars.Add(GetGibsonLesPaul());
                db.Guitars.Add(GetFenderStratocaster());
                db.SaveChangesAsync();
            }
        }

        public void Create(Guitar guitar)
        {
            db.Guitars.Add(guitar);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            Guitar deletingGuitar = db.Guitars
                .Where(g => g.GuitarId == id)
                .FirstOrDefault();
            if (deletingGuitar == null)
                return false;
            else
            {
                db.Guitars.Remove(deletingGuitar);
                db.SaveChanges();
                return true;
            }   
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
                .FirstOrDefault();
        }

        public void Update(Guitar guitar)
        {
            db.Guitars.Update(guitar);
            db.SaveChanges();
        }

        public bool IsExists(int id)
        {
            return db.Guitars.Any(e => e.GuitarId == id);
        }
    }
}
