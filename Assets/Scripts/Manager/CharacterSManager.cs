using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatManager : MonoBehaviour
{
    public static CharacterStatManager instance; // 매니저 스크립트 싱글톤
    [SerializeField] private Player baseStat; // Player 스크립트에서 정보 받아오기 , 초기 정보
    [SerializeField] private CoinManager coinManager;


    public int price = 100;
    public Player currentStat {  get; private set; } // 현재 정보
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else Destroy(gameObject);
        currentStat = baseStat;
     
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DamageUp(float amount)
    {
        int buyCount = 1;
        price = buyCount * 100;
        MoneyCheck();
        if (MoneyCheck() == true)
        {
            currentStat.damage += amount;
            coinManager.coin -= price;

            buyCount++;
        }
        else return;
           
    }
    public void AttackRateDown(float amount)
    {
        int buyCount = 1;
        price =  buyCount * 200;
        MoneyCheck();
        if(MoneyCheck() == true)
        {
            currentStat.attackRate -= amount;
            coinManager.coin -= price;
            buyCount++;
        }
        else return;
       
       
    }
    private bool MoneyCheck()
    {
        if ( coinManager.coin >= price)
        {
            return true;
        }
        return false;


    }


}
