using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBlackScreen : MonoBehaviour
{
    // ������ �гΰ� ���� ȭ�� �г��� �����մϴ�.
    public GameObject lastPanel;
    public GameObject blackScreenPanel;

    void Start()
    {
        lastPanel.SetActive(false);
        // ���� ȭ�� �г��� ��Ȱ��ȭ�մϴ�.
        blackScreenPanel.SetActive(false);
    }

    void Update()
    {
        // ������ �г��� Ȱ��ȭ�� ���¿��� 'E' Ű �Է��� �����մϴ�.
        if (lastPanel.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            
            // ���� ȭ�� �г��� Ȱ��ȭ�մϴ�.
            blackScreenPanel.SetActive(true);

            // �ʿ信 ���� ������ �г��� ��Ȱ��ȭ�� ���� �ֽ��ϴ�.
            // lastPanel.SetActive(false);
        }
    }
}
