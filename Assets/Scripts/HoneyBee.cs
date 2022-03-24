using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyBee : MonoBehaviour
{

    private bool foundFlower = false;
    private Vector3 targetLocation;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotateSpeed = 700f;
    private Vector3 targetRotation;
    private NPCWander npcWander;


    // Start is called before the first frame update
    private void OnEnable()
    {
        foundFlower = false;
        npcWander = GetComponentInChildren<NPCWander>();
    }


    // Update is called once per frame
    void Update()
    {
        if (foundFlower)
        {
            npcWander.StopWander();
            GoToFlower();
        }
        if (!foundFlower)
        {
            npcWander.StartWander(moveSpeed, rotateSpeed);
        }

    }

    private void GoToFlower()
    {
        // Move our position a step closer to the target.
        float step = moveSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, targetLocation) < 0.001f)
        {
            // Swap the position of the cylinder.
            foundFlower = false;
        }

        Quaternion toRotation = Quaternion.LookRotation(targetLocation - transform.position, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
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
