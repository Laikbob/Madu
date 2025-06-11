using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madu;

class Menu
{
    private ScoreManager scoreManager;

    public Menu(string filePath)
    {
        scoreManager = new ScoreManager(filePath);
    }

    public bool HandleMenuChoice()
    {
        while (true)
        {
            Display();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return true;  // Игрок хочет играть
                case "2":
                    ViewHighScores();
                    break;
                case "3":
                    Console.WriteLine("Exiting the game...");
                    Console.WriteLine("Press any key to close...");
                    Console.ReadKey();
                    return false;  // Игрок выбрал выход
                default:
                    Console.WriteLine("Invalid option! Please select again.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("                                                  ");
        Console.WriteLine("                                                  ");
        Console.WriteLine("                                                  ");
        Console.WriteLine("           ============================           ");
        Console.WriteLine("//////////////////////////////////////////////////");
        Console.WriteLine("/           Welcome to Snake Game!               /");
        Console.WriteLine("/           1. Start Game                        /");
        Console.WriteLine("/           2. View High Scores                  /");
        Console.WriteLine("/           3. Exit                              /");
        Console.WriteLine("//////////////////////////////////////////////////");
        Console.WriteLine("          ============================            ");
        Console.Write("               Select an option (1-3):                ");
        Console.WriteLine("                                                  ");
        Console.WriteLine("                                                  ");
    }

    public void StartGame(string playerName)
    {
        Game game = new Game(playerName, scoreManager);
        game.Run();

        Console.Clear();
        Console.WriteLine("Game over! Press any key to return to the menu.");
        Console.ReadKey();
    }

    private void ViewHighScores()
    {
        Console.Clear();
        scoreManager.DisplayScores();
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }
}
