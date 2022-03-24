using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCWander : MonoBehaviour
{
    private bool shouldWander;
    private float moveSpeed;
    private float rotateSpeed;
    private Vector3 targetLocation;
    [SerializeField] int minMagnitude = 5;
    [SerializeField] int maxMagnitude = 10;



    private void Awake()
    {
        shouldWander = false;
        targetLocation = transform.position;
    }


    // Update is called once per frame
    void Update()
    {


        if (shouldWander)
        {
            Wander();
        }
    }

    private void Wander()
    {

        if (targetLocation == transform.position)
        {
            FindNewTarget();
        }
        // Move our position a step closer to the target.
        float step = moveSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (transform.position.x - targetLocation.x < 1f && transform.position.z - targetLocation.z <1f)
        {
            targetLocation = transform.position;
        }

        Quaternion toRotation = Quaternion.LookRotation((targetLocation - transform.position), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
    }


    private void FindNewTarget()
    {

        float x = Random.Range(-100, 100);
        Debug.Log("x = " + x);
        float z = Random.Range(-100, 100);
        Debug.Log("z = " + z);
        float magnitude = Random.Range(minMagnitude, maxMagnitude);
        Debug.Log("magnitude = " + magnitude);
        Vector3 newTarget = new Vector3(x, 0, z).normalized;
        newTarget = newTarget * magnitude;

        targetLocation = newTarget + transform.position;
    }

    public void StartWander(float ms, float rs)
    {
        moveSpeed = ms;
        rotateSpeed = rs;
        shouldWander = true;
    }

    public void StopWander()
    {
        shouldWander = false;
        targetLocation = transform.position;
    }
}
