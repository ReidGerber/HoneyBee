using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeRange : MonoBehaviour
{
    private HoneyBee honeyBee;
    private void Awake()
    {
        honeyBee = GetComponentInParent<HoneyBee>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var pollenFlower = other.GetComponent<Pollen>();
        if (pollenFlower)
        {
            honeyBee.FoundFlower(other.transform.position, pollenFlower);
        }

    }
}
