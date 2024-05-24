using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanel : MonoBehaviour
{
    public GameObject panel; // 패널을 드래그하여 할당할 수 있도록 public으로 선언합니다.

    void Start()
    {
        if (panel == null)
        {
            Debug.LogError("Panel is not assigned.");
        }
    }

    void Update()
    {
        // 'E' 키가 눌렸는지 확인합니다.
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 패널을 비활성화합니다.
            if (panel != null)
            {
                panel.SetActive(false);
            }
        }
    }
}
