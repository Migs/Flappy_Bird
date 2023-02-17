using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapController : MonoBehaviour
{

    [SerializeField] Sprite[] _birdAnimations;
    Rigidbody2D _fallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _fallSpeed = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _birdAnimations[1];
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _birdAnimations[0];
        }
    }
}
