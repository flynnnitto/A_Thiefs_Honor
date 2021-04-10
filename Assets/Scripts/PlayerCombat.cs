using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Animator animator;
    public float attackRange = 0.5f;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public int attackDamage = 50;
  
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }


    void Attack()
    {
        animator.SetTrigger("IsAttacking");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        for(int i = 0; i< hitEnemies.Length; i++)
        {
            hitEnemies[i].GetComponent<Enemy>().TakeDamage(attackDamage);
            
        }

    }
    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        
    }
}
