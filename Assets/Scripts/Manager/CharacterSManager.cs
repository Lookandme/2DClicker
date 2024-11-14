using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatManager : MonoBehaviour
{
    public static CharacterStatManager instance; // �Ŵ��� ��ũ��Ʈ �̱���
    [SerializeField] private Player baseStat; // Player ��ũ��Ʈ���� ���� �޾ƿ��� , �ʱ� ����
    [SerializeField] private CoinManager coinManager;


    public int price = 100;
    public Player currentStat {  get; private set; } // ���� ����
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
