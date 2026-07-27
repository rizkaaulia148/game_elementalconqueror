using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float speedjump;
    private Animator animator;
    public bool gron;
   
  
    public int jumpCounter;
    public int maxJump =2;
    public bool isJumpDisabled;
    private float horizontalInput;
 // Referensi ke skrip ChestScript



    /* [SerializeField] private float fallBoundary;
     // Posisi checkpoint terakhir
     public static Vector2 lastCheckPoint;*/

    [SerializeField] private float batasMinimum; // Batas kiri area permainan

  
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
      /* lastCheckPoint = transform.position;*/

    }

    private void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        float clampedX = Mathf.Max(transform.position.x, batasMinimum);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.12f, 0.12f, 0.12f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gron && !isJumpDisabled)
            {
                Jump();
            }
            else if (jumpCounter < maxJump  && !isJumpDisabled)
            {
                Jump();
                jumpCounter++;
            }
          
        }
       /* if (transform.position.y < fallBoundary )
        {
            Respawn();
        }*/

        animator.SetBool("walk", horizontalInput != 0);
        animator.SetBool("grounded", gron);



    }
    

    public void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speedjump);
        animator.SetTrigger("jump");
        gron = false;
    }

    public void DisableJump()
    {
        isJumpDisabled = true;
    }
    public void EnableJump()
    {
        isJumpDisabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box"))
        {
            gron = true;
            jumpCounter = 0; // Reset jumlah lompatan tambahan ketika menyentuh tanah atau kotak
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box"))
        {
            gron = false;
        }
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && gron;
    }

   

}
