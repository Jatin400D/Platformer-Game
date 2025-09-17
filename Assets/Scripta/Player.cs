using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float DeltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float DeltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;


        float newXpos = transform.position.x + DeltaX;  
        float newYpos = transform.position.y + DeltaY;  

        transform.position = new Vector3(newYpos, newXpos);

    }
}
