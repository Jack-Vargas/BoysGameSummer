using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;
    public float baseSpeed;

    private float hor;
    private float vert;

    private Vector2 input;
    private float x;
    private float y;

    public float accel;
    public float addedIn;

    public int blockers;

    public float dashTime;
    public float dashForce;

    public int dashBlock;
    public float dashCooldown;

    public GameObject trail;
    public Gun gun;


    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        //DashAction.started += ctx => DashCheck();
        // DashAction.canceled += ctx => method(); 
        //the above comment is the get button up version
    }

    public void Move(InputAction.CallbackContext context)
    {
        //Debug.Log("should move");
        input = context.ReadValue<Vector2>();        
    }


    private void FixedUpdate()
    {
        if (blockers > 0)
        {
            return;
        }

        rb2d.linearVelocity = input * speed;        
    }

   

    public IEnumerator SpeedBoost(float boostSpeed, float boostTime)
    {
        speed += boostSpeed;
        yield return new WaitForSeconds(boostTime);
        speed -= boostSpeed;
    }
}
