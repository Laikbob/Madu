using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "highscores.txt";

            Sounds backgroundMusic = new Sounds();
            backgroundMusic.PlaySound(@"C:\Users\User\source\repos\Madu\resources\background.mp3", loop: true);

            Menu menu = new Menu(filePath);

            bool wantsToPlay = menu.HandleMenuChoice();

            backgroundMusic.Stop();

            if (wantsToPlay)
            {
                Console.Write("Enter your name: ");
                string playerName = Console.ReadLine();

                Game game = new Game(playerName, new ScoreManager(filePath));
                game.Run();
            }
            else
            {
                Console.WriteLine("Exiting...");
                Thread.Sleep(1000);
            }
        }
    }
}