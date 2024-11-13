using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public UiCondition uiCondition;
   [SerializeField] public TextMeshProUGUI score;
   

    [SerializeField]private PlayerController controller;
    public PlayerUI LineClear { get {  return uiCondition.lineClearUI; } }
    public PlayerUI Health { get { return uiCondition.healthUI; } }
     

    public float culAddAmount;
    public float culDecreaseAmount;
    public int currentCount;


    private void Awake()
    {
        instance = this;
        
        LineClear.currentGage = 0f;
        Health.currentGage += Health.maxGage;

    }
    private void Start()
    {
        controller.hitMotion += () => LineClear.Add(culAddAmount);

        culAddAmount = CharacterStatManager.instance.currentStat.culAddAmount;
        culDecreaseAmount = CharacterStatManager.instance.currentStat.culDecreaseAmount;

        Health.currentGageTxt.text = "Health Gage";
        LineClear.currentGageTxt.text = "LineClear Gage";
    }

        private void Update()
        {
            LineClear.Decrease(culDecreaseAmount);
        currentCount = controller.attackCount;
        score.text = $"Score: {(currentCount) * 100}"; // 점수가 일종의 재화 역할을 겸함

        }
    

}
