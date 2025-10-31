using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float life;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;
    private bool playerDetected;
    private Rigidbody2D rb;
    public Animator animator;
    public Transform player;
    public float stopDistance;
    public bool attacking;
    public bool IsDead;   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    public void Update()
    {
        if (IsDead == true)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }
        if (playerDetected == true && attacking == false)
        { 
            Vector3 distancia = player.position - transform.position;
           
            if (distancia.x > 0)//drch
            {
                rb.linearVelocity = speed * Vector2.right;
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else //izq
            {
                rb.linearVelocity = speed * Vector2.left;
                transform.eulerAngles = Vector3.zero;
            }

            Vector3 distance=player.position - transform.position;
            float distanceSQR = distance.sqrMagnitude;

            if (distanceSQR <= Mathf.Pow(stopDistance,2))
            { 
                attacking = true;
                rb.linearVelocity = Vector2.zero;
            }


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            
            Invoke("StartMoving", animator.GetCurrentAnimatorStateInfo(0).length);
            player = collision.transform;
            animator.SetTrigger("Alert");

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        
        }
                
    }



    private void StartMoving()
    {
        playerDetected = true;
        animator.SetBool("PlayerDetected", true);
    }

    public void TakeDamage(float _damage)
    {
        life -= _damage;
        if (life <= 0)
        {
            //Muelte
            animator.SetTrigger("Dead");
            rb.gravityScale = 0;
            GetComponent<Collider2D>().enabled = false;
            IsDead = true;
        }
        else
        {
            //Hit
            animator.SetTrigger("Hit");

        }
    
    
    }



}