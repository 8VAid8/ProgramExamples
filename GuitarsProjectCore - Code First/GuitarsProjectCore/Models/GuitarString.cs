using GuitarsProjectCore.Models;

namespace GuitarsProjectCore
{
    public class GuitarString : Entity
    {
        public string Gauge { get; set; } // толщина струн (Extra Light, Light, Medium)
        public string Metal { get; set; } //никель, сталь

        //вторичный ключ
        public int GuitarId { get; set; }
        public Guitar Guitar { get; set; }
    }
}