using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeRange : MonoBehaviour
{
    private HoneyBee thisBee;

    private void Awake()
    {
        thisBee = GetComponentInParent<HoneyBee>();
    }
    private void OnTriggerEnter(Collider other)
    {
        var isPollenFlower = other.GetComponent<Pollen>();
        if (isPollenFlower)
        {
            thisBee.FoundFlower(other.transform.position);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        var isPollenFlower = other.GetComponent<Pollen>();
        if (isPollenFlower)
        {
            thisBee.FoundFlower(other.transform.position);
        }
    }
}
