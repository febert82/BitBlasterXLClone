using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public Vector3 movementDirection;
    public float movementSpeed;

    private void FixedUpdate()
    {
        this.transform.Translate(this.movementDirection * this.movementSpeed * Time.deltaTime);
    }
}
