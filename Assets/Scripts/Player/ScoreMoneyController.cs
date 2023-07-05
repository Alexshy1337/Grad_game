using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMoneyController : MonoBehaviour
{
    public Text scoreLabel;
    public TextMeshProUGUI moneyLabel;
    public int totalScore = 0, totalmoney = 0;

    public void AddScore(int reward){
        totalScore += reward;
        totalmoney += reward;
        scoreLabel.text = "Очки: " + totalScore;
        moneyLabel.text = totalmoney + "$";
    }

    public void SpendMoney(int cost)
    {
        totalmoney -= cost;
        moneyLabel.text = totalmoney + "$";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            AddScore(500);
    }
}
