using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/* 
 * Component of Vehicle, controls the car based on player input.
 * 
 * Alexandra Collier-Lake
 * September 12, 2023
 */
public class PlayerController : MonoBehaviour
{
    private float speed; //holds forward movement of vehicle
    private float turnSpeed; //holds the turn speed of vehicle
    private float verticalInput; //gets a value [-1,1] from user key press up/down
    private float horizontalInput; //gets a value [-1,1] from user key press left/right
    private Rigidbody rb; //points to vehicle rigidbody component


    // Initialized speed, turnspeed, and rb before the first frame update
    void Start()
    {
        speed = 1000.0f;
        turnSpeed = 30.0f;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame, slightly delayed 
    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * speed * verticalInput);
        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);

    }

    private void OnMove(InputValue inputValue)
    {
        verticalInput = inputValue.Get<Vector2>().y;
        horizontalInput = inputValue.Get<Vector2>().x;

    }


}
