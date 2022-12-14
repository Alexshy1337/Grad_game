using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ProjectMUtils;
using System.Collections.Generic;

public class MainMenuScript : MonoBehaviour
{
    public GameObject LeaderBoard, tutor;
    public Transform entryContainer;
    public Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        List<HighScoresUtil.HighscoreEntry> highscores = HighScoresUtil.getScores();
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighScoresUtil.HighscoreEntry highscoreEntry in highscores)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighScoresUtil.HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 31f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString = rank.ToString();

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        // Set background visible odds and evens, easier to read
        entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);

        // Highlight First
        if (rank == 1)
        {
            entryTransform.Find("posText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("scoreText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("nameText").GetComponent<Text>().color = Color.green;
        }
        transformList.Add(entryTransform);
    }

    private void Start()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowLeaders()
    {
        gameObject.SetActive(false);
        LeaderBoard.SetActive(true);
    }

    public void HideLeaders()
    {
        LeaderBoard.SetActive(false);
        gameObject.SetActive(true);
    }

    public void ShowTutor()
    {
        gameObject.SetActive(false);
        tutor.SetActive(true);
    }

    public void HideTutor()
    {
        tutor.SetActive(false);
        gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
