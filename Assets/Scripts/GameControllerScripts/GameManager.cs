using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameManagement
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager Instance;

        public GameState State;

        public static event Action<GameState> OnGameStateChanged;

        void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            UpdateGameState(GameState.Initiating);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                switch (State) {
                    case GameState.Playing:
                        UpdateGameState(GameState.Paused);
                        break;
                    case GameState.Paused:
                        UpdateGameState(GameState.Initiating);
                        break;
                    default:
                        break;
                }
            }
        }

        public void UpdateGameState(GameState newState)
        {
            State = newState;

            switch (newState)
            {
                case GameState.Paused:
                    break;
                case GameState.Initiating:
                    break;
                case GameState.Playing:
                    HandlePlaying();
                    break;
                case GameState.GameOver:
                    HandleGameOver();
                    break;
                default:
                    //throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
                    break;
            }

            OnGameStateChanged?.Invoke(newState);
        }

        private void HandleGameOver()
        {
            Time.timeScale = 0f;
        }

        private void HandlePlaying()
        {
            Time.timeScale = 1f;
        }
    }


    public enum GameState
    {
        Paused,
        Initiating,
        Playing,
        GameOver
    }
}