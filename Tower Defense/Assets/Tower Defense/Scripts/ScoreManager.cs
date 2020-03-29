using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int lives = 20;
    public int coins = 100;
    public Text coinsText;
    public Text LivesText;
    public GameObject gameOverUI;
    public static bool GameIsOver;

    void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {
        if (GameIsOver)
        return;

        coinsText.text = "Coins $" + coins.ToString();
        LivesText.text = "Lives: " + lives.ToString();
    }

    public void LoseLife(int l = 1)
    {
        lives -= l;
        if(lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
    
} 

