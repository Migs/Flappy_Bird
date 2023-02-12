using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class CharacterController : MonoBehaviour
{

    float jumpDistance = 1f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && GameManager.Instance.State == GameState.Playing)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y+jumpDistance);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        else if(GameManager.Instance.State == GameState.GameOver)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        if (transform.position.y < -7)
        {
            transform.position = new Vector2(transform.position.x, -7);
            GameManager.Instance.UpdateGameState(GameState.GameOver);
        }
        if (transform.position.y > 7)
        {
            transform.position = new Vector2(transform.position.x, 7);
            GameManager.Instance.UpdateGameState(GameState.GameOver);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.UpdateGameState(GameState.GameOver);
    }
}
