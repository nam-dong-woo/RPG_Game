using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{

    public static PoolingManager instance;

    Queue<GameObject> enemyQueue = new Queue<GameObject>();
    [SerializeField]
    private GameObject enemyPrefab;
    public int initCount = 5;
    public Transform spawnRegion;

    public void Awake()
    {
        instance = this;
        Initialize(initCount);
    }



    void Start()
    {
        for (int i = 0; i < initCount; i++)
        {
            GetObject();
        }
    }

    GameObject GetObject()
    {
        if (enemyQueue.Count > 0)
        {
            var obj = enemyQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.transform.position = GetRandomPosition();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            return null;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        enemyQueue.Enqueue(obj);

        Invoke("GetObject", 0.5f);
    }

    Vector3 GetRandomPosition()
    {
        if (spawnRegion == null)
            return Vector3.zero;

        Vector3 ceneter = spawnRegion.position;
        Vector3 scale = spawnRegion.localScale;
        
        float randX = Random.Range(ceneter.x - scale.x * 0.5f, ceneter.x + scale.x * 0.5f);
        float randy = Random.Range(ceneter.y - scale.y * 0.5f, ceneter.y + scale.y * 0.5f);
        float randZ = Random.Range(ceneter.z - scale.z * 0.5f, ceneter.z + scale.z * 0.5f);
        Vector3 randomposition = new Vector3(randX, randy, randZ);
        return randomposition;
    }


    void Initialize(int intitCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            enemyQueue.Enqueue(CreateNewEnemy());
        }
    }

    GameObject CreateNewEnemy()
    {
        var newEnemy = Instantiate(enemyPrefab);
        newEnemy.SetActive(false);
        newEnemy.transform.SetParent(transform);
        return newEnemy;
    }
}
