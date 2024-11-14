using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public UiCondition uiCondition;
    [SerializeField] CharacterStatManager characterStatManager;
    [SerializeField] public TextMeshProUGUI score;
    [SerializeField] public TextMeshProUGUI hitBtn;
    [SerializeField] public TextMeshProUGUI autoBtn;
    [SerializeField] private Button upGradeViewButton; // ���׷��̵� â ����
    [SerializeField] private Button damageUpButton; // ������ ��
    [SerializeField] private Button attackRateDownButton; // ���� ������ ����
    [SerializeField] private GameObject upgradeUI;


    [SerializeField] private PlayerController controller;
    public PlayerUI LineClear { get { return uiCondition.lineClearUI; } }
    public PlayerUI Health { get { return uiCondition.healthUI; } }


    public float culAddAmount;
    public float culDecreaseAmount;
    public int currentCount;
    public int coin;


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
        coin = currentCount *= 100;
        LineClear.Decrease(culDecreaseAmount);
        currentCount = controller.attackCount;
        BtnTxt();



    }
    private void BtnTxt()
    {
        Health.currentGageTxt.text = "Health Gage";
        LineClear.currentGageTxt.text = "LineClear Gage";
        score.text = $"Current Coin: {coin}"; // ������ ������ ��ȭ ������ ���� // �� �κ��� �и��ؾ� �� �κ�
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


