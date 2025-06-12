using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;


namespace Madu
{
    public class ScoreManager
    {
        private string filePath; //хранит путь к файлу
        private List<Score> scores; //хранит текущий список всех загруженных очков
        //путь для сохранения
        public ScoreManager()
        {
            string folder = @"C:\Users\User\source\repos\Madu\";
            filePath = Path.Combine(folder, "highscores.txt");

            scores = LoadScores();

        }
        // Загружает список очков из файла, если файл существует.
        public List<Score> LoadScores()
        {
            List<Score> scoreList = new List<Score>();
            if (!File.Exists(filePath)) return scoreList;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[1], out int scoreValue))
                {
                    scoreList.Add(new Score(parts[0], scoreValue));
                }
            }

            return scoreList;
        }
        // Сохраняет новое очко в файл и добавляет его в список.
        public void SaveScore(Score score)
        {
            scores.Add(score);
            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine($"{score.Name},{score.Value}");
                }
            }
            catch
            {
          
            }
        }
        // Выводит на экран все сохранённые очки, отсортированные по убыванию.
        public void DisplayScores()
        {
            if (scores.Count == 0)
            {
                Console.WriteLine("Not saves score.");
                return;
            }

            Console.WriteLine("Records:");
            foreach (var score in scores.OrderByDescending(s => s.Value))
            {
                Console.WriteLine($"{score.Name}: {score.Value}");
            }
        }
    }
}
