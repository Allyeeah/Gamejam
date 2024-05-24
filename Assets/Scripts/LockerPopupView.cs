using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerPopupView : MonoBehaviour
{
    public GameObject popupUI;  // UI �˾� â�� ������ ����

    void Start()
    {
        if (popupUI != null)
        {
            popupUI.SetActive(false);  // ���� �� �˾� â ��Ȱ��ȭ
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // �÷��̾� �±� Ȯ��
        {
            if (popupUI != null)
            {
                popupUI.SetActive(true);  // �˾� â Ȱ��ȭ
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // �÷��̾� �±� Ȯ��
        {
            if (popupUI != null)
            {
                popupUI.SetActive(false);  // �˾� â ��Ȱ��ȭ
            }
        }
    }
}
