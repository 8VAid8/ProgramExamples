using System.Drawing;

namespace GuitarsProject
{
    public enum Type
    {
        Single,
        Humbucker
    }
    public class Pickup
    {
        public Color Color { get; set; }
        public Type Type { get; set; }
    }
}