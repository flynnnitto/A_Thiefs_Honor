using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int MaxHealth = 100;
    private int currentHealth;
    public Animator animator;
    void Start()
    {
        currentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Hurt");
        currentHealth -= damage;
        

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("IsDead", true);
        Debug.Log("hit enemy");
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }

    void Update()
    {
        
        
    }
}
