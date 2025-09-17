using UnityEngine;
using UnityEngine.Playables;

public class ActiVatiob : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playableDirector.Play();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
