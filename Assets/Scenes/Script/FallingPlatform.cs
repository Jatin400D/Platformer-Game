using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float fallwait = 2f;
    [SerializeField] private float Distroywait = 1f;

    bool isfalling;
    Rigidbody2D R2d;


    private void Start()
    {
        R2d = GetComponent<Rigidbody2D>();

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isfalling && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        isfalling = true;
        yield return new WaitForSeconds(fallwait);
        R2d.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, Distroywait);
    }


}
