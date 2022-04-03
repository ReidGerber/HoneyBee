using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingerBullet : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] float damage = 1.0f;
    [SerializeField] ParticleSystem dieParticle;

    
    private Rigidbody rb;
    private float dieDelay;
    
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        dieDelay = 1f;
    }

    private void OnEnable()
    {
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Bullet")
        {
            Debug.Log("Collider = "+ other.gameObject.tag);
            StartCoroutine(Die());
        }
        
    }


    IEnumerator Die()
    {
        Debug.Log("dead");
        rb.velocity = Vector3.zero;
        GetComponent<Renderer>().enabled = false;
        Instantiate(dieParticle, transform);
        dieParticle.Play();
        yield return new WaitForSeconds(dieDelay);
        gameObject.SetActive(false);

    }

}
