using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string Outside; // �̵��� ���� ���� �̸��� �Է��մϴ�.

    void OnMouseDown()
    {
        // ��� ������Ʈ�� Ŭ���Ǿ��� �� ���� �����մϴ�.
        if (!string.IsNullOrEmpty(Outside))
        {
            SceneManager.LoadScene(Outside);
        }
    }
}
