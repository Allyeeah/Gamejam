using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartView : MonoBehaviour
{
    public GameObject startView;
    public GameObject KeyGuideView;

    void Start()
    {
      
        // KeyGuideView를 초기 상태에서 비활성화
        if (KeyGuideView != null)
        {
            KeyGuideView.SetActive(false);
        }
        else
        {
            Debug.LogError("KeyGuideView is not assigned in the Inspector.");
        }
    }

    public void HideAndCreateNewPanel()
    {
        if (startView != null)
        {
            startView.SetActive(false);
            Debug.Log("Start View Panel hidden");
        }
       
        //새로운 패널 활성화
        if(KeyGuideView != null)
        {
            
            KeyGuideView.SetActive(true);
            Debug.Log("Key Guide Panel activated.");


        }
        
    }

}
