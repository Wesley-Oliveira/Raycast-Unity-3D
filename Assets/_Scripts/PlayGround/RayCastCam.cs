using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastCam : MonoBehaviour
{
    public bool firstPerson;
    public Camera myCamera;
    public float shootForce;


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray;

            if(firstPerson)
            {
                ray = new Ray(myCamera.transform.position, myCamera.transform.forward); //Do centro da cam pra fps
            }
            else
            {
                ray = myCamera.ScreenPointToRay(Input.mousePosition); // De qualquer lugar da cam
            }

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if (raycastHit.rigidbody)
                {
                    raycastHit.rigidbody.AddForceAtPosition(ray.direction * shootForce, raycastHit.point);
                }
            }
        }
    }
}
