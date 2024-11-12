using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ObjectPool ObjectPool { get; private set; }

    private int currentWaveIndex = 0; // ���̺� �ܰ�
    private int currentSpawnCount = 0; // ���� ���� ����
    private int waveSpawnCount = 0;  // ���̺� �� �����ؾ� �� ���� ����
   [SerializeField] private Transform spawnPosition; // ���Ͱ� �����Ǵ� ��ġ ����Ʈ
    public float spawnInterval = 0.5f; // ���� ���� ���� �ð�
    public List<GameObject> enemyPrefebs = new List<GameObject>(); // ���� ������ ��� ����Ʈ ������������ �����Ұ�?


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else Destroy(gameObject);


        ObjectPool = GetComponent<ObjectPool>();
    }
    private void Start()
    {
        SpawnEnemyAtPosition(2);
    }
    private void Update()
    {
        
    }

    void SpawnEnemyAtPosition(int posIdx)   // �ٽ� ���� ����!!
    {
        int prefabIdx = Random.Range(0, enemyPrefebs.Count);
        GameObject enemy = Instantiate(enemyPrefebs[prefabIdx], spawnPosition.position, Quaternion.identity);
        // ������ ���� OnEnemyDeath�� ����ؿ�.
        // enemy.GetComponent<HealthSystem>().OnDeath += OnEnemyDeath; ���� �̱���
        currentSpawnCount++;
    }
}
