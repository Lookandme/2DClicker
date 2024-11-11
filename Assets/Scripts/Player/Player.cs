using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public enum StatsChangeType
    {
        Add, // 가연산
        Multiple, // 곱연산
        Override, // 해당수치에 바로 도달 이 경우에는 효과시간을 따로 부여할것
    }
[Serializable]
public class Player : MonoBehaviour
{

        public StatsChangeType statsChangeType;
        [Range(0, 100)] public int maxHealth; // 최대체력
         [Range(0, 100)] public float maxSpeed;// 최대 속도
         [Range(0, 100)] public float damage; // 기본 공격력
        [Range(0f, 20f)] public float attackSpeed;  // 공격 속도
        [Range(0f,100f)] public float Criticalpercent; // 치명타 확률 // 이건 나중에 시간 남으면 구현
       
    
}
