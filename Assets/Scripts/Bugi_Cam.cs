using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugi_Cam : MonoBehaviour
{
    public Transform startLocation; // 카메라가 잠깐 위치할 시작 위치
    public float waitTime = 8f; // 카메라가 시작 위치에 머무는 시간
    public MonoBehaviour scriptToPause1; // 일시 중지할 스크립트
    public MonoBehaviour scriptToPause2;
    public MonoBehaviour scriptToPause3;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        // 카메라의 원래 위치와 회전을 저장합니다.
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        // 코루틴을 시작합니다.
        StartCoroutine(MoveCamera());
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
        transform.position = startLocation.position;
        transform.rotation = startLocation.rotation;

        // waitTime 동안 대기합니다.
        yield return new WaitForSeconds(waitTime);

        // 카메라를 원래 위치로 되돌립니다.
        transform.position = originalPosition;
        transform.rotation = originalRotation;

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
            scriptToPause2.enabled = true;
        }
    }
}