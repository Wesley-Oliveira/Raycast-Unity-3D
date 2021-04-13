using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed, turnSpeed;
    public Rigidbody playerRB;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(0, turnSpeed * Time.deltaTime * horizontal, 0);
        Vector3 targetMovement = transform.forward * moveSpeed * Time.deltaTime * vertical;
        playerRB.MovePosition(playerRB.position + targetMovement);
    }
}
