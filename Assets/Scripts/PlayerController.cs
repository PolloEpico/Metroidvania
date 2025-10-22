using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    private Animator animator;
    private int JumpCount;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float groundDistance;



    //Temporal
    private int maxJumps = 1;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();





    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(speed * horizontal, rb.linearVelocity.y);

        if (horizontal == 0f)
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }

        if (horizontal < 0f)
        { 
            transform.eulerAngles = new Vector3(0, 180, 0);
        
        }

        else if(horizontal > 0f)
        {
            transform.eulerAngles = Vector3.zero;
        }

        if (Input.GetButtonDown("Jump") && JumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            JumpCount++;
        }

        Collider2D[] coliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(0.67f, groundDistance), 0f);
        bool isGrounded = false;

        for (int i = 0; i < coliders.Length; i++)
        {
            if (coliders[i].transform.tag == "Ground")
            {
                isGrounded = true;
            
            }
        
        }
        if (isGrounded == true)
        { 
            JumpCount = 0;
            animator.SetBool("jump", false);
            
        
        }
        else
        {
            animator.SetBool("jump", true);
            

            if (JumpCount == 0)
            { 
                JumpCount++;

            }
        }



    }

}
