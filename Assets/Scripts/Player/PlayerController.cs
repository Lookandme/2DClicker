using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Button hitButton;
    private Rigidbody2D rb;
    private Animator animator;
    public Action hit;
    public float moveSpeed;
    private float attackRange = 1f;
    private float attackRate;
    private float lastAttackTime;
    public bool isAttacking = false;
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
        
    }
    private void FixedUpdate()
    {
        CharacterMove();
    }
    private void OnClick()
    {
        if(!isAttacking) return;
        else
        {
            animator.SetTrigger("Attack");
            hit?.Invoke();
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
            isAttacking = true;
            if (isAttacking && Time.time - lastAttackTime < attackRate)
            {
                lastAttackTime = Time.time;
                animator.SetBool("Attack", true);
                // hit2.collider.GetComponent<IDamagable>().GetDamage(damage); // ���� Ÿ�� �ִ� �ż��� �������̽��� ���� �ʿ�
            }
        }



    }
}