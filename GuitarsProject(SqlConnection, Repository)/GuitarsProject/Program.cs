using GuitarsProject.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarsProject
{
    class Program
    {
        private static Guitar GetYamahaPacifica012()
        {
            Guitar yamahaPacifica12 = new Guitar();
            yamahaPacifica12.Price = 300;
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
            gibsonLesPaul.Price = 3000;
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
            fenderStrat.Price = 1500;
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

        static void Main(string[] args)
        {
            Guitar yamahaPacifica012 = GetYamahaPacifica012();
            Guitar gibsonLesPaul = GetGibsonLesPaul();
            Guitar fenderStrat = GetFenderStratocaster();

            List<Guitar> guitars = new List<Guitar>
            {
                yamahaPacifica012,
                fenderStrat,
                gibsonLesPaul

            };

            GuitarsRepository guitarsRepo = new GuitarsRepository();
            int i = 10;
            foreach (var guitar in guitars)
            {
                guitarsRepo.Create(i,
                    guitar.Brand,
                    guitar.Model,
                    guitar.Color.Name,
                    guitar.Price);
                i++; //лучше добавить автоинкремент в бд
            }
            Console.ReadKey();
        }

    }
}
