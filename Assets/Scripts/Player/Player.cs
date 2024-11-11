using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public enum StatsChangeType
    {
        Add, // ������
        Multiple, // ������
        Override, // �ش��ġ�� �ٷ� ���� �� ��쿡�� ȿ���ð��� ���� �ο��Ұ�
    }
[Serializable]
public class Player
{ 

        public StatsChangeType statsChangeType;
        [Range(1, 100)] public int maxHealth; // �ִ�ü��
         [Range(1, 100)] public float maxSpeed;// �ִ� �ӵ�
         [Range(1, 100)] public float damage; // �⺻ ���ݷ�
        [Range(1f, 20f)] public float attackSpeed;  // ���� �ӵ�
        [Range(1f,100f)] public float Criticalpercent; // ġ��Ÿ Ȯ�� // �̰� ���߿� �ð� ������ ����
       
    
}
