using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IA_Generated.Interface;

namespace IA_Generated.Models
{
    // Classe que representa o mapa do jogo
    public class Map
    {
        private ICell[,] cells;
        private Robot robot;

        public int Width { get; }
        public int Height { get; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            cells = new ICell[Width, Height];
            robot = new Robot(0, 0, 10, 3);
            InitializeMap();
        }

        public void InitializeMap()
        {
            // Preenche o mapa com espaços vazios
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    cells[x, y] = new Empty(x, y);
                }
            }

            // Adiciona joias
            AddJewel(new Jewel(2, 1, "Red"));
            AddJewel(new Jewel(3, 3, "Green"));
            AddJewel(new Jewel(4, 4, "Blue"));

            // Adiciona obstáculos
            AddObstacle(new Obstacle(1, 0, "Water"));
            AddObstacle(new Obstacle(3, 2, "Tree"));

            // Posiciona o robô
            PlaceRobot(robot.X, robot.Y);
        }

        public void AddJewel(Jewel jewel)
        {
            cells[jewel.X, jewel.Y] = jewel;
        }

        public void AddObstacle(Obstacle obstacle)
        {
            cells[obstacle.X, obstacle.Y] = obstacle;
        }

        public void PlaceRobot(int x, int y)
        {
            cells[x, y] = robot;
        }

        public void PrintMap()
        {
            Console.Clear();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    ICell cell = cells[x, y];
                    ConsoleColor backgroundColor = cell.GetBackgroundColor();
                    ConsoleColor foregroundColor = cell.GetForegroundColor();
                    string symbol = cell.GetSymbol();

                    Console.BackgroundColor = backgroundColor;
                    Console.ForegroundColor = foregroundColor;
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Energy: " + robot.Energy);
            Console.WriteLine("Bag: " + robot.BagCount + "/" + robot.BagSize);
        }

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public bool IsJewelAdjacent()
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    int newX = robot.X + dx;
                    int newY = robot.Y + dy;

                    if (IsValidPosition(newX, newY) && cells[newX, newY] is Jewel)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void CollectJewel()
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    int newX = robot.X + dx;
                    int newY = robot.Y + dy;

                    if (IsValidPosition(newX, newY) && cells[newX, newY] is Jewel)
                    {
                        Jewel jewel = (Jewel)cells[newX, newY];
                        robot.CollectJewel();
                        cells[newX, newY] = new Empty(newX, newY);
                        Console.WriteLine("Jewel collected: " + jewel.Type);
                    }
                }
            }
        }

        public void MoveRobot(string direction)
        {
            int newX = robot.X;
            int newY = robot.Y;

            switch (direction)
            {
                case "up":
                    newY--;
                    break;
                case "down":
                    newY++;
                    break;
                case "left":
                    newX--;
                    break;
                case "right":
                    newX++;
                    break;
            }

            if (IsValidPosition(newX, newY))
            {
                if (cells[newX, newY] is Empty)
                {
                    cells[robot.X, robot.Y] = new Empty(robot.X, robot.Y);
                    robot.Move(newX, newY);
                    cells[robot.X, robot.Y] = robot;
                }
                else if (cells[newX, newY] is Jewel)
                {
                    CollectJewel();
                    cells[robot.X, robot.Y] = new Empty(robot.X, robot.Y);
                    robot.Move(newX, newY);
                    cells[robot.X, robot.Y] = robot;
                }
                else if (cells[newX, newY] is Obstacle)
                {
                    Console.WriteLine("Obstacle encountered!");
                }

                if (IsJewelAdjacent())
                {
                    Console.WriteLine("Jewel nearby!");
                }
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }
        }
    }
}