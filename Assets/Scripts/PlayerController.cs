using UnityEngine;
using UnityEngine.UIElements;

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
    [SerializeField]
    private float coldDown;
    private float passTime;

    public float mana;
    public float maxMana;
    [SerializeField]
    private float fireBallCost;
    private LevelManager levelManager;

    //Temporal
    private int maxJumps = 1;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

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
                if (coldDown <= passTime && GameManager.instance.GetGameData.PlayerMana >= fireBallCost)
                {
                    Instantiate(fireBallPrefab, spawnPoint.position, spawnPoint.rotation);
                    GameManager.instance.GetGameData.PlayerMana -= fireBallCost;
                    levelManager.UpdateMana();
                    passTime = 0;


                }
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

        passTime += Time.deltaTime;
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
            int comboAnimator = animator.GetInteger("Combo");
            if (comboCount > 0)
            {
                collision.gameObject.GetComponent<EnemyController>().TakeDamage(GameManager.instance.GetGameData.PlayerDamage);

            }
            else
            {
                collision.gameObject.GetComponent<EnemyController>().TakeDamage(GameManager.instance.GetGameData.BigAttackDamage);
            }


        }
    }
    public void TakeDamage(float _damage)
    {
        GameManager.instance.GetGameData.PlayerLife -= _damage;
        levelManager.UpdateLife();
        if (GameManager.instance.GetGameData.PlayerLife <= 0)
        {
            //muelte
            animator.SetTrigger("Dead");
            //Panel GameOver
        }
        else
        {
            //hit
            animator.SetTrigger("Hit");
        
        }


   
    }
}
