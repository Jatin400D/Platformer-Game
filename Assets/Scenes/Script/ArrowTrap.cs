using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireblade;
    private float Cooldowntimer;


    private void attack()
    {
        Cooldowntimer = 0;
        fireblade[FindFireBlade()].transform.position = firepoint.position;
        fireblade[FindFireBlade()].GetComponent<BladeProjectile>().ActivateProjectile();

    }
    private int FindFireBlade()
    {
        for(int i = 0; i < fireblade.Length; i++)
        {
            if (!fireblade[i].activeInHierarchy)
                return i;
        }
        return 0;

    }
    private void Update()
    {
        Cooldowntimer += Time.deltaTime;

       
        if (Cooldowntimer >= attackCooldown)
            attack();

    }








}



