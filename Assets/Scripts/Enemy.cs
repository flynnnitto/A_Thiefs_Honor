using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public int MaxHealth = 100;
    private int currentHealth;
    public Animator animator;
    public GameObject bloodEffect;
    public bool IstakingDamage = false;
    void Start()
    {
        currentHealth = MaxHealth;
    }

    private void FixedUpdate()
    {
        if(currentHealth<=0)
        {
            Destroy(gameObject);
        }

       
    }
    public void TakeDamage(int damage)
    {
        //animator.SetTrigger("Hurt");
        IstakingDamage = true;
        
        currentHealth -= damage;
        Debug.Log("Enemy hit");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        Debug.Log("Ded enemy");
        

    }

    void Update()
    {
        
        
    }
}
