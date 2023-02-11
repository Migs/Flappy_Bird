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
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
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
        text = GetComponent<TextMeshProUGUI>();
        gameObject.SetActive(false);

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
