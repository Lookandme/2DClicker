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
    private void Awake()
    {
        hitButton.onClick.AddListener(OnClick);
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Start()
    {
        moveSpeed = CharacterStatManager.instance.currentStat.maxSpeed;
        
    }
    private void FixedUpdate()
    {
        CharacterMove();
    }
    private void OnClick()
    {
        animator.SetTrigger("Attack");
        hit?.Invoke();
    }
    private void CharacterMove()
    {

        transform.position += Vector3.right * moveSpeed * Time.deltaTime; 


    }
}
