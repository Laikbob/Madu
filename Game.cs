using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

    namespace Madu
    {
        class Game
        {
            private string playerName;
            private ScoreManager scoreManager;
            private string mode;

            private Sounds backgroundMusic = new Sounds();
            private Sounds effects = new Sounds();

            public Game(string playerName, ScoreManager scoreManager, string mode)
            {
                this.playerName = playerName;
                this.scoreManager = scoreManager;
                this.mode = mode;
            }

            public void ShowMenu()
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в игру!");
                Console.WriteLine("Нажмите Enter, чтобы начать...");

                backgroundMusic.PlaySound(@"C:\Users\User\source\repos\Madu\resources\background.mp3", loop: true);

                Console.ReadLine();
            }

        public void Run()
        {
            backgroundMusic.Stop();

            Console.Clear();
            Console.SetWindowSize(90, 25);
            Console.CursorVisible = false;

            Walls walls = new Walls(80, 25);

            walls.Draw();

            Point p = new Point(10, 10, '*');
            Snake snake = new Snake(p, 4, Derection.Right);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            int score = 0;

            while (true)
            {
                Console.SetCursorPosition(0, 0);

                if (walls.IsHit(snake) || snake.IsHitTail())
                    break;

                if (snake.Eat(food))
                {
                    score++;

                    if (mode == "hard" && score % 5 == 0)
                    {
                        walls.GenerateRandomWalls(1);
                        walls.Draw();
                    }

                    effects.PlaySound(@"C:\Users\User\source\repos\Madu\resources\eat.mp3");

                    Console.SetCursorPosition(0, 1);
                    Console.WriteLine($"Score: {score}   ");

                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }
            }

            effects.PlaySound(@"C:\Users\User\source\repos\Madu\resources\gameover.mp3");

            Console.Clear();
            Console.WriteLine("         Game Over!");
            Console.WriteLine($"        Final Score: {score}");

            // Вот здесь сохраняем результат
            scoreManager.SaveScore(new Score(playerName, score));
        }
    }
}