using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeRange : MonoBehaviour
{
    private HoneyBee thisBee;
    private bool shouldLook;

    private void Awake()
    {
        thisBee = GetComponentInParent<HoneyBee>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!shouldLook)
        {
            var isPollenFlower = other.GetComponent<Pollen>();
            if (isPollenFlower)
            {
                thisBee.FoundFlower(other.transform.position);
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {

        if (!shouldLook)
        {
            var isPollenFlower = other.GetComponent<Pollen>();
            if (isPollenFlower)
            {
                thisBee.FoundFlower(other.transform.position);
            }
        }

    }

    public void SetShouldLook(bool yes)
    {
        shouldLook = yes;
    }

    public void StopShouldLook(bool no)
    {
        shouldLook = no;
    }
}
