namespace JewelCollector.Models
{
// Classe que representa o robô
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<Jewel> Bag { get; set; }

        public Robot(int x, int y)
        {
            X = x;
            Y = y;
            Bag = new List<Jewel>();
        }

        public void MoveUp()
        {
            Y--;
        }

        public void MoveDown()
        {
            Y++;
        }

        public void MoveLeft()
        {
            X--;
        }

        public void MoveRight()
        {
            X++;
        }

        public void CollectJewel(Jewel jewel)
        {
            Bag.Add(jewel);
        }

        public void PrintBag()
        {
            Console.WriteLine("Total de joias coletadas: " + Bag.Count);
            int totalValue = 0;
            foreach (var jewel in Bag)
            {
                totalValue += GetValueOfJewel(jewel);
            }
            Console.WriteLine("Valor total: " + totalValue);
        }

        private int GetValueOfJewel(Jewel jewel)
        {
            switch (jewel.Type)
            {
                case "Red":
                    return 100;
                case "Green":
                    return 50;
                case "Blue":
                    return 10;
                default:
                    return 0;
            }
        }
    }
}