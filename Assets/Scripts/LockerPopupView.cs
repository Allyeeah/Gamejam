using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerPopupView : MonoBehaviour
{
    public GameObject popupUI;  // UI 팝업 창을 연결할 변수

    void Start()
    {
        if (popupUI != null)
        {
            popupUI.SetActive(false);  // 시작 시 팝업 창 비활성화
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // 플레이어 태그 확인
        {
            if (popupUI != null)
            {
                popupUI.SetActive(true);  // 팝업 창 활성화
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // 플레이어 태그 확인
        {
            if (popupUI != null)
            {
                popupUI.SetActive(false);  // 팝업 창 비활성화
            }
        }
    }
}
