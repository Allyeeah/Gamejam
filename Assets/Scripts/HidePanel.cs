using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanel : MonoBehaviour
{
    public GameObject panel; // �г��� �巡���Ͽ� �Ҵ��� �� �ֵ��� public���� �����մϴ�.

    void Start()
    {
        if (panel == null)
        {
            Debug.LogError("Panel is not assigned.");
        }
    }

    void Update()
    {
        // 'E' Ű�� ���ȴ��� Ȯ���մϴ�.
        if (Input.GetKeyDown(KeyCode.E))
        {
            // �г��� ��Ȱ��ȭ�մϴ�.
            if (panel != null)
            {
                panel.SetActive(false);
            }
        }
    }
}
