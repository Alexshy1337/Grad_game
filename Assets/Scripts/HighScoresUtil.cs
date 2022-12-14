using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectMUtils
{
    public class HighScoresUtil
    {
        public static List<HighscoreEntry> getScores()
        {
            string jsonString = PlayerPrefs.GetString("highscoreTable");
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
            if (highscores == null)
            {
                highscores = new Highscores()
                {
                    highscoreEntryList = new List<HighscoreEntry>()
                };
            }
            return highscores.highscoreEntryList;
        }

        static void SaveTable(List<HighscoreEntry> l)
        {
            Highscores h = new Highscores() { highscoreEntryList = l };
            string json = JsonUtility.ToJson(h);
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();
        }

        public static void AddScore(int score, string name)
        {
            HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
            List<HighscoreEntry>  highscores = getScores();
            if (highscores.Count >= 10)
            {
                if (highscores[9].score < highscoreEntry.score)
                    highscores.Add(highscoreEntry);
            }
            else
                highscores.Add(highscoreEntry);
            highscores.Sort();
            highscores.Reverse();
            if (highscores.Count > 10)
                highscores.RemoveAt(10);
            SaveTable(highscores);
        }

        class Highscores
        {
            public List<HighscoreEntry> highscoreEntryList;
        }

        [System.Serializable]
        public class HighscoreEntry: IComparable<HighscoreEntry>
        {
            public int score;
            public string name;
            public int CompareTo(HighscoreEntry obj)
            {
                return score.CompareTo(obj.score);
            }
        }
    }
}