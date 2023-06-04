using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IA_Generated.Interface;

namespace IA_Generated.Models
{
    // Classe que representa um espaço vazio
    public class Empty : ICell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Empty(int x, int y)
        {
            X = x;
            Y = y;
        }

        public ConsoleColor GetBackgroundColor()
        {
            return ConsoleColor.Black;
        }

        public ConsoleColor GetForegroundColor()
        {
            return ConsoleColor.White;
        }

        public string GetSymbol()
        {
            return "--";
        }
    }
}