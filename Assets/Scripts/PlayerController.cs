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
    private int comboCount;

    [SerializeField]
    private GameObject fireBallPrefab;
    [SerializeField]
    private Transform spawnPoint;


    //Temporal
    private int maxJumps = 1;
    public float mana;
    public float maxmana;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        //movimiento
        if (comboCount == 0)
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

            else if (horizontal > 0f)
            {
                transform.eulerAngles = Vector3.zero;
            }

            //salto
            if (Input.GetButtonDown("Jump") && JumpCount < maxJumps)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                JumpCount++;
            }

            CheckJump();

            if (Input.GetButtonDown("FireBall"))
            {
                Instantiate(fireBallPrefab, spawnPoint.position, spawnPoint.rotation);  
            
            }
        }

        else 
        {
         rb.linearVelocity = Vector2.zero;
        }


        //ataque
        if (JumpCount == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                comboCount = Mathf.Clamp(comboCount + 1, 0, 2);
                animator.SetInteger("Combo", comboCount);
            }

            if (Input.GetButtonDown("Fire2") && comboCount == 0)
            {
                animator.SetTrigger("bigAttack");
            }
        }

    }

    public void CheckCombo1()
    {
        if (comboCount < 2)
        {
            comboCount = 0;
            animator.SetInteger("Combo", comboCount);
        }
    }

    public void CheckCombo2()
    {
        
   
            comboCount = 0;
            animator.SetInteger("Combo", comboCount);
        
    }

    public void FinishBigAttack()
    {
        comboCount = 0;
            
    }

    

    void CheckJump()
    {
        Collider2D[] coliders = Physics2D.OverlapCircleAll(transform.position, groundDistance);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("muelto");
        }
    }
}
