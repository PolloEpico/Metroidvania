using UnityEngine;

public class LanzaPeter : MonoBehaviour
{
    [SerializeField]
    private float speed;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime, Space.Self );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Duele
            Debug.Log("duele");
        
        }
        Destroy(gameObject);

    }

}
