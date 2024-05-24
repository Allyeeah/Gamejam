using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stu_Action : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    Vector3 movement;

    public float movePower = 5f;
    private float CrouchPower = 3f;
    private int direction = 1;
    private bool Crouching = false;
    public float scale = 0.245f;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Walk();
        Crouch();
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
        if (!Crouching)
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isWalking", false);

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = 1;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1, 1) * scale;
                anim.SetBool("isWalking", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = -1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1) * scale;
                anim.SetBool("isWalking", true);

            }
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }

        else if (Crouching)
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isCrawling", false);

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = 1;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1, 1) * scale;
                anim.SetBool("isCrawling", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = -1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1) * scale;
                anim.SetBool("isCrawling", true);

            }
            transform.position += moveVelocity * CrouchPower * Time.deltaTime;
        }

    }


}
