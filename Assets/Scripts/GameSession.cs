using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score = 0;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject stopAndResumePanel;
    GamePersist gamePresist;
    void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
       
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
        gamePresist= FindObjectOfType<GamePersist>();
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            gameOverPanel.SetActive(true);
           // ResetGameSession();
        }
    }

    void TakeLife()
    {
        playerLives--;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        livesText.text = playerLives.ToString();
    }

    public void ResetGameSession()
    {
        gamePresist.ResetGamePersist();
        SceneManager.LoadScene(1);
        Destroy(gameObject);
    }

    public void Menu()
    {
        gamePresist.ResetGamePersist();
        gameOverPanel.SetActive(false);
        stopAndResumePanel.SetActive(false);
        SceneManager.LoadScene("Main Menu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        stopAndResumePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        stopAndResumePanel.SetActive(false);
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }
}
