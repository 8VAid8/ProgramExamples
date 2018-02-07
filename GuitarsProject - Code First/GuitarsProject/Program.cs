using GuitarsProject.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GuitarsProject.Guitar;

namespace GuitarsProject
{
    class Program
    {
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

        static void Main(string[] args)
        {
            Guitar yamahaPacifica012 = GetYamahaPacifica012();
            Guitar gibsonLesPaul = GetGibsonLesPaul();
            Guitar fenderStrat = GetFenderStratocaster();

            GuitarsRepository guitars = new GuitarsRepository();
            
           // guitars.Create(yamahaPacifica012);
           // guitars.Create(gibsonLesPaul);
           // guitars.Create(fenderStrat);

            List<Guitar> guitarsList = guitars.Get().ToList();
            WriteGuitarsInfo(guitarsList);
            Console.WriteLine("Выберите номер сортировки:\n1)По количеству ладов;\n" +
                "2)По марке гитары\r\n" +
                "3)По названию дерева корпуса\r\n");
            int s = Convert.ToInt32(Console.ReadLine());
            bool isOkInput = true;
            if (s == 1)
            {
                SortByFretsCount(guitarsList, true);
                Console.WriteLine("После сортировки по количеству ладов:");
            }
            else if (s == 2)
            {
                guitarsList.Sort();
                Console.WriteLine("После сортировки по марке гитары:");
            }
            else if (s == 3)
            {
                guitarsList.Sort(new BodyWoodComparer());
                Console.WriteLine("После сортировки по названию дерева корпуса:");
            }
            else
            {
                isOkInput = false;
                Console.WriteLine("Неверный метод сортировки");
            }
            if (isOkInput)
            {
                WriteGuitarsInfo(guitarsList);
            }   

            Console.ReadKey();
        }

        /// <summary>
        ///  Сортировка по количеству ладов
        /// </summary>
        /// <param name="guitars">список гитар</param>
        /// <param name="isAscending">сортировка по возрастанию</param>
        private static void SortByFretsCount(List<Guitar> guitars, bool isAscending)
        {
            for (int i = 0; i < guitars.Count; i++)
            {
                for (int j = 0; j < guitars.Count - i - 1; j++)
                {
                    if (isAscending)
                    {
                        if (guitars[j].Neck.FretsCount > guitars[j + 1].Neck.FretsCount)
                        {
                            Guitar temp = guitars[j];
                            guitars[j] = guitars[j + 1];
                            guitars[j + 1] = temp;
                        }
                    }
                    else
                    {
                        if (guitars[j].Neck.FretsCount < guitars[j + 1].Neck.FretsCount)
                        {
                            Guitar temp = guitars[j];
                            guitars[j] = guitars[j + 1];
                            guitars[j + 1] = temp;
                        }
                    }
                }
            }
        }

        private static void WriteGuitarsInfo(List<Guitar> guitars)
        {
            Console.WriteLine("Список гитар:\r\n");
            int n = 1;
            foreach(var guitar in guitars)
            {
                Console.WriteLine($"Гитара {n}:\r\n");
                n++;
                string guitarInfo = $"Марка: {guitar.Brand}\r\n" +
                    $"Модель: {guitar.Model}\r\n" +
                    $"Тип: {guitar.Type}\r\n" +
                    $"Цвет: {guitar.Color}\r\n" +
                    $"Корпус\r\n" +
                    $"Материал дерева: {guitar.Body.Wood}\r\n" +
                    $"Накладка: {(guitar.Body.Cover == true ? "есть" : "нет")}\r\n" +
                    $"Гриф\r\n" +
                    $"Материал дерева: {guitar.Neck.Wood}\r\n" +
                    $"Количество ладов: {guitar.Neck.FretsCount}\r\n" +
                    $"Звукосниматели\r\n";
                int i = 1;
                foreach(var pickup in guitar.Pickups)
                {
                    guitarInfo += $"Звукосниматель {i}\r\n" +
                        $"Тип: {pickup.Type}\r\n" +
                        $"Цвет: {pickup.Color}\r\n";
                    i++;
                }
                i = 1;
                foreach (var guitarString in guitar.Strings)
                {
                    guitarInfo += $"Струна {i}\r\n" +
                        $"Метал: {guitarString.Metal}\r\n" +
                        $"Толщина: {guitarString.Gauge}\r\n";
                    i++;
                }

                Console.WriteLine(guitarInfo);
            }
        }
    }
}
