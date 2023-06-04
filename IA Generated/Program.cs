using System;
using IA_Generated.Models;

public class Program
{
    public static void Main()
    {
        Map map = new Map(10, 10);
        bool running = true;

        while (running)
        {
            map.PrintMap();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    map.MoveRobot("up");
                    break;
                case ConsoleKey.DownArrow:
                    map.MoveRobot("down");
                    break;
                case ConsoleKey.LeftArrow:
                    map.MoveRobot("left");
                    break;
                case ConsoleKey.RightArrow:
                    map.MoveRobot("right");
                    break;
                case ConsoleKey.Escape:
                    running = false;
                    break;
            }
        }
    }
}