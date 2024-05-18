using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartView : MonoBehaviour
{
    public GameObject startView;

    public void HidePanel()
    {
        if (startView != null)
        {
            startView.SetActive(false);
        }
        
    }
}
