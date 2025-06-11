using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Madu;

public class Menu
{
    private ScoreManager scoreManager;

    public Menu(string filePath)
    {
        scoreManager = new ScoreManager();
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
                    string playerName = AskPlayerName();
                    string mode = ChooseGameMode();
                    StartGame(playerName, mode);
                    break;
                case "2":
                    ViewHighScores();
                    break;
                case "3":
                    Console.WriteLine("Exiting the game...");
                    Console.WriteLine("Press any key to close...");
                    Console.ReadKey();
                    return false;
                default:
                    Console.WriteLine("Invalid option! Please select again.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }

    private string AskPlayerName()
    {
        Console.Clear();
        Console.Write("Enter your name: ");
        return Console.ReadLine();
    }

    private string ChooseGameMode()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose game mode:");
            Console.WriteLine("1. Simple (no walls)");
            Console.WriteLine("2. Hard (random walls)");
            Console.Write("Select mode (1 or 2): ");

            string modeChoice = Console.ReadLine();
            if (modeChoice == "1") return "simple";
            if (modeChoice == "2") return "hard";

            Console.WriteLine("Invalid choice. Try again.");
            Thread.Sleep(1000);
        }
    }

    public void Display()
    {
        Console.Clear();

        string title = "Welcome to Snake Game!";
        string[] options = {
        "1. Start Game",
        "2. View High Scores",
        "3. Exit"
    };

        int width = 50;
        string borderLine = new string('═', width);

        // Заголовок
        Console.WriteLine("╔" + borderLine + "╗");
        Console.WriteLine("║" + CenterText(title, width) + "║");
        Console.WriteLine("╠" + borderLine + "╣");

        // Опции меню
        foreach (var option in options)
        {
            Console.WriteLine("║" + CenterText(option, width) + "║");
        }

        Console.WriteLine("╚" + borderLine + "╝");
        Console.WriteLine();
        Console.Write("Select an option (1-3): ");
    }

    // Метод для центрирования текста по ширине
    private string CenterText(string text, int width)
    {
        if (text.Length >= width)
            return text.Substring(0, width);

        int leftPadding = (width - text.Length) / 2;
        int rightPadding = width - text.Length - leftPadding;
        return new string(' ', leftPadding) + text + new string(' ', rightPadding);
    }

    public void StartGame(string playerName, string mode)
    {
        Game game = new Game(playerName, scoreManager, mode);
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
