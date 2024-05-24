using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.XR;

public class DoorChanger : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer; // 변경할 스프라이트 렌더러를 참조합니다.
    public Sprite newSprite; // 새로운 스프라이트를 참조합니다.
    public Sprite originalSprite; // 원래의 스프라이트를 저장합니다.

    public GameObject panel; // E키를 두 번째 눌렀을 때 표시할 패널
    private bool isSpriteChanged = false; // 스프라이트 변경 여부
    private bool isPanelShown = false; // 패널이 표시되었는지 여부
    public ParticleSystem particleSystem; // 파티클 시스템 오브젝트

    public GameObject monsterSprite;
    public GameObject traceTarget;
    public GameObject Monster;
    public GameObject Camera;
    public GameObject imageRestart;

    private ClassRoomCardKey cardKeyManager;
    public bool done = false;
    public Transform firstLocation;
    public Transform secondLocation;
    public Transform lastLocation;
    public float waitTime = 0.2f; // 카메라가 시작 위치에 머무는 시간
    public MonoBehaviour scriptToPause1; // 일시 중지할 스크립트
    public MonoBehaviour scriptToPause2;
    public MonoBehaviour scriptToPause3;
    public float movePower = 30f;

    void Start()
    {
        monsterSprite.SetActive(false);
        // 원래 스프라이트를 저장합니다.
        if (targetSpriteRenderer != null)
        {
            originalSprite = targetSpriteRenderer.sprite;
        }
    }

    void Update()
    {
        Vector3 moveVelocity = Vector3.zero;
        // E키를 눌렀을 때 상호작용을 처리
        if (Input.GetKeyDown(KeyCode.E))
        {
            /*if (!ClassRoomCardKey.Instance.hasCardKey)
            {
                ActivateMonsterSprite();
                Vector3 playerPos = traceTarget.transform.position;

                if (playerPos.x > Monster.transform.position.x)
                {
                    moveVelocity = Vector3.right;
                    Monster.transform.localScale = new Vector3(-1, 1, 1) * 0.5f;

                }
                else if (playerPos.x < Monster.transform.position.x)
                {
                    moveVelocity = Vector3.left;
                    Monster.transform.localScale = new Vector3(1, 1, 1) * 0.5f;
                }

                if (playerPos.x - Monster.transform.position.x < 15 && playerPos.x - Monster.transform.position.x > -15)
                {
                    StartCoroutine(MoveCamera());
                }
            }*/


            if (!isSpriteChanged)
            {
                ChangeSprite();
                particleSystem.Stop();
            }
            else if (!isPanelShown)
            {
                ShowPanel();
            }

            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
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
    void ActivateMonsterSprite()
    {
        if (monsterSprite != null && !monsterSprite.activeInHierarchy)
        {
            monsterSprite.SetActive(true);
        }
    }

    void ChangeSprite()
    {
        if (targetSpriteRenderer != null && newSprite != null)
        {
            targetSpriteRenderer.sprite = newSprite;
            isSpriteChanged = true;
        }
    }

    void ShowPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
            isPanelShown = true;
        }
    }
}
