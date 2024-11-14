using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public UiCondition uiCondition;
    [SerializeField] CharacterStatManager characterStatManager;
    [SerializeField] public TextMeshProUGUI hitBtn;
    [SerializeField] public TextMeshProUGUI autoBtn;
    [SerializeField] private Button upGradeViewButton; // 업그레이드 창 열기
    [SerializeField] private Button damageUpButton; // 데미지 업
    [SerializeField] private Button attackRateDownButton; // 공격 딜레이 감소
    [SerializeField] private GameObject upgradeUI;


    [SerializeField] private PlayerController controller;
    public PlayerUI LineClear { get { return uiCondition.lineClearUI; } }
    public PlayerUI Health { get { return uiCondition.healthUI; } }


    public float culAddAmount;
    public float culDecreaseAmount;
    
    


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else Destroy(gameObject);

        LineClear.currentGage = 0f;
        Health.currentGage += Health.maxGage;
        upGradeViewButton.onClick.AddListener(UpGradeView);
        damageUpButton.onClick.AddListener(OnClickDamageUp);
        attackRateDownButton.onClick.AddListener(OnClickAttackRateDown);
       

    }
    private void Start()
    {
        controller.hitMotion += () => LineClear.Add(culAddAmount);

        culAddAmount = CharacterStatManager.instance.currentStat.culAddAmount;
        culDecreaseAmount = CharacterStatManager.instance.currentStat.culDecreaseAmount;
        


    }

    private void Update()
    {
        
        LineClear.Decrease(culDecreaseAmount);
       
        BtnTxt();



    }
    private void BtnTxt()
    {
        Health.currentGageTxt.text = "Health Gage";
        LineClear.currentGageTxt.text = "LineClear Gage";
       
        if (controller.isAttacking == false)
        {
            hitBtn.text = "Wait ...";
        }
        else
        {
            hitBtn.text = "Hit !";
        }

    }
    private void UpGradeView()
    {
        if (!upgradeUI.activeSelf)
        {
            upgradeUI.SetActive(true);

        }
        else
        {
            upgradeUI.SetActive(false);
        }
    }
    private void OnClickDamageUp()
    {
        characterStatManager.DamageUp(1);
    }
    private void OnClickAttackRateDown()
    {
        characterStatManager.AttackRateDown(1);
    }
}


