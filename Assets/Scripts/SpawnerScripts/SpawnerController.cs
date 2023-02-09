using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Management;
using Wall;


namespace Spawner
{
    public class SpawnerController : MonoBehaviour
    {

        bool isSpawnTime = true;
        private WallPool pool;

        private void Start()
        {
            pool = GetComponent<WallPool>();
        }

        // Update is called once per frame
        void Update()
        {
            if (isSpawnTime)
            {
                StartCoroutine(Spawn());
            }
        }

        IEnumerator Spawn()
        {
            isSpawnTime = false;
            GameObject newWall = pool.GetPooledObject();
            newWall.transform.position = new Vector2(transform.position.x, Random.Range(2, 8));
            newWall.SetActive(true);

            yield return new WaitForSeconds(10f / newWall.GetComponent<WallMovingScript>().GetMovementSpeed());
            isSpawnTime = true;
        }
    }
}
