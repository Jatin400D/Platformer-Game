using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{

    
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;


    [SerializeField] private Warrior Warrior;
    private bool invulnerable;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            
        }
        else
        {
            if (!dead)
            {

                if (currentHealth <= 0)
                {

                    anim.SetTrigger("Death");



                    Warrior.enabled = false;

                    dead = true;
                }
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    public void Respawn()
    {
        AddHealth(startingHealth);
        anim.ResetTrigger("Death");
        anim.Play("Idle");
        Warrior.enabled = true;
        dead = false;

    }
}
