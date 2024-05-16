using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // GameManager를 찾습니다.
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) // 'O' 키로 문 열기
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
