using UnityEngine;

public class TRapsEnemy : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField]private float MovementDistance;
    [SerializeField] private float speed;
    private bool movingLeft;
    private float LeftEdge;
    private float RightEdge;
    [SerializeField] private Health playerHealth;


    private void Awake()
    {
        LeftEdge = transform.position.x - MovementDistance;

        RightEdge = transform.position.x + MovementDistance;
    }


    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > LeftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = false;
        
       }

        else
        {
            if (transform.position.x < RightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = true;
        }

    }






    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<Health>().TakeDamage(damage);


       

    }







}
