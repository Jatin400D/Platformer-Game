using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    public void Respawn()
    {
        playerHealth.Respawn(); 
        transform.position = currentCheckpoint.position; 

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            
            collision.GetComponent<Collider2D>().enabled = false;
            sOUNDmANAGER.instance.PlaySound(checkpoint);
        }
    }

}
