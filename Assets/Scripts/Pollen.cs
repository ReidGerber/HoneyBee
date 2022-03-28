using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollen : MonoBehaviour
{
    [SerializeField] float startingPollen;
    [SerializeField] GameObject objectToSpawn;

    private float currentPollen;

    private void OnEnable()
    {
        currentPollen = startingPollen;
    }

    public void HarvestPollen(float harvestAmount)
    {
        currentPollen -= harvestAmount;
        if (currentPollen <=0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);

        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }
}
