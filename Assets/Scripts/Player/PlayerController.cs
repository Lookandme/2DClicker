using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public interface IOnDamage
{
    public void OnDamage(float damage);
}
public class PlayerController : MonoBehaviour, IOnDamage
{
    [SerializeField] private Button hitButton;
    [SerializeField] private Button autoButton;
    [SerializeField] private UiManager uiManager;
    private Rigidbody2D rb;
    private Animator animator;
    public Action hitMotion;
    public Action onDamage;
    public float moveSpeed;
    private float attackRange = 0.5f;
    private float attackRate;
    private float lastAttackTime = 0f;
    private float damage;
    public bool isAttacking = false;
    public bool isCoroutineRunning = false;
    public int attackCount = 1;
    public LayerMask targetMask;


    private void Awake()
    {
        hitButton.onClick.AddListener(OnHitClick);
        autoButton.onClick.AddListener(AutoClick);

        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();


    }
    private void Start()
    {
        moveSpeed = CharacterStatManager.instance.currentStat.maxSpeed;
        attackRate = CharacterStatManager.instance.currentStat.attackRate;
        damage = CharacterStatManager.instance.currentStat.damage;
    }
    private void FixedUpdate()
    {
        CharacterMove();
    }
    private void OnHitClick()
    {
        if (isAttacking)
        {
            animator.SetBool("GetDamage", false);
            animator.SetBool("Attack", true);
            hitMotion?.Invoke();
            attackCount += 1;

            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, transform.right, attackRange, targetMask);
            if (Time.time - lastAttackTime > attackRate)
            {
                isAttacking = true;
                lastAttackTime = Time.time;
                hit2.collider.GetComponent<IOnDamage>().OnDamage(damage);

            }
        }
       


    }
    private void AutoClick()
    {
        if (isCoroutineRunning)
        {
            uiManager.autoBtn.text = "Auto";
            StopCoroutine(nameof(Auto));
            isCoroutineRunning = false;



        }
        else
        {
            uiManager.autoBtn.text = "Playing ...";
           
            StartCoroutine(nameof(Auto));
            

           
        }
    }
    private IEnumerator Auto()
    {
        isCoroutineRunning = true;
        while (true) 
        {
            if (isAttacking)
            {
                OnHitClick();
               
                yield return new WaitForSeconds(attackRate); 
               
            }
            else
            {
                yield return null; 
            }
        }
    }
        private void CharacterMove()
        {
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, transform.right, attackRange, targetMask);
            if (hit2.collider == null)
            {
                isAttacking = false ;
                animator.SetBool("Walk", true);

                transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            }
            else
            {
                 isAttacking = true;
                animator.SetBool("Walk", false);



            }



        }
        public void OnDamage(float damage)
        {
            Debug.Log("hit");
        animator.SetBool("Attack", false);
        animator.SetBool("GetDamage",true);
            onDamage?.Invoke();                 // 나중에 추가 할 동작코드 있다면 구독      
            uiManager.Health.Decrease(damage);

            if (uiManager.Health.currentGage <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            animator.SetBool("Die", true);
        }


    
}
