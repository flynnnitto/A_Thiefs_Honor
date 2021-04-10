using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private bool movingright = true;
    public Transform groundDetection;
    public Animator animator;
    public Vector2 movement;
    

    private void Update()
    {
        movement = Vector2.right * speed * Time.deltaTime;
        EnemyPatrolling();
        animator.SetFloat("Speed", Mathf.Abs(movement.x));
        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (groundinfo.collider == false)
        {
            if (movingright == true)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingright = false;

            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingright = true;
            }

        }
    }

    private void EnemyPatrolling()
    {
        if(GetComponent<Enemy>().IstakingDamage == true)
        {
            transform.Translate(Vector3.zero);
            animator.SetBool("Attacked", true);
            animator.SetFloat("Speed", 0);
        }

        else
        {
            transform.Translate(movement);
            animator.SetBool("Attacked", false);
        }
        
    }
}
