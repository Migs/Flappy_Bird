using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using System;

public class GameOverScreenController : MonoBehaviour
{

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameState obj)
    {
        if(obj == GameState.GameOver) gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }

    void Start()
    {
        gameObject.SetActive(false);
    }
}
