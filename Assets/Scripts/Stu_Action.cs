using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stu_Action : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    Vector3 movement;
    private float movePower = 3f;
    private float CrouchPower = 1.5f;
    private float RunningMovePower = 5f;
    private int direction = 1;
    private bool Running = false;
    private bool Crouching = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Walk();
        Run();
        Crouch();
    }

    void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Running = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Running = false;
        }

    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Crouching = true;
            anim.SetBool("isCrouching", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            Crouching = false;
            anim.SetBool("isCrouching", false);
        }
    }

    void Walk()
    {
        if (!Running && !Crouching)
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isWalking", false);

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1, 1);
                anim.SetBool("isWalking", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1);
                anim.SetBool("isWalking", true);

            }
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }

        if (Crouching)
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isCrawling", false);

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1, 1);
                anim.SetBool("isCrawling", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1);
                anim.SetBool("isCrawling", true);

            }
            transform.position += moveVelocity * CrouchPower * Time.deltaTime;
        }

        if (Running && !Crouching)
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRunning", false);
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1, 1);
                anim.SetBool("isRunning", true);
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1);
                anim.SetBool("isRunning", true);
            }
            transform.position += moveVelocity * RunningMovePower * Time.deltaTime;
        }

    }

}
