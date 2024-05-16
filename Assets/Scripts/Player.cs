using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // GameManager�� ã���ϴ�.
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) // 'O' Ű�� �� ����
        {
            gameManager.OpenDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KeyButton"))
        {
            gameManager.SendMessage("OnTriggerEnter", other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("KeyButton"))
        {
            gameManager.SendMessage("OnTriggerExit", other);
        }
    }
}
