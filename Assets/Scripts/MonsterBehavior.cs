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
    public GameObject monsterSprite;  // ���� ��������Ʈ ������Ʈ
    public Transform player;          // �÷��̾� Transform
    public float speed = 30f;
    public GameObject imageRestart;   // ���� �ӵ�

    private bool isMonsterActive = false;  // ���� Ȱ��ȭ ����

    void Start()
    {
        animator = GetComponent<Animator>();
        // �ʱ⿡�� ���� ��������Ʈ�� ��Ȱ��ȭ�մϴ�.
        monsterSprite.SetActive(false);
    }

    void Update()
    {
        // �÷��̾ 'E' Ű�� ������ �� ���͸� Ȱ��ȭ�մϴ�.
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!ClassRoomCardKey.Instance.hasCardKey)
            {
                isMonsterActive = true;
                monsterSprite.SetActive(true);
            }
        }

        // ���Ͱ� Ȱ��ȭ�� ���¶�� �÷��̾ �����մϴ�.
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


    }
}