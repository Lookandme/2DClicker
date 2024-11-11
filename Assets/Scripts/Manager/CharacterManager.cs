using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance; // 매니저 스크립트 싱글톤
    [SerializeField] private Player baseStat; // Player 스크립트에서 정보 받아오기 , 초기 정보
    public Player currentStat {  get; private set; } // 현재 정보
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
