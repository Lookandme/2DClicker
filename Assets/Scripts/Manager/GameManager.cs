using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private string playerTag = "Player";
    public ObjectPool ObjectPool { get; private set; }
    public Transform Player { get; private set; }
    private float attackRange; // ���� �Ÿ�(����)

    private int currentWaveIndex = 0; // ���̺� �ܰ�
    private int currentSpawnCount = 0; // ���� ���� ����
    private int waveSpawnCount = 0;  // ���̺� �� �����ؾ� �� ���� ����
    private Transform spawnPosition; // ���Ͱ� �����Ǵ� ��ġ ����Ʈ
    public float spawnInterval = 0.5f; // ���� ���� ���� �ð�
    public List<GameObject> enemyPrefebs = new List<GameObject>(); // ���� ������ ��� ����Ʈ ������������ �����Ұ�?


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
