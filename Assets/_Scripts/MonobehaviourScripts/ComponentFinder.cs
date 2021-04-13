using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentFinder : MonoBehaviour
{
    private Light discoLight;
    private GameObject cube;
    private Camera discoCamera;

    public float cameraMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        FindLight();
        FindCube();
        FindCamera();
    }

    private void FindCamera()
    {
        discoCamera = FindObjectOfType<Camera>();

        /*if (Screen.currentResolution.width == 800)
            discoCamera.fieldOfView = 80;
        */

        Debug.Log(discoCamera.fieldOfView);
    }

    private void FindCube()
    {
        cube = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(cube.transform.position);
    }

    private void FindLight()
    {
        discoLight = GetComponent<Light>();
        Debug.Log(discoLight.color);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount % 40 == 0)
        {
            UpdateLight();
            UpdateCube();
        }

        UpdateCamera();
    }

    private void UpdateCamera()
    {
        discoCamera.transform.Translate(cameraMoveSpeed * Time.deltaTime, 0, 0);
        discoCamera.transform.LookAt(cube.transform);
    }

    private void UpdateCube()
    {
        cube.transform.localScale = new Vector3(1, Random.Range(1f, 1.5f), 1);
    }

    private void UpdateLight()
    {
        discoLight.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
