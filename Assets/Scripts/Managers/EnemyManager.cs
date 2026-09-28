using UnityEngine;
using UnityEngine.Pool;

public class EnemyManager : MonoBehaviour
{
    public ObjectPool<GameObject> enemyPool;
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    private void Awake()
    {
        enemyPool = new ObjectPool<GameObject>(
            createFunc: NewEnemy,
            actionOnGet: GetEnemy,
            actionOnRelease: PoolEnemy,
            actionOnDestroy: DestroyEnemy,
            maxSize: 50
        );
    }

    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    void Spawn ()
    {
        if(playerHealth.playerInterface.Health <= 0f)
        {
            return;
        }

        enemyPool.Get();
    }

    private GameObject NewEnemy()
    {
        GameObject pooledEnemy = Instantiate(enemy);
        pooledEnemy.SetActive(false);
        pooledEnemy.GetComponent<EnemyHealth>().sourcePool = this;
        return pooledEnemy;
    }

    private void GetEnemy(GameObject pooledEnemy)
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Transform enemyTransform = pooledEnemy.transform;

        pooledEnemy.SetActive(true);
        enemyTransform.position = spawnPoints[spawnPointIndex].position;
        enemyTransform.rotation = spawnPoints[spawnPointIndex].rotation;
    }

    private void PoolEnemy(GameObject pooledEnemy)
    {
        pooledEnemy.SetActive(false);
    }

    private void DestroyEnemy(GameObject pooledEnemy)
    {
        Destroy(pooledEnemy);
    }
}
