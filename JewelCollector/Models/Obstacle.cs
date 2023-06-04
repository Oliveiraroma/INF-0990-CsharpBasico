using JewelCollector.Interface;

namespace JewelCollector.Models
{
// Classe que representa um obstáculo
    public class Obstacle : ICell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Type { get; set; }

        public Obstacle(int x, int y, string type)
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
            return ConsoleColor.Gray;
        }

        public string GetSymbol()
        {
            switch (Type)
            {
                case "Water":
                    return "$$";
                case "Tree":
                    return "##";
                default:
                    return "";
            }
        }
    }
}