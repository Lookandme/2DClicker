using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatManager : MonoBehaviour
{
    public static CharacterStatManager instance; // �Ŵ��� ��ũ��Ʈ �̱���
    [SerializeField] private Player baseStat; // Player ��ũ��Ʈ���� ���� �޾ƿ��� , �ʱ� ����
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


}
