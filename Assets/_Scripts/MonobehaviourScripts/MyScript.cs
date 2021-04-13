using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    public Light lightSource;

    // Start is called before the first frame update
    void Start()
    {
        lightSource.intensity = 5;
        lightSource.color = new Color(0, 1, 0);
        lightSource.type = LightType.Point;
        lightSource.range = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
