using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public int count = 10;
    public GameObject prefab;
    public GameObject[] rowObjects;
    public GameObject[] characterObjects;
    private float speed = 1f;

    void Start()
    {
        rowObjects = new GameObject[count];
        characterObjects = new GameObject[count];
        for(int i = 0; i < count; i++)
        {
            GameObject newObject = new GameObject("Objeto " + (i + 1));
            newObject.transform.position = new Vector3(0, 0, i);
            rowObjects[i] = newObject;

            float x = Random.Range(-5, 5);
            float z = Random.Range(-5, 5);
            GameObject character = Instantiate(prefab, new Vector3(x, 0, z), Quaternion.identity);
            characterObjects[i] = character;
        }
    }

    void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        for(int i = 0; i < count; i++)
        {
            Transform target = rowObjects[i].transform;
            //Update the position moving one step
            characterObjects[i].transform.position = Vector3.MoveTowards(characterObjects[i].transform.position, target.position, step);
            // Check the position of the characterObject and rowObjects are approximately equal.
            if (Vector3.Distance(transform.position, target.position) < 0.001f)
                target.position *= -1.0f;
        }
    }
}
