using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
   
        public float speed = 2f;
        public float hoverAmplitude = 0.5f;
        public float hoverFrequency = 2f;
        public Transform pointA;
        public Transform pointB;
        public Transform player;
        public float followRange = 5f;

        private Vector3 nextPoint;
        private float startY;

        void Start()
        {
            nextPoint = pointB.position;
            startY = transform.position.y;
        }

        void Update()
        {
            Vector3 target = nextPoint;

            // Check distance to player
            if (player != null && Vector3.Distance(transform.position, player.position) < followRange)
            {
                target = player.position;
            }

            // Horizontal movement
            Vector3 newPos = Vector3.MoveTowards(transform.position, new Vector3(target.x, transform.position.y, transform.position.z), speed * Time.deltaTime);

            // Hovering effect on Y-axis
            float hoverY = startY + Mathf.Sin(Time.time * hoverFrequency) * hoverAmplitude;
            newPos.y = hoverY;

            transform.position = newPos;

            // Patrol logic
            if (Vector3.Distance(transform.position, pointA.position) < 0.1f)
                nextPoint = pointB.position;
            else if (Vector3.Distance(transform.position, pointB.position) < 0.1f)
                nextPoint = pointA.position;
        }
    }

