using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelImageChanger : MonoBehaviour
{
    // 패널 배열
    public GameObject[] panels;
    // 현재 활성화된 패널 인덱스
    private int currentPanelIndex = 0;
    public GameObject EndingCartoon;

    void Start()
    {
        // 모든 패널을 비활성화 상태로 시작
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        // 첫 번째 패널을 활성화
        if (panels.Length > 0)
        {
            panels[0].SetActive(true);
        }
    }

    void Update()
    {
        // "E" 키 입력 감지
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowNextPanel();
        }
    }

    void ShowNextPanel()
    {
        if (panels.Length == 0)
        {
            Debug.LogWarning("No panels to show.");
            return;
        }

        // 디버깅 메시지: 현재 패널 인덱스 및 패널 배열 길이
        Debug.Log($"Current Panel Index: {currentPanelIndex}, Panels Length: {panels.Length}");

        // 현재 패널 비활성화
        if (currentPanelIndex >= 0 && currentPanelIndex < panels.Length)
        {
            panels[currentPanelIndex].SetActive(false);
        }
        else
        {
            Debug.LogError($"Current panel index {currentPanelIndex} is out of bounds.");
            return;
        }

        // 다음 패널 인덱스 계산
        currentPanelIndex++;

        /*//모든 패널 비활성화
        if (currentPanelIndex >= panels.Length)
        {
            Debug.Log("All panels are now hidden.");
            if (EndingCartoon != null)
            {
                EndingCartoon.SetActive(false);
            }

            currentPanelIndex = -1; // 모든 패널이 비활성화되었음을 표시
            return;
*/

            // 다음 패널 활성화
            if (currentPanelIndex >= 0 && currentPanelIndex < panels.Length)
            {
                panels[currentPanelIndex].SetActive(true);
            }
            else
            {
                Debug.LogError($"Next panel index {currentPanelIndex} is out of bounds.");
            }
        }
    }



