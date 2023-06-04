using JewelCollector.Models;
using JewelCollector.Interface;

namespace JewelCollector.Models
{
 // Classe que representa o mapa
    public class Map
    {
        private const int MapSize = 10;
        private char[,] map;
        private Robot robot;
        private List<Jewel> jewels;
        private List<Obstacle> obstacles;

        public Map()
        {
            map = new char[MapSize, MapSize];
            robot = new Robot(0, 0);
            jewels = new List<Jewel>();
            obstacles = new List<Obstacle>();
        }

        public void AddJewel(Jewel jewel)
        {
            jewels.Add(jewel);
        }

        public void AddObstacle(Obstacle obstacle)
        {
            obstacles.Add(obstacle);
        }

        public void PrintMap()
        {
            Console.Clear();

            for (int y = 0; y < MapSize; y++)
            {
                for (int x = 0; x < MapSize; x++)
                {
                    bool isRobot = robot.X == x && robot.Y == y;
                    bool isJewel = false;
                    bool isObstacle = false;

                    foreach (var jewel in jewels)
                    {
                        if (jewel.X == x && jewel.Y == y)
                        {
                            isJewel = true;
                            break;
                        }
                    }

                    foreach (var obstacle in obstacles)
                    {
                        if (obstacle.X == x && obstacle.Y == y)
                        {
                            isObstacle = true;
                            break;
                        }
                    }

                    if (isRobot)
                    {
                        Console.Write("ME ");
                    }
                    else if (isJewel)
                    {
                        Console.Write(GetJewelSymbol(x, y) + " ");
                    }
                    else if (isObstacle)
                    {
                        Console.Write(GetObstacleSymbol(x, y) + " ");
                    }
                    else
                    {
                        Console.Write("-- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            robot.PrintBag();
        }

        private string GetJewelSymbol(int x, int y)
        {
            foreach (var jewel in jewels)
            {
                if (jewel.X == x && jewel.Y == y)
                {
                    switch (jewel.Type)
                    {
                        case "Red":
                            return "JR";
                        case "Green":
                            return "JG";
                        case "Blue":
                            return "JB";
                    }
                }
            }

            return " ";
        }

        private string GetObstacleSymbol(int x, int y)
        {
            foreach (var obstacle in obstacles)
            {
                if (obstacle.X == x && obstacle.Y == y)
                {
                    switch (obstacle.Type)
                    {
                        case "Water":
                            return "$$";
                        case "Tree":
                            return "##";
                    }
                }
            }

            return "";
        }

        public bool IsJewelAdjacent()
        {
            foreach (var jewel in jewels)
            {
                if (Math.Abs(jewel.X - robot.X) <= 1 && Math.Abs(jewel.Y - robot.Y) <= 1)
                {
                    return true;
                }
            }

            return false;
        }

        public void CollectJewel()
        {
            foreach (var jewel in jewels)
            {
                if (Math.Abs(jewel.X - robot.X) <= 1 && Math.Abs(jewel.Y - robot.Y) <= 1)
                {
                    robot.CollectJewel(jewel);
                    jewels.Remove(jewel);
                    break;
                }
            }
        }

        public bool IsObstacle(int x, int y)
        {
            foreach (var obstacle in obstacles)
            {
                if (obstacle.X == x && obstacle.Y == y)
                {
                    return true;
                }
            }

            return false;
        }

        public void MoveRobot(char direction)
        {
            int newX = robot.X;
            int newY = robot.Y;

            switch (direction)
            {
                case 'w':
                    newY--;
                    break;
                case 's':
                    newY++;
                    break;
                case 'a':
                    newX--;
                    break;
                case 'd':
                    newX++;
                    break;
            }

            if (newX >= 0 && newX < MapSize && newY >= 0 && newY < MapSize && !IsObstacle(newX, newY))
            {
                robot.X = newX;
                robot.Y = newY;
            }
        }
    }
}