using UnityEngine;

public class pARALLAX : MonoBehaviour
{
    private Transform cam;
    [SerializeField]
    private float porcentaje;
    private Vector3 previousPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main.transform;
        previousPos = cam.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 loQueSeHaMovido = cam.position - previousPos;
        transform.Translate(loQueSeHaMovido * porcentaje);
        previousPos = cam.position;
    }
}
