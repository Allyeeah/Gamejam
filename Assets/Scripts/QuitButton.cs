using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static System.Net.Mime.MediaTypeNames;

public class QuitButton : MonoBehaviour
{

    // QuitButton �޼��带 ���� Application.Quit�� ȣ��
    public void QuitGame()
    {
        // �����Ϳ��� ���� ���� ���� ������ ������� �ʱ� ������ ���������� Ȯ��
    #if UNITY_EDITOR
        // UnityEditor.EditorApplication.isPlaying�� false�� �����Ͽ� ������ ������ ����
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        // ����� ���ӿ����� Application.Quit()�� ȣ���Ͽ� ������ ����
        Application.Quit();
    #endif
    }
}
