﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GuitarsProject
{
    public class Guitar
    {
        public int Id { get; set; }
        public string Brand { get; set; } //марка (Yamaha, Gibson)
        public string Model { get; set; } //модель (Pacifica, Les Paul)
        public decimal Price { get; set; } //цена
        public string Color { get; set; } // цвет гитары
    }
}
