using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public enum BossStates { Waiting, Jumping, Roar, Roll, Spikes, Tired, Dead }

    [Header("Variables Generales")]
    [SerializeField]
    private BossStates currentState;
    private Transform player;
    private Animator animator;

    [Header("Jumping")]
    [SerializeField]
    private float maxJump = 12.5f;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private float timeToJump;

    [Header("Waiting")]
    [SerializeField]
    private float WaitingTime;

    [Header("Roar")]
    [SerializeField]
    private GameObject escapatrajoPrefab;
    [SerializeField]
    private Transform escapatrajoSpawn;
    [SerializeField]
    private float timeSpawnEscapatrajo;

    [Header("Roll")]
    [SerializeField]
    private float timeToRoll;
    [SerializeField]
    private float colliderRoll;
    [SerializeField]
    private float rollSpeed;
    private bool collisioning;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //Temporal Testing
        currentState = BossStates.Roar;
        ChangeState();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeState()
    {
        switch (currentState)
        { 
            case BossStates.Waiting:
                StartCoroutine(WaitingCoroutine());
                break;
            case BossStates.Jumping:
                StartCoroutine( JumpCoroutine());
                break;
            case BossStates.Roar:
                StartCoroutine ( RoarCoroutine());
                break;
            case BossStates.Roll:
                StartCoroutine (RollCoroutine());
                break;
            case BossStates.Spikes:

                break;
            case BossStates.Tired:

                break;
            case BossStates.Dead:

                break;
            default:
                
                break;
        }
    
    }
    IEnumerator WaitingCoroutine()
    { 
    
        yield return new WaitForSeconds(WaitingTime);
        currentState = (BossStates)Random.Range(1, 5);
    }



    IEnumerator JumpCoroutine()
    {
        animator.SetBool("Jumping", true);
        yield return new WaitForSeconds(timeToJump);

        Vector2 puntoA = transform.position;
        float puntoBX = player.position.x;
        float puntoBY = maxJump;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * jumpSpeed;
            
            float posX = Mathf.Lerp(puntoA.x, puntoBX, t);
            float posY = puntoA.y + 4 * maxJump * t * (1 - t);

            

                transform.position = new Vector2(posX, posY);

            yield return null;
        }
        animator.SetBool("Jumping", false);
        currentState = BossStates.Waiting;

    }

    IEnumerator RoarCoroutine()
    {
        animator.SetBool("Roar", true);
       
        collisioning = false;

        yield return new WaitForSeconds(timeSpawnEscapatrajo);

        Instantiate(escapatrajoPrefab, escapatrajoSpawnPoint.positon, escapatrajoSpawnPoint.rotation);

        animator.SetBool("Roar", false);
        
        yield return new WaitForSeconds(timeSpawnEscapatrajo);
   
        currentState = BossStates.Waiting;
        ChangeState();
    
    }

    IEnumerator RollCoroutine()
    {
        animator.SetBool("Roll", true);
        yield return new WaitForSeconds(timeToRoll);
        CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
        float standarCollider = collider.size.x;
        collider.size = new Vector2 (colliderRoll, collider.size.y);

        while (collisioning == false)
        {
            transform.Translate(Vector3.left * rollSpeed * Time.deltaTime, Space.Self);
            yield return null;
        }
    }
}
