using UnityEngine;

public class temp2 : MonoBehaviour
{

    public class EnemyProjectile : MonoBehaviour
    {
        public float speed = 5f;
        public int damage = 10;

        void Update()
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                // other.GetComponent<PlayerHealth>()?.TakeDamage(damage);
                Debug.Log("Player hit by enemy projectile");
            }

            Destroy(gameObject);
        }
    }

}
