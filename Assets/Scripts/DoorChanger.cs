using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.XR;

public class DoorChanger : MonoBehaviour
{

    public Animator animator;
    public SpriteRenderer targetSpriteRenderer; // 변경할 스프라이트 렌더러를 참조합니다.
    public Sprite newSprite; // 새로운 스프라이트를 참조합니다.
    public Sprite originalSprite; // 원래의 스프라이트를 저장합니다.

    public Transform firstTargetPosition; // 첫 번째 이동할 목표 위치

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

    private Transform currentTargetPosition;

    void Start()
    {
        animator = GetComponent<Animator>();

        currentTargetPosition = firstTargetPosition;
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
