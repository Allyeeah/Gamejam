using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBlackScreen : MonoBehaviour
{
    // 마지막 패널과 검은 화면 패널을 연결합니다.
    public GameObject lastPanel;
    public GameObject blackScreenPanel;

    void Start()
    {
        lastPanel.SetActive(false);
        // 검은 화면 패널을 비활성화합니다.
        blackScreenPanel.SetActive(false);
    }

    void Update()
    {
        // 마지막 패널이 활성화된 상태에서 'E' 키 입력을 감지합니다.
        if (lastPanel.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            
            // 검은 화면 패널을 활성화합니다.
            blackScreenPanel.SetActive(true);

            // 필요에 따라 마지막 패널을 비활성화할 수도 있습니다.
            // lastPanel.SetActive(false);
        }
    }
}
