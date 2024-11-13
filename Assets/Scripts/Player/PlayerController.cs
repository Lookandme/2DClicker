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
    [SerializeField]private UiManager uiManager;
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
    public int attackCount = 1;
    public LayerMask targetMask;


    private void Awake()
    {
        hitButton.onClick.AddListener(OnClick);
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
        
    }
    private void Start()
    {
        moveSpeed = CharacterStatManager.instance.currentStat.maxSpeed;
        attackRate = CharacterStatManager.instance.currentStat.attackSpeed;
        damage = CharacterStatManager.instance.currentStat.damage;
    }
    private void FixedUpdate()
    {
        CharacterMove();
    }
    private void OnClick()
    {
        if(isAttacking)
        {
            animator.SetTrigger("Attack");
            hitMotion?.Invoke();
            attackCount += 1;
        }
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, transform.right, attackRange, targetMask);
        if (Time.time - lastAttackTime > attackRate)
        {
            isAttacking = true;
            lastAttackTime = Time.time;
            hit2.collider.GetComponent<IOnDamage>().OnDamage(damage);

        }


    }
    private void CharacterMove()
    {
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, transform.right, attackRange, targetMask);
        if (hit2.collider == null)
        {
            animator.SetBool("Walk", true);
            isAttacking = false;
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        }
        else
        {
            animator.SetBool("Walk", false);
           
            
            
        }



    }
    public void OnDamage(float damage)
    {
        Debug.Log("hit");
        animator.SetTrigger("GetDamage");
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
