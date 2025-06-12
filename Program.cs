using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu
{
    class Program
    {   
        // логика выбора для меню
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

                Console.WriteLine("Select mode: ");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Hard");
                Console.Write("Your choice (1 or 2): ");
                string modeChoice = Console.ReadLine();

                string mode = modeChoice == "2" ? "hard" : "easy";  // по умолчанию — легкий режим

                Game game = new Game(playerName, new ScoreManager(), mode);
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