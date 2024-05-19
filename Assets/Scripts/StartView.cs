using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

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
