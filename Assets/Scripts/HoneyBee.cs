using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyBee : MonoBehaviour
{

    private bool foundFlower = false;
    private Vector3 targetLocation;
    [SerializeField] float speed;


    // Start is called before the first frame update
    private void OnEnable()
    {
        foundFlower = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (foundFlower)
        {
            GoToFlower();
        }

    }

    private void GoToFlower()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, targetLocation) < 0.001f)
        {
            // Swap the position of the cylinder.
            foundFlower = false;
        }
    }

    public void FoundFlower(Vector3 flowerTransform)
    {
        if (flowerTransform != null)
        {
            foundFlower = true;
            targetLocation = flowerTransform;
        }
    }

}
