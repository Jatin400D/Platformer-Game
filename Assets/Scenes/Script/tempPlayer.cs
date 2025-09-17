using UnityEngine;

public class tempPlayer : MonoBehaviour
{
    private Rigidbody2D R2d;
   public float speedX, speedY;
    public float Movespeed;

    private void Start()
    {
        R2d = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
      speedX  = Input.GetAxis("Horizontal")*Movespeed;
      speedY = Input.GetAxis("Vertical")*Movespeed;

        R2d.linearVelocity = new Vector2(speedX, speedY);
        
    }
}
