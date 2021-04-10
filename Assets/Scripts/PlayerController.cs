using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpspeed = 100f;
    [SerializeField] Rigidbody2D Player_rb;
    [SerializeField] Animator animator;

    bool isGrounded = true;
    SpriteRenderer spriteRenderer;
    Vector2 movementVector;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Player_rb = GetComponent<Rigidbody2D>();
        
    }

   
    void Update()
    {
        float HorizontalMove = Input.GetAxis("Horizontal");
        transform.Translate(HorizontalMove * speed * Time.deltaTime, 0, 0);
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));
            spriteRenderer.flipX = false;

        }
        else if(Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetFloat("Speed", 0);

        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            Player_rb.AddForce(Vector3.up * jumpspeed, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }
    }


   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
    }
   
}
