using UnityEngine;

public class Bytigger : MonoBehaviour
{
    private Collider2D Collider;
    [SerializeField] private BOSS boss;
    [SerializeField] private BoxCollider2D boxcollider;

    private void Awake()
    {
        boxcollider.GetComponent<BoxCollider2D>();

    }
      

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { boss.Death(); }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { boss.Death(); }
    }
}
