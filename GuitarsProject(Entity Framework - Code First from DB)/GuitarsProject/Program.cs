using GuitarsProject.DAL;
using System;
using System.Collections.Generic;

namespace GuitarsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select the action:1 - create guitar, 2 - show all guitars");
            string action = Console.ReadLine();
            switch(action)
            {
                case "1": CreateGuitar(); break;
                case "2": ShowGuitars(); break;
            }


            //создание, обновление, удаление

            //здесь должен был быть соответствующий код

            //но его нет
            Console.ReadKey();
        }

        private static void ShowGuitars()
        {
            //строка подключения хранится в App.config -> connectionStrings
            GuitarsRepository guitarsRepo = new GuitarsRepository();
            IEnumerable<Guitar> guitars = guitarsRepo.Get();
            //Вывод всех гитар из базы данных
            foreach (var guitar in guitars)
            {
                Console.WriteLine($"{guitar.Id} | {guitar.Brand} | {guitar.Color} | {guitar.Model} | {guitar.Price}");
            }
        }

        private static void CreateGuitar()
        {
            GuitarsRepository g = new GuitarsRepository();
            string brand, model, color;
            decimal price;

            Console.WriteLine("Insert brand of the car");
            brand = Console.ReadLine();

            Console.WriteLine("Insert model of the car");
            model = Console.ReadLine();

            Console.WriteLine("Insert color of the car");
            color = Console.ReadLine();

            Console.WriteLine("Insert price of the car");
            price = decimal.Parse(Console.ReadLine());

            g.Create(1, brand, model, color, price);
        }
    }
}
