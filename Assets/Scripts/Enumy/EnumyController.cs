using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumyController : MonoBehaviour, IOnDamage
{
    private Rigidbody2D rb;
    private Animator animator;
    public float maxHealth = 50f;
    public float currentHealth;
    public float moveSpeed;
    private float attackRate = 5f;
    private float lastAttackTime;
    public float damage = 5f;
   
    public LayerMask targetMask;
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        EnumyMove();
    }

    private void EnumyMove()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;




    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("Player"))
        {

            if (Time.time - lastAttackTime > attackRate)
            {
                lastAttackTime = Time.time;
                collision.collider.GetComponent<IOnDamage>().OnDamage(damage);
            }
                

            
        }

    }




        public void OnDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    
}