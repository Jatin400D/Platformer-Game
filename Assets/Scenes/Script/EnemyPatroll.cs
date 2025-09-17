using UnityEngine;

public class EnemyPatroll : MonoBehaviour
{


    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;


    [SerializeField] private Transform enemy;


    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool MovingLeft;


    [SerializeField] private float idleDuration;
    private float idleTimer;


    [SerializeField] private Animator anim;


    private void Update()
    {
        if (MovingLeft)
        {
            if (enemy.position.x >= pointA.position.x)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= pointB.position.x)
                MoveInDirection(1);

            else
            {
                DirectionChange();
            }
        }

    }

    private void OnDisable()
    {
        anim.SetBool("Walking", false);
    }
    private void DirectionChange()
    {

        anim.SetBool("Walking", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            MovingLeft = !MovingLeft;
    }





    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("Walking", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);


    }
}