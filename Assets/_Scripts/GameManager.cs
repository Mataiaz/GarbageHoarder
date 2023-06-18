using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GameUI
{
    private GameObject mainPlayer;
    private void NewGame() {
        Time.timeScale = 1f;
        score = 0f;
        mainPlayer = GameObject.FindGameObjectWithTag("player");
        NewGameUI();
    }

    private void Start() {
        NewGame();
    }

    void Update() {
        if(mainPlayer.GetComponent<CharacterMovement>().health <= 0)
            GameOver();
        UI(score, mainPlayer.GetComponent<CharacterMovement>().health);
    }

    private void GameOver() {
        Time.timeScale = 0f;
        GameOverScreen();
    }
}
