using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wall;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private void OnEnable()
    {
        WallMovingScript.IncrementScore += IncrementScore;
    }

    private void OnDisable()
    {
        WallMovingScript.IncrementScore -= IncrementScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncrementScore()
    {
        TextMeshProUGUI temp = GetComponent<TextMeshProUGUI>();

        temp.text = (int.Parse(temp.text) + 1).ToString();
    }
}
