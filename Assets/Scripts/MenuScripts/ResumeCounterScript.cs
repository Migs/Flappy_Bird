using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using TMPro;

public class ResumeCounterScript : MonoBehaviour
{
    TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameState state)
    {
        if (state == GameState.Initiating)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
            StartCoroutine("ResumeGame");
        }
    }

    void Start()
    {
        gameObject.SetActive(false);
        GameManager.Instance.UpdateGameState(GameState.Initiating);
    }

    IEnumerator ResumeGame()
    {
        int timeUntil = 3;
        text.text = timeUntil.ToString();
        yield return new WaitForSecondsRealtime(1);
        timeUntil--;
        text.text = timeUntil.ToString();
        yield return new WaitForSecondsRealtime(1);
        timeUntil--;
        text.text = timeUntil.ToString();
        yield return new WaitForSecondsRealtime(1);
        //Time.timeScale = 1f;
        GameManager.Instance.UpdateGameState(GameState.Playing);
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
