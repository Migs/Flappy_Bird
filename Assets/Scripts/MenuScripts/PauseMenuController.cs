using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class PauseMenuController : MonoBehaviour
{
    private void Awake()
    {
        GameManager.OnGameStateChanged += GamePaused;
        gameObject.SetActive(false);
    }

    private void GamePaused(GameState state)
    {
        switch (state) {
            case GameState.Paused:
                gameObject.SetActive(true);
                Time.timeScale = 0f;
                break;
            case GameState.Initiating:
                gameObject.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GamePaused;
    }
}
