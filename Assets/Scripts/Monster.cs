using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float movePower = 5f;

    Animator animator;
    Vector3 movement;
    int movementFlag = 0;
    bool isTracing = false;
    public GameObject traceTarget;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine("ChangeMovement");
    }

    IEnumerator ChangeMovement() 
    {

        movementFlag = Random.Range(0, 3);

        if (movementFlag == 0)
        {
            animator.SetBool("isLooking", false);
        }
        else 
        {
            animator.SetBool("isLooking", true);
        }

        yield return new WaitForSeconds(3f);

        StartCoroutine("ChangeMovement");
    }

    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (isTracing)
        {
            Vector3 playerPos = traceTarget.transform.position;

            if(playerPos.x < transform.position.x)
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(1, 1, 1) * 0.5f;
            }
            else if (playerPos.x > transform.position.x)
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(-1, 1, 1) * 0.5f;
            }
        }
        else if (movementFlag == 1)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1) * 0.5f;
        }
        else if (movementFlag==2)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1) * 0.5f;
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Wall1")
        {
            transform.localScale = new Vector3(1, 1, 1) * 0.5f;
            movementFlag = 2;
        }
        if (other.collider.tag == "Wall2")
        {
            transform.localScale = new Vector3(-1, 1, 1) * 0.5f;
            movementFlag = 1;
        }
        if(other.gameObject.tag == "Player")
        {
            traceTarget = other.gameObject;

            StopCoroutine("ChangeMovement");
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = true; movePower = 12f;
            animator.SetBool("isDiscover", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = false;
            animator.SetBool("isDiscover", false);
        }

        StartCoroutine("ChangeMovement");
    }
}
