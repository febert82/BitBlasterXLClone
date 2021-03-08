using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float defaultMovementSpeed;
    public float extraAccelerationSpeed;
    public float breakingFactor;
    public float defaultTurnSpeed;

    private void FixedUpdate()
    {
        float movementSpeed = this.defaultMovementSpeed;
        
        // boost
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movementSpeed += this.extraAccelerationSpeed;
        }

        // slow down
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movementSpeed *= this.breakingFactor;
        }

        this.transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);

        // turn left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.forward, this.defaultTurnSpeed * Time.deltaTime);
        }

        // turn right
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(-Vector3.forward, this.defaultTurnSpeed * Time.deltaTime);
        }
    }
}
