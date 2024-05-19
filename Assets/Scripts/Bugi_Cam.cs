using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugi_Cam : MonoBehaviour
{
    public Transform startLocation; // ī�޶� ��� ��ġ�� ���� ��ġ
    public float waitTime = 8f; // ī�޶� ���� ��ġ�� �ӹ��� �ð�
    public MonoBehaviour scriptToPause1; // �Ͻ� ������ ��ũ��Ʈ
    public MonoBehaviour scriptToPause2;
    public MonoBehaviour scriptToPause3;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        // ī�޶��� ���� ��ġ�� ȸ���� �����մϴ�.
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        // �ڷ�ƾ�� �����մϴ�.
        StartCoroutine(MoveCamera());
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
        transform.position = startLocation.position;
        transform.rotation = startLocation.rotation;

        // waitTime ���� ����մϴ�.
        yield return new WaitForSeconds(waitTime);

        // ī�޶� ���� ��ġ�� �ǵ����ϴ�.
        transform.position = originalPosition;
        transform.rotation = originalRotation;

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
            scriptToPause2.enabled = true;
        }
    }
}