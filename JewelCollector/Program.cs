using JewelCollector.Interface;

namespace JewelCollector.Models
{
    public class Program
    {
        public static void Main()
        {
            Map map = new Map();

            // Insere as joias
            map.AddJewel(new Jewel(1, 9, "Red"));
            map.AddJewel(new Jewel(8, 8, "Red"));
            map.AddJewel(new Jewel(9, 1, "Green"));
            map.AddJewel(new Jewel(7, 6, "Green"));
            map.AddJewel(new Jewel(3, 4, "Blue"));
            map.AddJewel(new Jewel(2, 1, "Blue"));

            // Insere os obstáculos
            map.AddObstacle(new Obstacle(5, 0, "Water"));
            map.AddObstacle(new Obstacle(5, 1, "Water"));
            map.AddObstacle(new Obstacle(5, 2, "Water"));
            map.AddObstacle(new Obstacle(5, 3, "Water"));
            map.AddObstacle(new Obstacle(5, 4, "Water"));
            map.AddObstacle(new Obstacle(5, 5, "Water"));
            map.AddObstacle(new Obstacle(5, 6, "Water"));
            map.AddObstacle(new Obstacle(5, 9, "Tree"));
            map.AddObstacle(new Obstacle(3, 9, "Tree"));
            map.AddObstacle(new Obstacle(8, 3, "Tree"));
            map.AddObstacle(new Obstacle(2, 5, "Tree"));
            map.AddObstacle(new Obstacle(1, 4, "Tree"));


            char input;
            while (true)
            {
                map.PrintMap();

                Console.WriteLine("Jewel Collector - Instruções:");
                Console.WriteLine("Use as teclas 'w', 's', 'a', 'd' para mover o robô.");
                Console.WriteLine("Pressione 'g' para coletar uma joia.");
                Console.WriteLine("Pressione 'q' para sair do jogo.");
                input = Console.ReadKey().KeyChar;

                
                if (input == 'q')
                {
                    Console.WriteLine("Jogo encerrado.");
                    break;
                }
                else if (input == 'g' && map.IsJewelAdjacent())
                {
                    map.CollectJewel();
                }
                else if (input == 'w' || input == 's' || input == 'a' || input == 'd')
                {
                    map.MoveRobot(input);
                }       
                else
                {
                    Console.WriteLine("Comando inválido. Pressione enter para tentar novamente.");
                    Console.ReadLine();
                }
            }
        }
    }
}