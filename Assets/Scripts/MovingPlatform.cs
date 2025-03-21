using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 2f;

    private Vector3 target;
    private Transform player;

    void Start()
    {
        target = pointA.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
        if(Vector3.Distance(transform.position,target)<0.1f)
        {
            if(target == pointA.position)
            {
                target = pointB.position;
            }
            else
            {
                target = pointA.position;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
