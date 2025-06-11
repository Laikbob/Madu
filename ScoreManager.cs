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
        private string filePath;
        private List<Score> scores;

        public ScoreManager()
        {
            string folder = @"C:\Users\User\source\repos\Madu\";
            filePath = Path.Combine(folder, "highscores.txt");

            scores = LoadScores();

        }

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

        public void SaveScore(Score score)
        {
            scores.Add(score);
            try
            {
                File.AppendAllText(filePath, $"{score.Name},{score.Value}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка записи в файл: " + ex.Message);
            }
        }

        public void DisplayScores()
        {
            if (scores.Count == 0)
            {
                Console.WriteLine("Нет сохранённых очков.");
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
