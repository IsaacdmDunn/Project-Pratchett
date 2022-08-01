using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDist = 2f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] bool isGrounded;
    [SerializeField] float speed = 12f;
    [SerializeField] float sprintMod = 1.25f;
    [SerializeField] float jump = 12f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * speed * sprintMod * Time.deltaTime);
        }
        else 
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
