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

        public ScoreManager(string filePath)
        {
            this.filePath = filePath;
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
                if (parts.Length == 2)
                {
                    string name = parts[0];
                    int scoreValue = int.Parse(parts[1]);
                    scoreList.Add(new Score(name, scoreValue));
                }
            }

            return scoreList;
        }

        public void SaveScore(Score score)
        {
            scores.Add(score);
            File.AppendAllText(filePath, $"{score.Name},{score.Value}\n");
        }

        public void DisplayScores()
        {
            Console.WriteLine("High Scores:");
            foreach (var score in scores.OrderByDescending(s => s.Value))
            {
                Console.WriteLine($"{score.Name}: {score.Value}");
            }
        }
    }
}