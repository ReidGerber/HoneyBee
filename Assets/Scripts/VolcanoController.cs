using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class VolcanoController : MonoBehaviour
{
    [SerializeField] ParticleSystem lava;
    [SerializeField] int lavaPlayMin = 15;
    [SerializeField] int lavaPlayMax = 30;
    [SerializeField] int lavaDelayMin = 45;
    [SerializeField] int lavaDelayMax = 60;
    private bool lavaPlaying;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!lavaPlaying)
        {
            StartCoroutine(startVolcano());
        }
        
    }

    IEnumerator startVolcano()
    {
        lavaPlaying = true;
        //Debug.Log("started volcano coroutine");
        yield return new WaitForSeconds(Random.Range(lavaDelayMin, lavaDelayMax));
        PlayLava();

    }

    void PlayLava()
    {
        //Debug.Log("started lava");
        lava.Play();
        StartCoroutine(stopVolcano());
    }

    IEnumerator stopVolcano()
    {
        yield return new WaitForSeconds(Random.Range(lavaPlayMin, lavaPlayMax));
        lavaPlaying = false;
        lava.Stop();
    }

}
