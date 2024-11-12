using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ObjectPool ObjectPool { get; private set; }

    private int currentWaveIndex = 0; // 웨이브 단계
    private int currentSpawnCount = 0; // 현재 몬스터 숫자
    private int waveSpawnCount = 0;  // 웨이브 당 생성해야 할 몬스터 숫자
   [SerializeField] private Transform spawnPosition; // 몬스터가 생성되는 위치 포인트
    public float spawnInterval = 0.5f; // 몬스터 생성 간격 시간
    public List<GameObject> enemyPrefebs = new List<GameObject>(); // 몬스터 종류를 담는 리스트 스테이지마다 변경할것?


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

    void SpawnEnemyAtPosition(int posIdx)   // 다시 살펴 볼것!!
    {
        int prefabIdx = Random.Range(0, enemyPrefebs.Count);
        GameObject enemy = Instantiate(enemyPrefebs[prefabIdx], spawnPosition.position, Quaternion.identity);
        // 생성한 적에 OnEnemyDeath를 등록해요.
        // enemy.GetComponent<HealthSystem>().OnDeath += OnEnemyDeath; 아직 미구현
        currentSpawnCount++;
    }
}
