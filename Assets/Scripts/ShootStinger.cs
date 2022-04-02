using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootStinger : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] GameObject shooter;
    [SerializeField] GameObject stinger;


    private Quaternion rotation;
    private Vector3 direction;
    
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
                Vector3 direction = (raycastHit.point - cam.transform.position).normalized;
                GameObject shot = Instantiate(stinger, shooter.transform.position, Quaternion.FromToRotation(cam.transform.forward, direction)) as GameObject;
                shot.transform.LookAt(raycastHit.point);
                var rb = shot.GetComponent <Rigidbody>();
                rb.AddRelativeForce(Vector3.forward * 10f, ForceMode.Impulse);




            }
            
            
            
            
            //Vector3 starget = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.z));
            //rotation = Quaternion.Euler(cam.transform.rotation.x + 90, cam.transform.rotation.y, cam.transform.rotation.z);
            
        } 
    }
}
