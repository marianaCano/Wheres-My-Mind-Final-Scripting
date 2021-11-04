using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveHorizontal;
    float moveVertical;
    public float speed;
    Rigidbody2D rb2d;
    SpriteRenderer sr;
    Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Flip();
    }

    void Move()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = new Vector2(movement.x * speed, movement.y * speed);

        if (rb2d.velocity != Vector2.zero)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void Flip()
    {
        if (moveHorizontal < 0)
        {
            sr.flipX = true;
        }
        else if (moveHorizontal > 0)
        {
            sr.flipX = false;
        }
    }
}
