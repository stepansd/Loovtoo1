using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : MonoBehaviour
{
    private CharacterController _characterController;
    public float speed=5.0f;
    public float rotation=200.0f;
    public float gravity=20.0f;
    private Vector3 moving = Vector3.zero;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (v < 0) v = 0;

        transform.Rotate(0, h * rotation * Time.deltaTime, 0);

        if (_characterController.isGrounded)
        {
            bool move = (v > 0) || (h != 0);

            anim.SetBool("run", move);

            moving = Vector3.forward * v;

            moving = transform.TransformDirection(moving);
            moving *= speed;
        }
        moving.y -= gravity * Time.deltaTime;
        _characterController.Move(moving * Time.deltaTime);



    }

    
}
