using UnityEngine;

public class EFireBall : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float Lifetime;
    private Animator anim;
    private bool Hit;
    private BoxCollider2D BoxColider;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        BoxColider = GetComponent<BoxCollider2D>();
    }
    public void ActivateProjectile()
    {
        Hit = false;
        Lifetime = 0f;
        gameObject.SetActive(true);
        BoxColider.enabled = true;

    }
    private void Update()
    {
        if (Hit) return;
        float moveentspeed = speed * Time.deltaTime;
        transform.Translate(moveentspeed, 0, 0);


        Lifetime += Time.deltaTime;
        if (Lifetime > resetTime)
            gameObject.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
       
        Hit = true;
            base.OnTriggerEnter2D(collision);
            BoxColider.enabled = false;

            if (anim != null)
                anim.SetTrigger("Explode");
            else
                gameObject.SetActive(false);

        
    }
   
    private void deactivate()
    {
        gameObject.SetActive(false);
    }


}

