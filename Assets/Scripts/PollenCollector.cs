using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenCollector : MonoBehaviour
{
    private Pollen pollen;
    bool harvesting;
    private bool harvestWait;

    private void Awake()
    {
        harvesting = false;
        harvestWait = false;
    }

    private void Update()
    {
        if (harvesting && !harvestWait)
        {
            StartCoroutine("HarvestHoney");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        pollen = other.GetComponent<Pollen>();
        if (pollen != null)
        {
            harvesting = true;
        }
    }

    IEnumerator HarvestHoney()
    {
        harvestWait = true;
        pollen.HarvestPollen(1.0f);
        yield return new WaitForSeconds(1f);
        harvestWait = false;
    }

    private void OnTriggerExit(Collider other)
    {
        harvesting = false;
        harvestWait = false;
    }



}

