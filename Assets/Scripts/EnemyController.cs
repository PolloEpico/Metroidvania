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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    public void Update()
    {
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

    private void StartMoving()
    {
        playerDetected = true;
        animator.SetBool("PlayerDetected", true);
    }

}