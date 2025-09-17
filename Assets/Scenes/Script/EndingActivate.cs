using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingActivate : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.tag == "Player")
            {
                Invoke("SpawnDelay", 4);
            }
        }
    }

    public void SpawnDelay()
    {
      
        SceneManager.LoadScene("LOading2");
    }
}
