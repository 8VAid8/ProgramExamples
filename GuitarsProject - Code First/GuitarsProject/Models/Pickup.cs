using GuitarsProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace GuitarsProject
{
    public enum Type
    {
        Single,
        Humbucker
    }
    public class Pickup : Entity
    {
        public Color Color { get; set; }
        public Type Type { get; set; }

        //вторичный ключ
        public int GuitarId { get; set; }
        public Guitar Guitar { get; set; }
    }
}