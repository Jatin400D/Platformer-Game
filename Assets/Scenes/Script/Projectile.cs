using Unity.Mathematics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool Hit;


    private Animator anim;
    private BoxCollider2D BoxColider;
    private float direction;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        BoxColider = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        if (Hit) return;
        float moveentspeed = speed * Time.deltaTime * direction;
        transform.Translate(moveentspeed, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hit = true;
        BoxColider.enabled = false;
        anim.SetTrigger("Explode");
    }
    public void Setdirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        Hit = false;
        BoxColider.enabled = true;


        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;


        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}

