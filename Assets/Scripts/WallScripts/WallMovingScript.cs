using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Wall
{
    public class WallMovingScript : MonoBehaviour
    {
        public delegate void OnWallPass();
        public static event OnWallPass IncrementScore;
        WallStatsScriptableObject _wallStats;

        private GameObject bird;

        bool givePoints = true;

        void Start()
        {
            bird = GameObject.FindGameObjectWithTag("Bird");
            _wallStats = ScriptableObject.CreateInstance<WallStatsScriptableObject>();
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector2(transform.position.x - (WallStatsScriptableObject._movementSpeed)*Time.deltaTime, transform.position.y);

            if (givePoints)
            {
                if (transform.position.x <= bird.transform.position.x)
                {
                    givePoints = false;
                    if(IncrementScore != null)
                    {
                        IncrementScore();
                        _wallStats.IncreaseMovementSpeed();
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
            return WallStatsScriptableObject._movementSpeed;
        }
    }

}
