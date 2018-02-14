using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GuitarsProject.Models;

namespace GuitarsProject
{
    public enum GuitarType
    {
        Stratocaster,
        Telecaster,
        LesPaul
    }

    public class Guitar : IComparable<Guitar>
    {
        public int GuitarId { get; set; }
        public string Brand { get; set; } //марка (Yamaha, Gibson)
        public string Model { get; set; } //модель (Pacifica, Les Paul)
        public GuitarType Type { get; set; } //тип гитары (страт, телек, Лес Пол)
        public Color? Color { get; set; } // цвет гитары
        public Neck Neck { get; set; } //гриф
        public Body Body { get; set; } //дека
        public List<GuitarString> Strings { get; set; } //струны
        public List<Pickup> Pickups { get; set; } //звукосниматели

        /// <summary>
        /// Сравнение по марке
        /// </summary>
        /// <param name="guitar"></param>
        /// <returns></returns>
        public int CompareTo(Guitar guitar)
        {
            return this.Brand.CompareTo(guitar.Brand);
        }

        public class BodyWoodComparer : IComparer<Guitar>
        {
            public int Compare(Guitar guitar1, Guitar guitar2)
            {
                if (guitar1.Body.Wood.ToLower()[0] > guitar2.Body.Wood.ToLower()[0])
                    return 1;
                else if (guitar1.Body.Wood.ToLower()[0] < guitar2.Body.Wood.ToLower()[0])
                    return -1;
                else
                    return 0;
            }
        }
    }
}
