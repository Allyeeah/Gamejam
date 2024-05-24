using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Game : MonoBehaviour
{
    public void RestartScene()
    {
        // 현재 활성화된 씬의 이름을 가져옴
        string currentSceneName = SceneManager.GetActiveScene().name;
        // 현재 씬을 다시 로드함
        SceneManager.LoadScene(currentSceneName);
    }
}
