using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatManager : MonoBehaviour
{
    public static CharacterStatManager instance; // �Ŵ��� ��ũ��Ʈ �̱���
    [SerializeField] private Player baseStat; // Player ��ũ��Ʈ���� ���� �޾ƿ��� , �ʱ� ����
    [SerializeField] private UiManager uiManager;
    public int buyCount = 1;
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

        price = buyCount * 100;
        MoneyCheck();
        if (MoneyCheck() == true)
        {
            currentStat.damage += amount;
            buyCount++;
        }
        else return;
           
    }
    public void AttackRateDown(float amount)
    {
        price = buyCount * 200;
        MoneyCheck();
        if(MoneyCheck() == true)
        {
            currentStat.attackRate -= amount;
            buyCount++;
        }
        else return;
       
       
    }
    private bool MoneyCheck()
    {
        if (uiManager.coin >= price)
        {
            return true;
        }
        return false;
       
        
    }


}
