using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform PointA;
    [SerializeField] private Transform PointB;
    [SerializeField] private float Movespeed;

    private Vector3 NextPostion;


    private void Start()
    {
        NextPostion = PointB.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, NextPostion, Movespeed *Time.deltaTime);


        if(transform.position == NextPostion)
        {
            NextPostion = (NextPostion == PointA.position) ? PointB.position : PointA.position;
        }





    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        collision.transform.SetParent(transform);
        


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null
            );
    }



}
