using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Game : MonoBehaviour
{
    public void RestartScene()
    {
        // ���� Ȱ��ȭ�� ���� �̸��� ������
        string currentSceneName = SceneManager.GetActiveScene().name;
        // ���� ���� �ٽ� �ε���
        SceneManager.LoadScene(currentSceneName);
    }
}
