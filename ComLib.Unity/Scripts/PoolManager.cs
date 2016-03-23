using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ComLib.Unity.Scripts
{
    /// <summary>
    /// This is an edited version of the one in the link below.
    /// Original idea: http://www.alexmasse.com/blog/2016/3/5/objet-pooling-in-unity3d
    /// </summary>
    public class PoolManager : MonoBehaviour
    {
        //Singleton instance
        private static PoolManager instance;
        public static PoolManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<PoolManager>();
                }

                return instance;
            }
        }

        private Dictionary<string, List<Transform>> instantiatedObjects;

        void Start()
        {
            instantiatedObjects = new Dictionary<string, List<Transform>>();
        }

        /// <summary>
        /// Gets an object.
        /// </summary>
        public Transform GetPoolObject(Transform prefab)
        {
            Transform result = null;

            if (instantiatedObjects.ContainsKey(prefab.name))
            {
                List<Transform> existingObjects = instantiatedObjects[prefab.name];

                // Return a disabled item for re-use.
                foreach (Transform transform in existingObjects)
                {
                    if (transform.gameObject.activeInHierarchy == false)
                    {
                        result = transform;
                        break;
                    }
                }

                // If there is no disabled prefabs create a new one and add it to the pool.
                if (result == null)
                {
                    result = CeateNewObject(prefab);
                }
            }
            else
            {
                // There is no instances of the prefab. Must create a new one and add it to the pool manager.
                result = CeateNewObject(prefab);
            }

            result.gameObject.SetActive(true);
            return result;
        }

        /// <summary>
        /// Create a new prefab object.
        /// </summary>
        private Transform CeateNewObject(Transform prefab)
        {
            Transform newObject = (Transform)Transform.Instantiate(prefab);
            newObject.parent = transform;

            // If the pool contains a list of these prefabs add the new one to the list.
            if (instantiatedObjects.ContainsKey(prefab.name))
            {
                instantiatedObjects[prefab.name].Add(newObject);
            }
            else
            {
                List<Transform> newList = new List<Transform>();
                newList.Add(newObject);
                instantiatedObjects.Add(prefab.name, newList);
            }

            return newObject;
        }

        /// <summary>
        /// Resets all objects to disabled to reset everything back to normal.
        /// </summary>
        public void DisableAllObjectsInPool()
        {
            foreach (KeyValuePair<string, List<Transform>> keyValue in instantiatedObjects)
            {
                List<Transform> list = keyValue.Value;
                foreach (Transform obj in list)
                {
                    obj.gameObject.SetActive(false);
                }
            }
        }

    }
}
