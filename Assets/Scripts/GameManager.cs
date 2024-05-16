using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ClearPanel;
    public GameObject KeyButton;
    public bool gotKey = false;

    private bool isNearKeyButton = false;

    void Update()
    {
        if (isNearKeyButton && Input.GetKeyDown(KeyCode.E))
        {
            GetKey();
        }
    }

    public void OpenDoor()
    {
        if (gotKey == true)
        {
            ClearPanel.SetActive(true);
        }
    }

    public void GetKey()
    {
        gotKey = true;
        Destroy(KeyButton);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == KeyButton)
        {
            isNearKeyButton = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == KeyButton)
        {
            isNearKeyButton = false;
        }
    }
}
