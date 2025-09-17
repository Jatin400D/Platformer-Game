using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float attackcooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int Damage;
    [SerializeField] private int MaxHeath = 100;
    private int CurremtHealth;
    [SerializeField] private BoxCollider2D boxcollider;
    [SerializeField] private LayerMask playerlayer;
    private float cooldowntimer = Mathf.Infinity;
    private Animator anim;
    [SerializeField] private AudioClip Attacks;


    private EnemyPatroll enemypatrol;
    private Health playerHealth;
   



    private void Start()
    {
        CurremtHealth = MaxHeath;
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemypatrol = GetComponentInParent<EnemyPatroll>();
    }

    private void Update()
    {
        cooldowntimer += Time.deltaTime;

        if (playerinsight())
        {
            if(cooldowntimer >= attackcooldown)
            {
                cooldowntimer = 0;
                anim.SetTrigger("Attack");
                sOUNDmANAGER.instance.PlaySound(Attacks);
            }
        }
        if (enemypatrol != null)
            enemypatrol.enabled = !playerinsight();
    }



    private bool playerinsight()
    {
        RaycastHit2D hit2D = Physics2D.BoxCast(boxcollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,new Vector3(  boxcollider.bounds.size.x * range ,     boxcollider.bounds.size.y, boxcollider.bounds.size.z)
             , 0, Vector2.left, 0, playerlayer);


        if (hit2D.collider != null)
            playerHealth = hit2D.transform.GetComponent<Health>();

        return hit2D.collider != null;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxcollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxcollider.bounds.size.x * range ,  boxcollider.bounds.size.y, boxcollider.bounds.size.z));
    }

    public void TakeDamage(int damage)
    {
        CurremtHealth -= damage;
        anim.SetTrigger("Hurt");

        if (CurremtHealth <= 0)
        {
            Die();
            Invoke("DeathEmd", 1);
        }
    }


    private void Die()
    {
        anim.SetBool("Dead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
        GetComponent<Enemy>().enabled = false;
        
    }
    
   private void DeathEmd()
    {
        gameObject.SetActive(false);
    }


    private void DamagePlayer()
    {
        if (playerinsight()  )
        {
            playerHealth.TakeDamage(Damage);
        }

      


    }














}
