using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Temp1 : MonoBehaviour

{
    public float Falleait = 2f;
    public float DistroyWait = 1f;

    private bool isfalling;
    private Rigidbody2D R2d;
    private Vector3 InititalPosition;

    private void Start()
    {
        R2d = GetComponent<Rigidbody2D>();
        InititalPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isfalling && collision.collider.CompareTag("Player"))
        {
            isfalling = true;
            Invoke("Fall", Falleait);

        }
    }
    private void Fall()
    {
       
        R2d.bodyType = RigidbodyType2D.Dynamic;
        Invoke("ResetPlatform", 2f);
    }

    private void ResetPlatform()
    {
        R2d.bodyType = RigidbodyType2D.Kinematic;
        R2d.linearVelocity = Vector2.zero;
        R2d.angularVelocity = 0f;
        transform.position = InititalPosition;
        isfalling = false;
    }




}





