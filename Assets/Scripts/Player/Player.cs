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
        [Range(0, 100)] public int maxHealth; // �ִ�ü��
         [Range(0.1f, 10f)] public float maxSpeed;// �ִ� �ӵ�
         [Range(1f, 100f)] public float damage; // �⺻ ���ݷ�
        [Range(0.1f, 2f)] public float attackRate;  // ���� ������
        [Range(1f,100f)] public float Criticalpercent;// ġ��Ÿ Ȯ�� // �̰� ���߿� �ð� ������ ����
    [Range(0.1f, 10f)] public float culAddAmount; // ȸ���ӵ�
    [Range(0.1f, 10f)] public float culDecreaseAmount; //���Ҽӵ�




}
