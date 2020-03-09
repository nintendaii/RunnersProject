using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

  private MobileController mContr;
    public float jumpPower;

    private float gravityForce;
    private Vector3 moveVector;

    private CharacterController ch_controller;
    private Animator ch_animator;

    // Use this for initialization
    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
        mContr=GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
        Gravitation();
        //Shifting
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 30f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 20f;
        }
    }

    //Movment method

    private void CharacterMove()
    {
        //moving on the plane
        moveVector = Vector3.zero;
        moveVector.x = mContr.Horizontal() * moveSpeed ;
        //moveVector.z = mContr.Vertical()*moveSpeed*(-1);  //THIS ROW IS FOR NORMAL MODE
        moveVector.z =mContr.Vertical()* moveSpeed ; //THIS ROW IS FOR SPEEDRUN MODE

        //Movement animaion

        if (ch_controller.isGrounded && (moveVector.x != 0 || moveVector.z != 0))
        {
            ch_animator.SetBool("Run", true);
        }
        else
        {
            ch_animator.SetBool ("Run",false);
        }


        //Rotation

        if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, moveSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        moveVector.y = gravityForce;
        ch_controller.Move(moveVector * Time.deltaTime);
    }

    //Gravitation method for PC

    private void Gravitation()
    {
        if (!ch_controller.isGrounded)
        {
            gravityForce -= 20f * Time.deltaTime;
        }
        else
        {
            gravityForce = -1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && ch_controller.isGrounded)
        {
            ch_animator.SetBool("Jump", true);
            gravityForce = jumpPower;
        }
    }

    //Gravitation method for Android
    public void Jump()
    {
        if (!ch_controller.isGrounded)
        {
            gravityForce -= 20f * Time.deltaTime;
        }
        else
        {
            gravityForce = -1;
        }
        if (ch_controller.isGrounded)
        {
            gravityForce = jumpPower;
        }
    }
}
