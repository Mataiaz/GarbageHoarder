using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : GameStats
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject gameUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    protected void NewGameUI() {
        if(gameUI) gameUI.SetActive(true);
        if(pauseMenu) pauseMenu.SetActive(false);
        if(gameOverMenu) gameOverMenu.SetActive(false);
    }

    protected void UI(float score, float health) {
        if(scoreText) scoreText.text = "Garbage Collected: "+score.ToString();
        if(healthText) healthText.text = "HP: "+health.ToString();
    }
    protected void GameOverScreen() {
        if(gameOverMenu) gameOverMenu.SetActive(true);
    }
}
