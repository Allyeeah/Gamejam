using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static System.Net.Mime.MediaTypeNames;

public class QuitButton : MonoBehaviour
{

    // QuitButton 메서드를 만들어서 Application.Quit을 호출
    public void QuitGame()
    {
        // 에디터에서 실행 중일 때는 게임이 종료되지 않기 때문에 에디터인지 확인
    #if UNITY_EDITOR
        // UnityEditor.EditorApplication.isPlaying을 false로 설정하여 에디터 실행을 중지
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        // 빌드된 게임에서는 Application.Quit()을 호출하여 게임을 종료
        Application.Quit();
    #endif
    }
}
