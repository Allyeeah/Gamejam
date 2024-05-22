using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float movePower = 5f;
    public float rayDistance = 25f; // 레이 거리
    public LayerMask playerLayer;

    Animator animator;
    Vector3 movement;
    int movementFlag = 0;
    bool isTracing = false;
    public GameObject traceTarget;
    public string playerAnimationState = "Stu_Run";

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
        CheckBackwardRay();
    }
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (isTracing)
        {
            Vector3 playerPos = traceTarget.transform.position;

            if (playerPos.x > transform.position.x)
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(-1, 1, 1) * 0.5f;

            }
            else if (playerPos.x < transform.position.x)
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(1, 1, 1) * 0.5f;

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
    void CheckBackwardRay()
    {
        Vector2 rayOffset = new Vector2(0f, 10.0f); // 예: 몬스터의 아래쪽으로 레이를 쏩니다.

        // 몬스터의 위치와 레이 오프셋을 합하여 레이를 쏘는 시작 위치 설정
        Vector2 rayStartPoint = (Vector2)transform.position + rayOffset;

        // 현재 몬스터가 향하고 있는 방향의 반대 방향으로 레이를 쏩니다.
        Vector2 rayDirection = transform.localScale.x < 0 ? Vector2.left : Vector2.right;
        RaycastHit2D hit = Physics2D.Raycast(rayStartPoint, rayDirection, rayDistance, playerLayer);

        Debug.DrawRay(rayStartPoint, rayDirection * rayDistance, Color.red);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            Animator playerAnimator = hit.collider.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                // 플레이어의 현재 애니메이션 상태를 확인합니다.
                AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
                if (stateInfo.IsName(playerAnimationState))
                {
                    Vector3 moveVelocity = Vector3.zero;
                    Vector3 playerPos = traceTarget.transform.position;

                    if (playerPos.x > transform.position.x)
                    {
                        StopCoroutine("ChangeMovement");
                        transform.localScale = new Vector3(-1, 1, 1) * 0.5f;
                        StartCoroutine("StartChase");

                    }
                    else if (playerPos.x < transform.position.x)
                    {
                        StopCoroutine("ChangeMovement");
                        transform.localScale = new Vector3(1, 1, 1) * 0.5f;
                        StartCoroutine("StartChase");

                    }

                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Wall1")
        {
            transform.localScale = new Vector3(1, 1, 1) * 0.5f;
            movementFlag = 1;
        }
        if (other.collider.tag == "Wall2")
        {
            transform.localScale = new Vector3(-1, 1, 1) * 0.5f;
            movementFlag = 2;
        }
        if (other.gameObject.tag == "Player")
        {
            traceTarget = other.gameObject;

            StopCoroutine("ChangeMovement");
        }
/*
        Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());*/
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !isTracing)
        {
            StartCoroutine("StartChase");
        }
    }
    IEnumerator StartChase()
    {
        isTracing = true;
        movePower = 0f;
        animator.SetTrigger("Discover");

        yield return new WaitForSeconds(3.0f);

        movePower = 12f;
        animator.SetBool("isDiscover", true);

    }

}
