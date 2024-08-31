using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject loseUI;
    public int score;
    public Text loseScoreText, winScoreText;
    public Text inGameScoreText;
    public GameObject winUI;

    private void Start()
    {
        inGameScoreText.gameObject.SetActive(true);
    }

    public void LevelEnd()
    {
        loseUI.SetActive(true);
        loseScoreText.text = "Your Score Is : " + score;
        inGameScoreText.gameObject.SetActive(false);
    }
    public void WinLevel()
    {
        winUI.SetActive(true);
        winScoreText.text = "Your Score Is : " + score;
        inGameScoreText.gameObject.SetActive(false);

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void StartApp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void AddScore(int pointValue)
    {
        score += pointValue;
        inGameScoreText.text = "Score : " + score; 
    }

    public void AppQuit()
    {
        Application.Quit();
    }
}
