using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;

    public Rigidbody playerRB;
    public int jumpForce;
    public LayerMask layerMask;
    public float rayForce = 100f;
    public float rayDistance = 8f;
    public Transform rayOrigin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Debug.DrawRay(rayOrigin.position, rayOrigin.forward * rayDistance, Color.red, 0.01f);
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, rayDistance, layerMask))
        {
            if(hitInfo.rigidbody != null)
            {
                //hitInfo.rigidbody.AddForce(transform.forward * 100);
                hitInfo.rigidbody.AddForceAtPosition(rayOrigin.forward * rayForce, hitInfo.point);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(0, turnSpeed * Time.deltaTime * horizontal, 0);
        Vector3 targetMovement = transform.forward * moveSpeed * Time.deltaTime * vertical;
        
        playerRB.MovePosition(playerRB.position + targetMovement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Colidir"))
        {
            Debug.Log("Começou a colidir");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Colidir"))
        {
            Debug.Log("Está a colidindo");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Colidir"))
        {
            Debug.Log("Cabou de colidir");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.CompareTag("Gatilho"))
        {
            Debug.Log("Começou a colidir");
            Destroy(collider.gameObject);
        }
        else if (collider.transform.CompareTag("Jump"))
        {
            playerRB.AddForce(0, jumpForce, 0);
        }
    }

    private void OnTriggerEnterStay(Collider collider)
    {
        if (collider.transform.CompareTag("Gatilho"))
        {
            Debug.Log("Está a colidindo");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.transform.CompareTag("Gatilho"))
        {
            Debug.Log("Cabou de colidir");
        }
    }
}
