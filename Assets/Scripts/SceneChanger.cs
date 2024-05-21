using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string Outside; // 이동할 다음 씬의 이름을 입력합니다.

    void OnMouseDown()
    {
        // 계단 오브젝트가 클릭되었을 때 씬을 변경합니다.
        if (!string.IsNullOrEmpty(Outside))
        {
            SceneManager.LoadScene(Outside);
        }
    }
}
