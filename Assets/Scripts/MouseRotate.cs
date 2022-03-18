using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    [SerializeField] float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //var target = Camera.main.
        //transform.Rotate(horizontal * turnSpeed * Vector3.left, Space.Self);

        //var horizontal = Input.GetAxis("Horizontal");
        //transform.Rotate(horizontal * turnSpeed * Vector3.up, Space.World);

    }
}
