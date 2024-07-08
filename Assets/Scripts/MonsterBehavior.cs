using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// MonsterBehavior.cs

public class MonsterBehavior : MonoBehaviour
{

    public Transform firstLocation;
    public Transform secondLocation;
    public Transform lastLocation;
    public float waitTime = 0.2f;
    public GameObject Camera;
    public GameObject traceTarget;
    private Animator animator;
    public GameObject monsterSprite;  // 몬스터 스프라이트 오브젝트
    public Transform player;          // 플레이어 Transform
    public float speed = 30f;
    public GameObject imageRestart;   // 몬스터 속도

    private bool isMonsterActive = false;  // 몬스터 활성화 여부

    void Start()
    {
        animator = GetComponent<Animator>();
        // 초기에는 몬스터 스프라이트를 비활성화합니다.
        monsterSprite.SetActive(false);
    }

    void Update()
    {
        // 플레이어가 'E' 키를 눌렀을 때 몬스터를 활성화합니다.
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!ClassRoomCardKey.Instance.hasCardKey)
            {
                isMonsterActive = true;
                monsterSprite.SetActive(true);
            }
        }

        // 몬스터가 활성화된 상태라면 플레이어를 추적합니다.
        if (isMonsterActive)
        {
            float distance = Vector3.Distance(transform.position, traceTarget.transform.position);
            animator.SetBool("isDiscover", true);

            if (distance == 0)
            {
                StartCoroutine(MoveCamera());

            }

            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

        }
    }

    private IEnumerator MoveCamera()
    {

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


    }
}