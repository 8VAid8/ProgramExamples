using GuitarsProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarsProject
{
    public class Neck : Entity
    {
        public string Wood { get; set; } //материал изготовления (красное дерево, клён, липа и т.д.)
        public int FretsCount { get; set; } //количество ладов (22, 24)

        //вторичный ключ
        [Key]
        [ForeignKey("Guitar")]
        public int GuitarId { get; set; }
        public Guitar Guitar { get; set; }
    }
}