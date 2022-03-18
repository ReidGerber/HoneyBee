using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] float distanceFromCamera;

    Rigidbody myRigidBody;

    Camera cam;

    

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();
        //cam = Camera.main;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();





        //Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera));
        //Vector3 mouseDirection = mousePos - transform.position;

        if (movementDirection.magnitude >=0.1)
        {
            float movementAngle = Mathf.Atan2(movementDirection.x, movementDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, horizontalInput, 0f);
            
            //move with physics
            myRigidBody.AddForce(transform.forward * verticalInput * moveSpeed * Time.deltaTime, ForceMode.Impulse);
    
            //move without physics
            //transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
        }
    }
}
