using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumyController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float moveSpeed;
    private float attackRange = 1f;
    private float attackRate;
    private float lastAttackTime;
    public bool isAttacking = false;
    public LayerMask targetMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnumyMove();
    }

    private void EnumyMove()
    {
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, transform.right, attackRange, targetMask);
        if (hit2.collider == null)
        {
            //animator.SetBool("Walk", true);
            isAttacking = false;
            transform.position += Vector3.left * 0.1f * Time.deltaTime;

        }
        else
        {
            animator.SetBool("Walk", false);
            isAttacking = true;
            if (isAttacking && Time.time - lastAttackTime < attackRate)
            {
                animator.SetBool("Attack", true);
                // hit2.collider.GetComponent<IDamagable>().GetDamage(damage); // 몬스터 타격 주는 매서드 인터페이스로 구현 필요
            }
        }



    }
}
