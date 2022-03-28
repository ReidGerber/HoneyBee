using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCWander : MonoBehaviour
{
    [SerializeField] int minWanderRange = 5;
    [SerializeField] int maxWanderRange = 10;

    private float moveSpeed;
    private float rotateSpeed;
    private Vector3 targetLocation;
    HoneyBee honeyBee;


    private void Awake()
    {
        honeyBee = GetComponentInParent<HoneyBee>();
        moveSpeed = honeyBee.getMoveSpeed();
        rotateSpeed = honeyBee.getRotateSpeed();
    }

    private void OnEnable()
    {
        targetLocation = Vector3.zero; ;
    }


    // Update is called once per frame
    void Update()
    {

        if (targetLocation == Vector3.zero)
        {
            FindNewTarget();
        }
        // Move our position a step closer to the target.
        float step = moveSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (transform.position.x - targetLocation.x < 1f && transform.position.z - targetLocation.z < 1f)
        {
            targetLocation = Vector3.zero;
            //FindNewTarget();
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
        float magnitude = Random.Range(minWanderRange, maxWanderRange);
        Debug.Log("magnitude = " + magnitude);
        Vector3 newTarget = new Vector3(x, 0, z).normalized;
        newTarget = newTarget * magnitude;
        targetLocation = newTarget + transform.position;
    }
}
