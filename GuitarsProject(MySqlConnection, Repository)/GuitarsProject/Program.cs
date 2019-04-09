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
        private static Guitar CreateGuitar(int price, string model, string brand, Color color, string woodMaterial, bool cover, int fretsCount)
        {
            Guitar guitar = new Guitar();
            guitar.Price = price;
            guitar.Body = new Body
            {
                Wood = woodMaterial,
                Cover = cover
            };
            guitar.Brand = brand;
            guitar.Color = color;
            guitar.Model = model;
            guitar.Neck = new Neck()
            {
                Wood = woodMaterial,
                FretsCount = fretsCount
            };
            //ToDo: implement pickups and strings
            //yamahaPacifica12.Pickups = new List<Pickup>()
            //{
            //    new Pickup() {Color = Color.White, Type = Type.Humbucker},
            //    new Pickup() {Color = Color.White, Type = Type.Single},
            //    new Pickup() {Color = Color.White, Type = Type.Single}
            //};
            //yamahaPacifica12.Strings = new List<GuitarString>()
            //{
            //    new GuitarString() {Metal = "никель", Gauge = "Light"},
            //    new GuitarString() {Metal = "никель", Gauge = "Light"},
            //    new GuitarString() {Metal = "никель", Gauge = "Light"},
            //    new GuitarString() {Metal = "никель", Gauge = "Light"},
            //    new GuitarString() {Metal = "никель", Gauge = "Light"},
            //    new GuitarString() {Metal = "никель", Gauge = "Light"}
            //};
            //yamahaPacifica12.Type = GuitarType.Stratocaster;

            return guitar;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Select the action:1 - create guitar, 2 - show all guitars");
            string action = Console.ReadLine();
            switch (action)
            {
                case "1": CreateGuitar(); break;
                case "2": ShowGuitars(); break;
            }


            Console.ReadKey();
        }

        private static void ShowGuitars()
        {
            GuitarsRepository guitarsRepo = new GuitarsRepository();
            IEnumerable<Guitar> guitars = guitarsRepo.Get();
            foreach (var guitar in guitars)
            {
                Console.WriteLine(guitar.Model + " " + guitar.Type + " " + guitar.Price);
            }
        }

        private static void CreateGuitar()
        {
            GuitarsRepository g = new GuitarsRepository();
            string brand, model, color;
            decimal price;

            Console.WriteLine("Insert brand of the guitar");
            brand = Console.ReadLine();

            Console.WriteLine("Insert model of the guitar");
            model = Console.ReadLine();

            Console.WriteLine("Insert color of the guitar");
            color = Console.ReadLine();

            Console.WriteLine("Insert price of the car");
            price = decimal.Parse(Console.ReadLine());

            g.Create(brand, model, color, price);
        }
    }
}
