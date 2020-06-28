using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    public Rigidbody body;
    public float turnSpeed = 20f;
    Animator m_Animator;
    Vector3 move;
    Quaternion m_Rotation = Quaternion.identity;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

        move = transform.right * xDir + transform.forward * yDir;
        controller.Move(move * speed * Time.deltaTime);

        //Below Code to start Walking Animation
        bool hasHorizontalInput = !Mathf.Approximately(xDir, 0f);
        bool hasVerticalInput = !Mathf.Approximately(yDir, 0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;

        m_Animator.SetBool("IsWalking", isWalking);

        //Vector3 desiredForward = Vector3.zero;

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, move, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);


        //if (Input.GetButton("Horizontal"))
        //{
        //    Debug.Log("Horzontal Pressed");
        //    body.position.Set(controller.);

        //}

        //if (Input.GetButton("Vertical"))
        //{
        //    desiredForward = Vector3.RotateTowards(transform.forward, move, turnSpeed * Time.deltaTime, 0f);

        //}
        //m_Rotation = Quaternion.LookRotation(desiredForward);

        //    //Vector3 desiredForward = Vector3.RotateTowards(transform.forward, move, turnSpeed * Time.deltaTime, 0f);

        //    body.MovePosition(body.position + (move * m_Animator.deltaPosition.magnitude));
        //    body.MoveRotation(m_Rotation);
    }

    void OnAnimatorMove()
    {
        Debug.Log("here");

        //body.MovePosition(body.position + (move * m_Animator.deltaPosition.magnitude));
        body.MoveRotation(m_Rotation);

    }
}


//void FixedUpdate()
//{
//    float horizontal = Input.GetAxis("Horizontal");
//    float vertical = Input.GetAxis("Vertical");

//    m_Movement.Set(horizontal, 0f, vertical);
//    m_Movement.Normalize();

//    bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
//    bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
//    bool isWalking = hasHorizontalInput || hasVerticalInput;
//    m_Animator.SetBool("IsWalking", isWalking);

//    Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
//    m_Rotation = Quaternion.LookRotation(desiredForward);
//}

//void OnAnimatorMove()
//{
//    m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
//    m_Rigidbody.MoveRotation(m_Rotation);
//}