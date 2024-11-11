using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private string playerTag = "Player";
    public ObjectPool ObjectPool { get; private set; }
    public Transform Player { get; private set; }
    private float attackRange; // 공격 거리(범위)

    private int currentWaveIndex = 0; // 웨이브 단계
    private int currentSpawnCount = 0; // 현재 몬스터 숫자
    private int waveSpawnCount = 0;  // 웨이브 당 생성해야 할 몬스터 숫자
    private Transform spawnPosition; // 몬스터가 생성되는 위치 포인트
    public float spawnInterval = 0.5f; // 몬스터 생성 간격 시간
    public List<GameObject> enemyPrefebs = new List<GameObject>(); // 몬스터 종류를 담는 리스트 스테이지마다 변경할것?


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else Destroy(gameObject);

        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
       ObjectPool = GetComponent<ObjectPool>();
    }
}
