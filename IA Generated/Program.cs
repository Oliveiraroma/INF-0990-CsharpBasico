using System;
using IA_Generated.Models;

public class Program
{
    public static void Main()
    {
        Map map = new Map(10, 10);
        bool running = true;
        char input;

        while (running)
        {
            map.PrintMap();

            Console.WriteLine("Use as teclas 'w', 's', 'a', 'd' para mover o robô.");
            Console.WriteLine("Pressione 'g' para coletar uma joia.");
            Console.WriteLine("Pressione 'q' para sair do jogo.");
            Console.WriteLine("Pressione 'r' para reiniciar o jogo.");
            input = Console.ReadKey().KeyChar;        
          
            if (input == 'q')
                {
                    Console.WriteLine("Jogo encerrado.");
                    running = false;
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
            


        }
    }
}