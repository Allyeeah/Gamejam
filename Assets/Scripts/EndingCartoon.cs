using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCartoon : MonoBehaviour
{
    public GameObject endingCartoonPanel;
    public GameObject e2Panel;

   /* void Start()
    {
        // ������ �� EndingCartoon �г��� Ȱ��ȭ�ϰ� E2 �г��� ��Ȱ��ȭ
        endingCartoonPanel.SetActive(true);
        e2Panel.SetActive(false);
    }*/

    void Update()
    {
        // 'E' Ű�� ������ �� �г� ��ȯ
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchToE2Panel();
        }
    }

    void SwitchToE2Panel()
    {
        // EndingCartoon �г��� ��Ȱ��ȭ�ϰ� E2 �г��� Ȱ��ȭ
        endingCartoonPanel.SetActive(false);
        e2Panel.SetActive(true);
    }
}
