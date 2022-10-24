using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;

        public Pool(string newTag, GameObject newPrefab, int newSize)
        {
            tag = newTag;
            prefab = newPrefab;
            size = newSize;
        }
    }

    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionnary;

    #region Singleton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
        poolDictionnary = new Dictionary<string, Queue<GameObject>>();

    }
    #endregion
    // Start is called before the first frame update
    private void Start()
    {

    }

    public void SetUpPool()
    {
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; ++i)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionnary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionnary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " does not exist.");
            return null;
        }



        GameObject objectToSpawn = poolDictionnary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionnary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

}
