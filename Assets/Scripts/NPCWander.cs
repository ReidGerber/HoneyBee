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
        //CheckGroundHeight();
        transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (transform.position.x - targetLocation.x < 1f && transform.position.z - targetLocation.z < 1f)
        {
            targetLocation = Vector3.zero;
            //FindNewTarget();
        }

        Quaternion toRotation = Quaternion.LookRotation((targetLocation - transform.position), Vector3.up);
        toRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, toRotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
    }

    private void FindNewTarget()
    {
        float x = Random.Range(-100, 100);
        float z = Random.Range(-100, 100);
        float magnitude = Random.Range(minWanderRange, maxWanderRange);
        Vector3 newTarget = new Vector3(x, 0, z).normalized;
        newTarget = newTarget * magnitude;
        targetLocation = newTarget + transform.position;
    }
    //private void CheckGroundHeight()
    //{
    //    Debug.Log("ray");
    //    Ray ray = new Ray(transform.position, Vector3.down);
    //    RaycastHit hitInfo;
    //    if (Physics.Raycast(ray, out hitInfo))
    //    {
    //        Debug.Log("hit info = " + hitInfo.collider.tag.ToString());
    //        if (hitInfo.distance <= .5 && hitInfo.collider.tag == "Terrain")
    //        {
    //            // Move our position a step closer to the target.
    //            Vector3 vectorUp = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

    //            float step = moveSpeed * Time.deltaTime; // calculate distance to move
    //            transform.position = Vector3.MoveTowards(transform.position, vectorUp, step * 50);
    //        }
    //        if (hitInfo.distance >= 2.5 && hitInfo.collider.tag == "Terrain")
    //        {
    //            // Move our position a step closer to the target.
    //            Vector3 vectorDown = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);

    //            float step = moveSpeed * Time.deltaTime; // calculate distance to move
    //            transform.position = Vector3.MoveTowards(transform.position, vectorDown, step);
    //        }
    //    }
    //}
}
