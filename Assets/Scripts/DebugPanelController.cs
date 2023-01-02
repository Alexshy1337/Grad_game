using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugPanelController : MonoBehaviour
{
    public Text label1;
    public TextMeshProUGUI pureTextLabel;
    public int totalScore = 0, totalmoney = 0;

    public void AddScore(int reward)
    {
        totalScore += reward;
        totalmoney += reward;
        label1.text = "Очки: " + totalScore;
        pureTextLabel.text = totalmoney + "$";
    }

    public void SpendMoney(int cost)
    {
        totalmoney -= cost;
        pureTextLabel.text = totalmoney + "$";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            AddScore(500);
        //if (Input.GetKeyDown(KeyCode.T))
            //removeCollision/disableTriggers/showVelocity
    }
}
