using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelImageChanger : MonoBehaviour
{
    // �г� �迭
    public GameObject[] panels;
    // ���� Ȱ��ȭ�� �г� �ε���
    private int currentPanelIndex = 0;
    public GameObject EndingCartoon;

    void Start()
    {
        // ��� �г��� ��Ȱ��ȭ ���·� ����
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        // ù ��° �г��� Ȱ��ȭ
        if (panels.Length > 0)
        {
            panels[0].SetActive(true);
        }
    }

    void Update()
    {
        // "E" Ű �Է� ����
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

        // ����� �޽���: ���� �г� �ε��� �� �г� �迭 ����
        Debug.Log($"Current Panel Index: {currentPanelIndex}, Panels Length: {panels.Length}");

        // ���� �г� ��Ȱ��ȭ
        if (currentPanelIndex >= 0 && currentPanelIndex < panels.Length)
        {
            panels[currentPanelIndex].SetActive(false);
        }
        else
        {
            Debug.LogError($"Current panel index {currentPanelIndex} is out of bounds.");
            return;
        }

        // ���� �г� �ε��� ���
        currentPanelIndex++;

        /*//��� �г� ��Ȱ��ȭ
        if (currentPanelIndex >= panels.Length)
        {
            Debug.Log("All panels are now hidden.");
            if (EndingCartoon != null)
            {
                EndingCartoon.SetActive(false);
            }

            currentPanelIndex = -1; // ��� �г��� ��Ȱ��ȭ�Ǿ����� ǥ��
            return;
*/

            // ���� �г� Ȱ��ȭ
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



