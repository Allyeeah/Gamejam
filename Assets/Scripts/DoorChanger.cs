using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.XR;

public class DoorChanger : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer; // ������ ��������Ʈ �������� �����մϴ�.
    public Sprite newSprite; // ���ο� ��������Ʈ�� �����մϴ�.
    public Sprite originalSprite; // ������ ��������Ʈ�� �����մϴ�.

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

    void Start()
    {
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
        // �Ͻ� ������ ��ũ��Ʈ�� ������ �ߴ��մϴ�.
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

        // ī�޶� ���� ��ġ�� �̵���ŵ�ϴ�.
        Camera.transform.position = firstLocation.position;
        Camera.transform.rotation = firstLocation.rotation;

        // waitTime ���� ����մϴ�.
        yield return new WaitForSeconds(waitTime);

        // ī�޶� ���� ��ġ�� �ǵ����ϴ�.
        Camera.transform.position = secondLocation.position;
        Camera.transform.rotation = secondLocation.rotation;

        yield return new WaitForSeconds(waitTime);

        // ī�޶� ���� ��ġ�� �ǵ����ϴ�.
        Camera.transform.position = lastLocation.position;
        Camera.transform.rotation = lastLocation.rotation;

        yield return new WaitForSeconds(5f);
        imageRestart.SetActive(true);
        // �Ͻ� ������ ��ũ��Ʈ�� ������ �簳�մϴ�.
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
