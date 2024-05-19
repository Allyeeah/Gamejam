using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Start_Scene: MonoBehaviour
{

    public Transform firstTargetPosition; // 첫 번째 이동할 목표 위치
    public Transform secondTargetPosition; // 두 번째 이동할 목표 위치
    public float moveSpeed = 2f; // 이동 속도

    private Animator animator;
    private bool isMoving = true;
    private Transform currentTargetPosition;
    private bool reachedFirstTarget = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentTargetPosition = firstTargetPosition;
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        while (isMoving)
        {
            float distance = Vector3.Distance(transform.position, currentTargetPosition.position);
            animator.SetBool("isWalking", true);

            if (distance < 0.1f)
            {
                if (!reachedFirstTarget)
                {
                    reachedFirstTarget = true;
                    currentTargetPosition = secondTargetPosition;
                    animator.SetBool("isLooking", true);
                    animator.SetBool("isWalking", false);
                }
                else
                {
                    isMoving = false;
                    animator.SetBool("isLooking", false);
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTargetPosition.position, moveSpeed * Time.deltaTime);
            }


            yield return null;
        }
        animator.SetBool("isLooking", false);
        animator.SetBool("isWalking", false);
    }
}