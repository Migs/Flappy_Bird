using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Wall
{
    public class WallMovingScript : MonoBehaviour
    {
        public delegate void OnWallPass();
        public static event OnWallPass IncrementScore;

        private GameObject bird;

        bool givePoints = true;
        float movementSpeed = 7;

        void Start()
        {
            bird = GameObject.FindGameObjectWithTag("Bird");
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector2(transform.position.x - (movementSpeed)*Time.deltaTime, transform.position.y);

            if (givePoints)
            {
                if (transform.position.x <= bird.transform.position.x)
                {
                    givePoints = false;
                    if(IncrementScore != null)
                    {
                        IncrementScore();
                    }
                }
            }

            if (transform.position.x < -12)
            {
                givePoints = true;
                gameObject.SetActive(false);
            }
        }

        public float GetMovementSpeed()
        {
            return movementSpeed;
        }
    }

}
