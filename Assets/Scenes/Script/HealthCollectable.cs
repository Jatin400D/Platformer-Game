using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
  [SerializeField]  private float HealthValue = 1f;
    [SerializeField] private AudioClip PickUp;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sOUNDmANAGER.instance.PlaySound(PickUp);
            collision.GetComponent<Health>().AddHealth(HealthValue);
            gameObject.SetActive(false);
        }
    }


}
