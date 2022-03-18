using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Rigidbody myRigidBody;
    Vector3 moveVector;
   

    // Start is called before the first frame update
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var vInput = Input.GetAxisRaw("Vertical");
        var hInput = Input.GetAxisRaw("Horizontal");
        moveVector = new Vector3(hInput, 0f, vInput).normalized;

    }

    void FixedUpdate()
    {
        myRigidBody.AddForce(moveVector * moveSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}
