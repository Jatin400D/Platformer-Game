using UnityEngine;

public class Crusher : EnemyDamage
{
    public Transform topPoint;     
    public Transform bottomPoint;  
    public float crushSpeed = 2f;  
    public float waitTime = 1f;    
    

    private Vector3 targetPosition;
    private bool movingDown = true;
    private float waitTimer = 0f;

    void Start()
    {
        targetPosition = bottomPoint.position;
    }

    void Update()
    {
        if (waitTimer > 0f)
        {
            waitTimer -= Time.deltaTime;
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, crushSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            waitTimer = waitTime;
            movingDown = !movingDown;
            targetPosition = movingDown ? bottomPoint.position : topPoint.position;
        }

    }

    
    


}
