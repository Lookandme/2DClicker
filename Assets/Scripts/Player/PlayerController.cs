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
    private void Awake()
    {
        hitButton.onClick.AddListener(OnClick);
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.velocity = Vector2.right * CharacterStatManager.instance.currentStat.maxSpeed;
    }
    private void OnClick()
    {
        animator.SetTrigger("Attack");
        hit?.Invoke();
    }
}
