using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IA_Generated.Interface;

namespace IA_Generated.Models
{
    // Classe que representa uma joia
    public class Jewel : ICell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Type { get; set; }

        public Jewel(int x, int y, string type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public ConsoleColor GetBackgroundColor()
        {
            return ConsoleColor.Black;
        }

        public ConsoleColor GetForegroundColor()
        {
            switch (Type)
            {
                case "Red":
                    return ConsoleColor.Red;
                case "Green":
                    return ConsoleColor.Green;
                case "Blue":
                    return ConsoleColor.Blue;
                default:
                    return ConsoleColor.White;
            }
        }

        public string GetSymbol()
        {
            switch (Type)
            {
                case "Red":
                    return "JR";
                case "Green":
                    return "JG";
                case "Blue":
                    return "JB";
                default:
                    return "";
            }
        }
    }
}