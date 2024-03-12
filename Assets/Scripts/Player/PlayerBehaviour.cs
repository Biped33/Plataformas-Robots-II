using UnityEngine;
public class PlayerBehaviour : MonoBehaviour{
    private int t_movSpeed = 400, t_jumpCount = 2, t_layerint = 3; 
    private float t_inputHorizontal, t_jumpForce = 30f, t_maxJumpForce = 35f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    void Start(){
        getComponents();
    }
    void Update(){
        playerJump();
        playerDirection();
    }
    private void FixedUpdate(){
        playerMovement();
    }
    private void OnCollisionEnter2D(Collision2D collision){
        playerCollisions(collision);
    }
    void getComponents(){
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void playerMovement(){
        t_inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(t_inputHorizontal * t_movSpeed * Time.deltaTime, rb.velocity.y);
    }
    void playerJump(){
        if (Input.GetKeyDown(KeyCode.Space) && t_jumpCount > 0){
            rb.AddForce(Vector2.up * t_jumpForce, ForceMode2D.Impulse);
            t_jumpCount--;
            animator.SetBool("Jumping", true);
        }
        if (rb.velocity.magnitude > t_maxJumpForce){
            rb.velocity = rb.velocity.normalized * t_maxJumpForce;
        }
    }
    void playerDirection(){
        if (t_inputHorizontal < 0){
            sprite.flipX = true;
            animator.SetBool("Walking", true);
        }
        if (t_inputHorizontal > 0){
            sprite.flipX = false;
            animator.SetBool("Walking", true);
        }
        else if (t_inputHorizontal == 0){
            animator.SetBool("Walking", false);
        }
    }
    void playerCollisions(Collision2D collision){
        if (collision.gameObject.layer == t_layerint){
            t_jumpCount = 2;
            animator.SetBool("Jumping", false);
        }
    }
}
