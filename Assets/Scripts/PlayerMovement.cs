using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10;
    [SerializeField] float jumpSpeed;
    [SerializeField] float climbSpeed;
    [SerializeField] Vector2 deathKick = new Vector2();
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    

    float myGravityScale;
    Vector2 moveInput;
    Rigidbody2D rb;
    Animator animator;
    CapsuleCollider2D capsule;
    BoxCollider2D boxCollider;
    bool IsALife = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider2D>();
        myGravityScale = rb.gravityScale;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsALife) { return; }
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }

    void OnMove(InputValue value)
    {
        if (!IsALife) { return; }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!IsALife) { return; }
        if (!boxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (value.isPressed)
        {
            rb.velocity += new Vector2(0f, jumpSpeed);
        }

    }

    void OnFire()
    {
        if (!IsALife) { return; }

        //Instantiate(bullet, gun.position, transform.rotation * Quaternion.Euler(0f, 0f, transform.localScale.x * 90));
        Instantiate(bullet, gun.position, Quaternion.Euler(0,0,-90));

    }

    void Run()
    {
        Vector2 vector = new Vector2(moveInput.x * runSpeed, rb.velocity.y);
        rb.velocity = vector;

        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        animator.SetBool("IsRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void ClimbLadder()
    {
        if (!boxCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            rb.gravityScale = myGravityScale;
            animator.SetBool("IsClimbing", false);
            return;
        }

        Vector2 vector = new Vector2(rb.velocity.x, moveInput.y * climbSpeed);
        rb.velocity = vector;
        rb.gravityScale = 0;
        bool playerHasVerticalSpeed = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        animator.SetBool("IsClimbing", playerHasVerticalSpeed);
    }

    void Die()
    {
        if (capsule.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazard")))
        {
            IsALife = false;
            animator.SetTrigger("Dying");
            rb.velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }


}
