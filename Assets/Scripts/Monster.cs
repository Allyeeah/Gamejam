using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
    public GameObject Camera;
    public string playerAnimationState = "Run_Player";
    public bool stopmove = false;
    public bool back = false;
    public bool tmp = false;

    public bool done = false;
    public Transform firstLocation;
    public Transform secondLocation;
    public Transform lastLocation;
    public float waitTime = 0.2f; // 카메라가 시작 위치에 머무는 시간
    public MonoBehaviour scriptToPause1; // 일시 중지할 스크립트
    public MonoBehaviour scriptToPause2;
    public MonoBehaviour scriptToPause3;

    public AudioClip normalMusic; // 일반 배경음악
    public AudioClip monsterMusic; // 몬스터와 충돌 시 재생할 음악
    private AudioSource audioSource;
    public GameObject imageRestart;
    private void Start()
    {
        imageRestart.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = normalMusic;
        audioSource.Play();
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine("ChangeMovement");
        transform.position = Vector2.MoveTowards(new Vector2(144.52f, -6.95f), new Vector2(90, -6.95f), 99999f);
    }
    void ChangeMusic(AudioClip newClip)
    {
        if (audioSource.clip != newClip)
        {
            audioSource.clip = newClip;
            audioSource.Play();
        }
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

        yield return new WaitForSeconds(4f);

        StartCoroutine("ChangeMovement");
    }

    private void FixedUpdate()
    {
        CheckBackwardRay();
        Move();
    }
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if(stopmove == false)
        {
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
                    
                if (playerPos.x - transform.position.x < 15 && playerPos.x - transform.position.x > -15 && !done && tmp)
                {
                    done = true;
                    StartCoroutine(MoveCamera());

                }

            }

            else if (movementFlag == 1)
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(1, 1, 1) * 0.5f;
            }

            else if (movementFlag == 2)
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(-1, 1, 1) * 0.5f;
            }

            transform.position += moveVelocity * movePower * Time.deltaTime;
        }

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

        if(!back)
        {
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                Animator playerAnimator = hit.collider.GetComponent<Animator>();
                if (playerAnimator != null)
                {
                    // 플레이어의 현재 애니메이션 상태를 확인합니다.
                    AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
                    if (stateInfo.IsName(playerAnimationState))
                    {
                        back = true;
                        Vector3 moveVelocity = Vector3.zero;
                        Vector3 playerPos = traceTarget.transform.position;

                        if (playerPos.x > transform.position.x)
                        {
                            StopCoroutine("ChangeMovement");
                            animator.SetBool("isLooking", false);
                            movementFlag = 2;
                            StartCoroutine(PauseBeforeChase(new Vector3(-1, 1, 1) * 0.5f));

                        }
                        else if (playerPos.x < transform.position.x)
                        {
                            StopCoroutine("ChangeMovement");
                            animator.SetBool("isLooking", false);
                            movementFlag = 1;
                            StartCoroutine(PauseBeforeChase(new Vector3(1, 1, 1) * 0.5f));

                        }

                    }
                }
            }
        }

    }
    IEnumerator PauseBeforeChase(Vector3 newScale)
    {
        if(!isTracing)
        {
            stopmove = true;
            yield return new WaitForSeconds(2.0f); // Adjust the wait time as needed

            transform.localScale = newScale;

            yield return new WaitForSeconds(2.0f);

            back = false;
            stopmove = false;
            animator.SetBool("isLooking", true);
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
        movePower = 0f;
        animator.SetTrigger("Discover");
        isTracing = true;

        yield return new WaitForSeconds(3.0f);

        ChangeMusic(monsterMusic);
        tmp = true;
        movePower = 30f;
        animator.SetBool("isDiscover", true);

    }
    private IEnumerator MoveCamera()
    {
        // 일시 중지할 스크립트의 실행을 중단합니다.
        if (scriptToPause1 != null)
        {
            scriptToPause1.enabled = false;
        }
        if (scriptToPause2 != null)
        {
            scriptToPause2.enabled = false;
        }
        if (scriptToPause3 != null)
        {
            scriptToPause3.enabled = false;
        }

        // 카메라를 시작 위치로 이동시킵니다.
        Camera.transform.position = firstLocation.position;
        Camera.transform.rotation = firstLocation.rotation;

        // waitTime 동안 대기합니다.
        yield return new WaitForSeconds(waitTime);

        // 카메라를 원래 위치로 되돌립니다.
        Camera.transform.position = secondLocation.position;
        Camera.transform.rotation = secondLocation.rotation;

        yield return new WaitForSeconds(waitTime);

        // 카메라를 원래 위치로 되돌립니다.
        Camera.transform.position = lastLocation.position;
        Camera.transform.rotation = lastLocation.rotation;

        yield return new WaitForSeconds(5f);
        imageRestart.SetActive(true);
        // 일시 중지한 스크립트의 실행을 재개합니다.
        if (scriptToPause1 != null)
        {
            scriptToPause1.enabled = true;
        }
        if (scriptToPause2 != null)
        {
            scriptToPause2.enabled = true;
        }
        if (scriptToPause3 != null)
        {
            scriptToPause3.enabled = true;
        }
    }
}
