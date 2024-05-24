using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCartoon : MonoBehaviour
{
    public GameObject endingCartoonPanel;
    public GameObject e2Panel;

   /* void Start()
    {
        // 시작할 때 EndingCartoon 패널은 활성화하고 E2 패널은 비활성화
        endingCartoonPanel.SetActive(true);
        e2Panel.SetActive(false);
    }*/

    void Update()
    {
        // 'E' 키를 눌렀을 때 패널 전환
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchToE2Panel();
        }
    }

    void SwitchToE2Panel()
    {
        // EndingCartoon 패널을 비활성화하고 E2 패널을 활성화
        endingCartoonPanel.SetActive(false);
        e2Panel.SetActive(true);
    }
}
