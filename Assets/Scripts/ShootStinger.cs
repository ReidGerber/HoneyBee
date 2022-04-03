using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootStinger : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] GameObject shooter;
    [SerializeField] GameObject stinger;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                transform.LookAt(raycastHit.point);
                Instantiate(stinger, transform.position, transform.rotation);
            }
            
        } 
    }
}
