using GuitarsProject.DAL;
using System;
using System.Collections.Generic;

namespace GuitarsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //строка подключения хранится в App.config -> connectionStrings
            GuitarsRepository guitarsRepo = new GuitarsRepository();
            IEnumerable<Guitar> guitars = guitarsRepo.Get();

            //Вывод всех гитар из базы данных
            foreach (var guitar in guitars)
            {
                Console.WriteLine($"{guitar.Id} | {guitar.Brand} | {guitar.Color} | {guitar.Model} | {guitar.Price}");
            }

            //создание, обновление, удаление

            //здесь должен был быть соответствующий код

            //но его нет
            Console.ReadKey();
        }

    }
}
