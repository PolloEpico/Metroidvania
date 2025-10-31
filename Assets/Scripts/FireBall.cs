using UnityEngine;

public class FireBall : MonoBehaviour
{

    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    private Animator animator;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = speed * transform.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.transform.tag != "Player" && collision.transform.tag != "FireBall") 
        {
            animator.SetTrigger("Pum");
            speed=0;
            if(collision.transform.tag== "Enemy")
            {
                collision.gameObject.GetComponent<EnemyController>().TakeDamage(GameManager.instance.GetGameData.FireBallDamage);


            }
        }
    }

    public void DestroyBall()
    {
        Destroy(gameObject);
    
    }


}


