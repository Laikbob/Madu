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

        private Sounds backgroundMusic = new Sounds();
        private Sounds effects = new Sounds();

        public Game(string playerName, ScoreManager scoreManager)
        {
            this.playerName = playerName;
            this.scoreManager = scoreManager;
        }

        // Метод запуска меню — музыка играет
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в игру!");
            Console.WriteLine("Нажмите Enter, чтобы начать...");

            // Запускаем фоновую музыку
            backgroundMusic.PlaySound(@"C:\Users\User\source\repos\Madu\resources\background.mp3", loop: true);

            Console.ReadLine();
        }

        // Метод запуска самой игры — музыка выключается
        public void Run()
        {
            // Останавливаем фоновую музыку при старте игры
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
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    score++;

                    effects.PlaySound(@"C:\Users\User\source\repos\Madu\resources\eat.mp3");

                    Console.SetCursorPosition(0, 1);
                    Console.WriteLine($"Score: {score}");

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

            // Проиграть звук окончания игры
            effects.PlaySound(@"C:\Users\User\source\repos\Madu\resources\gameover.mp3");

            Console.Clear();
            Console.WriteLine("         Game Over!");
            Console.WriteLine($"        Final Score: {score}");
        }

        public void SaveScore(Score score)
        {
            scoreManager.SaveScore(score);
            Console.WriteLine("       Score saved successfully!");
        }
    }
}
