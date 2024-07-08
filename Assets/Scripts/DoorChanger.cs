using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.XR;

public class DoorChanger : MonoBehaviour
{

    public Animator animator;
    public SpriteRenderer targetSpriteRenderer; // ������ ��������Ʈ �������� �����մϴ�.
    public Sprite newSprite; // ���ο� ��������Ʈ�� �����մϴ�.
    public Sprite originalSprite; // ������ ��������Ʈ�� �����մϴ�.

    public Transform firstTargetPosition; // ù ��° �̵��� ��ǥ ��ġ

    public GameObject panel; // EŰ�� �� ��° ������ �� ǥ���� �г�
    private bool isSpriteChanged = false; // ��������Ʈ ���� ����
    private bool isPanelShown = false; // �г��� ǥ�õǾ����� ����
    public ParticleSystem particleSystem; // ��ƼŬ �ý��� ������Ʈ

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
    public float waitTime = 0.2f; // ī�޶� ���� ��ġ�� �ӹ��� �ð�
    public MonoBehaviour scriptToPause1; // �Ͻ� ������ ��ũ��Ʈ
    public MonoBehaviour scriptToPause2;
    public MonoBehaviour scriptToPause3;
    public float movePower = 30f;

    private Transform currentTargetPosition;

    void Start()
    {
        animator = GetComponent<Animator>();

        currentTargetPosition = firstTargetPosition;
        monsterSprite.SetActive(false);
        // ���� ��������Ʈ�� �����մϴ�.
        if (targetSpriteRenderer != null)
        {
            originalSprite = targetSpriteRenderer.sprite;
        }
    }

    void Update()
    {
        Vector3 moveVelocity = Vector3.zero;
        // EŰ�� ������ �� ��ȣ�ۿ��� ó��
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
