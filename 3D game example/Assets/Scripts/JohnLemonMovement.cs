using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    public float turnSpeed = 20f;
    public float MoveSpeed = 10f;
    //Animator m_Animator;
    private Rigidbody Rigidbody;
    private Vector3 Movement;
    private Quaternion Rotation = Quaternion.identity;

    void Start()
    {
        //m_Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Movement.Set(horizontal, 0f, vertical);
        Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        //m_Animator.SetBool("IsWalking", isWalking);

        
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, Movement, turnSpeed * Time.deltaTime, 0f);
        Rotation = Quaternion.LookRotation(desiredForward);

        Rigidbody.MovePosition(Rigidbody.position + Movement * MoveSpeed * Time.deltaTime);
        Rigidbody.MoveRotation(Rotation);
    }

   
}