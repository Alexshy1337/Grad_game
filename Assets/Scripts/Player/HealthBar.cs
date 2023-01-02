using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ProjectMUtils;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public float maxValue = 100;
    public int regenValue = 15;
    public GameObject deathEffect, player, gameOverScreen, pauseMenu, spawners;
    public bool debugMode = false;
    public TMP_InputField inputField;
    public ScoreCounter scoreCounter;
    public Button saveScoreButton;
    private WeaponController weaponController;
    private static float current;
    private bool gameIsPaused = false;

    void Start()
    {
        slider.maxValue = maxValue;
        slider.minValue = 0;
        current = maxValue;
        StartCoroutine(Regenerate());
        weaponController = player.GetComponent<WeaponController>();
    }

    void Update()
    {
        if (current < 0) current = 0;
        if (current > maxValue) current = maxValue;
        slider.value = current;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        if(gameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Resume();
        }
        else //if game is running
        {
            if (Input.GetButtonDown("Fire2"))
                BuyGun();
            if (Input.GetKeyDown(KeyCode.Escape))
                Pause();
        }

    }

    IEnumerator Regenerate()
    {
        while (true)
        {
            current += regenValue;
            yield return new WaitForSeconds(1f);
        }
    }

    public void TakeDamage(int damage)
    {
        current -= damage;
        if(current <= 0)
        {
            StopAllCoroutines();
            current = 0;
            EndGame();
        }
    }

    private void BuyGun()
    {
        if (scoreCounter.totalmoney >= 500)
        {
            scoreCounter.SpendMoney(500);
            weaponController.GetNewGun();
        }
        else if (debugMode)
        {
            weaponController.GetNewGun();
        }
    }

    private void EndGame()
    {
        Instantiate(deathEffect, player.transform.position, player.transform.rotation);
        player.SetActive(false);
        gameOverScreen.SetActive(true);
        spawners.BroadcastMessage("endGame");
    }

    public void SaveScore()
    {
        int score = scoreCounter.totalScore;
        string name = inputField.text;
        inputField.interactable = false;
        saveScoreButton.interactable = false;
        HighScoresUtil.AddScore(score, name);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        player.SetActive(false);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        player.SetActive(true);
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}