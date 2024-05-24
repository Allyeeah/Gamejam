using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string Outside;
    private bool playerInRange = false;
    /*public void ChangeScene(string Outside)
    {
        SceneManager.LoadScene(Outside);
    }*/

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E)) // �÷��̾ ���� ���� �ְ� 'E' Ű�� ������
        {
            if (!string.IsNullOrEmpty(Outside))
            {
                Debug.Log("Loading scene: " + Outside);
                SceneManager.LoadScene(Outside); // ���� ������ ��ȯ
            }
            else
            {
                Debug.LogError("Scene name 'Outside' is not set!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered the trigger area.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player exited the trigger area.");
        }
    }
}
