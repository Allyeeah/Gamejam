using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stu_Action : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    Vector3 movement;
    private float movePower = 9f;
    private float CrouchPower = 4.5f;
    private float RunningMovePower = 15f;
    private int direction = 1;
    private bool Crouching = false;
    private bool Readying = false;
    private float playersize = 2;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Walk();
        Ready();
        Crouch();
    }

    void Ready()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Readying = true;
            anim.SetBool("isReady", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Readying = false;
            anim.SetBool("isReady", false);
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
        if (!Readying && !Crouching)
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isWalking", false);

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1, 1) * playersize;
                anim.SetBool("isWalking", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1) * playersize;
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

                transform.localScale = new Vector3(direction, 1, 1) * playersize;
                anim.SetBool("isCrawling", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1) * playersize;
                anim.SetBool("isCrawling", true);

            }
            transform.position += moveVelocity * CrouchPower * Time.deltaTime;
        }

        if (Readying && !Crouching)
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRunning", false);
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1, 1) * playersize;
                anim.SetBool("isRunning", true);
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1) * playersize;
                anim.SetBool("isRunning", true);
            }
            transform.position += moveVelocity * RunningMovePower * Time.deltaTime;
        }

    }

}
