using UnityEngine;

public class Switch : MonoBehaviour
{

    public GameObject Door;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Door.SetActive(false);
        }
    }
}
