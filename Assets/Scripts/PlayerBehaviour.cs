using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private int movSpeed = 500, jumpForce = 7, jumpCount = 2;
    private float horizontal;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        PlayerMovement();
        PlayerDirection();
    }
    void PlayerMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            animator.SetBool("Jumping", true);

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount--;
        }
    }

    void PlayerDirection()
    {
        if (horizontal < 0)
        {
            sprite.flipX = true;
            animator.SetBool("Walking", true);
        }
        if (horizontal > 0)
        {
            sprite.flipX = false;
            animator.SetBool("Walking", true);
        }
        else if (horizontal == 0)
        {
            animator.SetBool("Walking", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("IsGrounded"))
        {
            jumpCount = 2;
            animator.SetBool("Jumping", false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * movSpeed * Time.deltaTime, rb.velocity.y);
    }
}
