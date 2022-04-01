using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var colliderObject = other.GetComponent<Collider>();
        
        if (colliderObject.tag == "Player")
        {
            UIScoreManager.instance.AddHoney(1);
            Die();

        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
