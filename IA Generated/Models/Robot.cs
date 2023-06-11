using IA_Generated.Interface;

namespace IA_Generated.Models
{
    // Classe que representa o robô
    public class Robot : ICell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Energy { get; set; }
        public int MaxEnergy { get; set; }
        public int BagSize { get; set; }
        public int BagCount { get; set; }

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
            return "ME";
        }
        public Robot(int x, int y, int maxEnergy, int bagSize)
        {
            X = x;
            Y = y;
            Energy = maxEnergy;
            MaxEnergy = maxEnergy;
            BagSize = bagSize;
            BagCount = 0;
        }

        public void Move(int newX, int newY)
        {
            X = newX;
            Y = newY;
            Energy--;
        }

        public void CollectJewel()
        {
            BagCount++;
            Energy++;
        }

        public bool IsBagFull()
        {
            return BagCount >= BagSize;
        }

        public void Recharge()
        {
            Energy = MaxEnergy;
        }
    }
}