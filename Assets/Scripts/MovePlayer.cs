using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private GameObject player;

    public float speed = 5F;

    [SerializeField] private float jump_power = 0.5f;

    private Rigidbody2D rb2;

    private bool isJumping = false;
    private int jump_counter = 0;
    private float jump_cd = 2f;
    private bool isOnCooldown = false;

    private bool IsFacingRight = true;
    private bool IsFlipped = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        if(rb2 == null)
            Debug.LogError("No rigidbody found");
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        if(hor != 0)
        {
            IsFacingRight = hor > 0;
            if (!IsFacingRight && !IsFlipped)
            {
                Flip();
            }
            else if (IsFacingRight && IsFlipped)
            {
                Flip();
            }
        }
        rb2.velocity = new Vector2(hor * speed, rb2.velocity.y);
    }

    private void Flip()
    {
        IsFlipped = !IsFlipped; 
        transform.rotation = Quaternion.Euler(0, IsFlipped ? 180 : 0, 0);
    }

    private void Jump()
    {
        if (isOnCooldown) return; 

        float vertical = Input.GetAxis("Vertical");

        if (vertical > 0.2f && !isJumping && jump_counter < 2)
        {
            rb2.velocity = new Vector2(rb2.velocity.x, jump_power);
            jump_counter++;
            isJumping = true;
            animator.SetBool("IsJumping", isJumping);

            if (jump_counter == 2)
            {
                StartCoroutine(JumpCooldown());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
        animator.SetBool("IsJumping", isJumping);
    }

    private IEnumerator JumpCooldown()
    {
        isOnCooldown = true; 
        yield return new WaitForSeconds(jump_cd);
        jump_counter = 0; 
        isOnCooldown = false; 
    }
}


