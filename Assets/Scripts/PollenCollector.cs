using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenCollector : MonoBehaviour
{
    private Pollen pollen;
    bool harvesting;
    private bool harvestWait;
    HoneyBee honeyBee;
    private HoneyDrop honeyDrop;

    private void Awake()
    {
        honeyBee = GetComponentInParent<HoneyBee>();
    }

    private void OnEnable()
    {
        harvesting = false;
        harvestWait = false;
        pollen = honeyBee.GetPollenObject();
        if (pollen != null)
        {
            harvesting = true;
        }

        if (pollen == null)
        {
            //tell parent that no flower found (passing false to set "foundFlower" status in parent)
            honeyBee.FlowerHarvestComplete();
        }
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
        honeyDrop = other.GetComponent<HoneyDrop>();

        if (honeyDrop != null)
        {
            //tell parent that no flower found (passing false to set "foundFlower" status in parent)
            honeyBee.FlowerHarvestComplete();
        }
    }

    IEnumerator HarvestHoney()
    {
        harvestWait = true;
        pollen.HarvestPollen(1.0f);
        yield return new WaitForSeconds(1f);
        harvestWait = false;
    }

}

