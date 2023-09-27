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
    private float upDownSpeed; // Speed for moving up and down



    // Initialized speed, turnspeed, and rb before the first frame update
    void Start()
    {
        speed = 2200.0f;
        turnSpeed = 100.0f;
        rb = GetComponent<Rigidbody>();
        upDownSpeed = 500.0f;

        

    }

    // Update is called once per frame, slightly delayed 
    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * speed * verticalInput);
        if (Mathf.Abs(transform.rotation.y) < 0.26)
        {
            transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
        }
        
        //Scorekeeper.Instance.AddToScore(verticalInput);

        // Get input for moving up and down
        //float upDownInput = Input.GetAxis("VerticalUpDown");
        // Calculate up and down movement
        //float upDownForce = upDownInput * upDownSpeed * Time.deltaTime;
        //rb.AddRelativeForce(Vector3.up * upDownForce);

        float y = transform.rotation.y;
        int yInt = (int) (y * 180 / Mathf.PI);
        Debug.Log(yInt);

    }

    private void OnMove(InputValue inputValue)
    {
        verticalInput = inputValue.Get<Vector2>().y;
        horizontalInput = inputValue.Get<Vector2>().x;

    }

    public void StopMovement()
    {
        // Stop the player's movement by freezing the Rigidbody's constraints
        rb.constraints = RigidbodyConstraints.FreezeAll;
        // Optionally, you can also set the player's velocity to zero
        rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Energy"))
        {
            Scorekeeper.Instance.SubtractFromScore();
            Destroy(collision.gameObject);
        }
    }


}
