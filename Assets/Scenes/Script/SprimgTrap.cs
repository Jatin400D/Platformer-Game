using UnityEngine;

public class SprimgTrap : MonoBehaviour
{
    public float BounceForce = 20f;
    [SerializeField] private AudioClip Bounce;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerBounce(collision.gameObject);
            sOUNDmANAGER.instance.PlaySound(Bounce);
        }
    }


    private void HandlePlayerBounce(GameObject Player)
    {
        Rigidbody2D Rb = Player.GetComponent<Rigidbody2D>();


        if (Rb)
        {
            Rb.linearVelocity = new Vector2(Rb.linearVelocity.x, 0f);

            Rb.AddForce(Vector2.up * BounceForce, ForceMode2D.Impulse);
        }



    }



}
