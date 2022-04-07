using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterControllerMovement1 : MonoBehaviour
{
    
    [SerializeField] float speed = 10f;
    [SerializeField] float turnSmoothTimeY = 0.1f; 
    [SerializeField] float turnSpeed = 0.5f;

    CharacterController controller;
    private float turnSmoothVelocityY;
    private float turnSmoothVelocityX;
    Transform cam;
    Animator animator;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") / turnSpeed;
        float vertical = Input.GetAxisRaw("Vertical");
        float jump = Input.GetAxisRaw("Jump");

        //Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 jumpDirection = new Vector3(0f, jump, 0f).normalized;
        

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

 
        if (direction.magnitude >= 0.1)
        {

            float targetAngleY = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angleY = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngleY, ref turnSmoothVelocityY, turnSmoothTimeY);

            transform.rotation = Quaternion.Euler(0f, angleY, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngleY, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }

        else
        {
            animator.SetBool("isMoving", false);
        }
            controller.Move(jumpDirection * speed * Time.deltaTime);
    }
}
