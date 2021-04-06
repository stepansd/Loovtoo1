using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running2 : MonoBehaviour
{
    //muutujad
    [SerializeField] private float speed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float rotation;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    private CharacterController controller;
    private Animator anim;

   
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);//arvutab kas me oleme pinnal
        if (isGrounded && velocity.y < 0)//kontrilleerib kui me oleme pinnal ja takistab gravity andmine
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX= Input.GetAxis("Horizontal");
        moveDirection = new Vector3(moveX, 0, moveZ);

        //transform.Rotate(0, moveX * rotation * Time.deltaTime, 0);

        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero)
            {
                Run();
            }

            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            //moveDirection *= speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        moveDirection *= speed;
        controller.Move(moveDirection * Time.deltaTime);
        

        velocity.y += gravity * Time.deltaTime;//arvutab gravity 
        controller.Move(velocity * Time.deltaTime);//annab gravity
    }

    private void Run()
    {   
        speed = walkSpeed;
        anim.SetFloat("Spedd", 1f, 0.1f, Time.deltaTime);
        /*if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("back", true);
        }
        else
        {
            anim.SetBool("back", false);
        }*/
    }

    private void Idle()
    {
        anim.SetFloat("Spedd", 0f, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetTrigger("jump");
    }
}
