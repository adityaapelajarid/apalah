using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logicscript : MonoBehaviour
{
    public int PlayerScore;
    public Text scoreText;
    public UnityEngine.UI.Text highScoreText;
    private int highScore = 0;
    public GameObject gameOverScreen;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("SkorTertinggi", 0);
        highScoreText.text = "High Score :  " + highScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        PlayerScore = PlayerScore + scoreToAdd;
        scoreText.text = PlayerScore.ToString();

        if (PlayerScore > highScore)
        {
        highScore = PlayerScore;
        highScoreText.text = "High Score: " + highScore.ToString();
        PlayerPrefs.SetInt("SkorTertinggi", highScore);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
