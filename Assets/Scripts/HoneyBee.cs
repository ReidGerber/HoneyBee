using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HoneyBee : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotateSpeed = 700f;
    
    private Vector3 targetRotation;
    private Vector3 targetLocation;
    private bool foundFlower = false;
    private Pollen pollenFlower;

    //Sub components
    Animator animator;
    BeeRange beeRange;
    NPCWander npcWander;
    PollenCollector pollenCollector;

    internal Pollen GetPollenObject()
    {
        return pollenFlower;
    }

    //bee states 
    private int beeState;

    //sharing variables
    internal float getMoveSpeed()
    {
        return moveSpeed;
    }
    internal float getRotateSpeed()
    {
        return rotateSpeed;
    }



    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        beeRange = GetComponentInChildren<BeeRange>();
        npcWander = GetComponentInChildren<NPCWander>();
        pollenCollector = GetComponentInChildren <PollenCollector>();
    }



    private void OnEnable()
    {

        
    }


    // Update is called once per frame
    void Update()
    {

        switch (beeState)
        {

            case 3: //harvest flower
                animator.SetBool("isMoving", false);
                pollenCollector.enabled = true;
                break;
            case 2: //found flower
                beeRange.enabled = false;
                npcWander.enabled = false;
                GoToFlower();
                break;
            case 1: //wander
                beeRange.enabled = true;
                npcWander.enabled = true;
                pollenCollector.enabled = false;
                animator.SetBool("isMoving", true);
                break;
            default:
                beeRange.enabled = false;
                npcWander.enabled = false;
                pollenCollector.enabled = false;
                animator.SetBool("isMoving", false);
                break;
        }

    }

    private void GoToFlower()
    {
        // Move our position a step closer to the target.
        float step = moveSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (transform.position.x -  targetLocation.x < 0.001f && transform.position.z - targetLocation.z < 0.001f)
        {
            // Swap the position of the cylinder.
            targetLocation = transform.position;
            beeState = 3;
        }

        Quaternion toRotation = Quaternion.LookRotation(targetLocation - transform.position, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
    }

    public void FoundFlower(Vector3 flowerTransform, Pollen other)
    {
        if (flowerTransform != null)
        {
            pollenFlower = other;
            targetLocation = flowerTransform;
            beeState = 2;
        }
    }

    
    internal void FlowerHarvestComplete()
    {
        beeState = 1;
    }

}
