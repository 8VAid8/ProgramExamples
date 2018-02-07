using GuitarsProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarsProject
{
    public class Body : Entity
    {
        public string Wood { get; set; } //материал изготовления (красное дерево, клён, липа и т.д.)
        public bool Cover { get; set; } //накладка (естьили нет)

        //вторичный ключ
        [Key]
        [ForeignKey("Guitar")]
        public int GuitarId { get; set; }
        public Guitar Guitar { get; set; }
    }
}