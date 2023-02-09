using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Management
{
    public class WallPool : MonoBehaviour
    {

        public static WallPool SharedInstance;
        public List<GameObject> pooledObjects;
        public GameObject objectToPool;
        public int amountToPool;

        private void Awake()
        {
            SharedInstance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            pooledObjects = new List<GameObject>();
            GameObject temp;

            for (int i = 0; i < amountToPool; i++)
            {
                temp = Instantiate(objectToPool);
                temp.SetActive(false);
                pooledObjects.Add(temp);
            }
        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < amountToPool; ++i)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }

            return null;
        }
    }
}
