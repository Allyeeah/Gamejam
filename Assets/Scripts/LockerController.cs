using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite closedSprite; // 닫힌 상태의 스프라이트
    public Sprite openSprite;   // 열린 상태의 스프라이트
    private bool isOpen = false;
    private static LockerController selectedLocker;

    private bool playerInRange = false;
    public GameObject cardKey;  // 카드키 오브젝트

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedSprite; // 초기 상태는 닫힌 상태

        if (cardKey != null)
        {
            cardKey.SetActive(false); // 사물함이 닫혀 있을 때 카드키 비활성화
        }
    }

    void OnMouseDown()
    {
        selectedLocker = this; // 사물함 클릭 시 선택된 사물함으로 설정
    }

    void Update()
    {
        if (selectedLocker == this && Input.GetKeyDown(KeyCode.E)) // 선택된 사물함이고 'E' 키가 눌리면
        {
            isOpen = !isOpen;
            spriteRenderer.sprite = isOpen ? openSprite : closedSprite;

            if (isOpen && cardKey != null)
            {
                cardKey.SetActive(true); // 사물함이 열리면 카드키 활성화
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 플레이어가 사물함에 들어올 때
        {
            playerInRange = true;
            selectedLocker = this; // 사물함을 선택된 사물함으로 설정
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 플레이어가 사물함을 나갈 때
        {
            playerInRange = false;
            if (selectedLocker == this)
            {
                selectedLocker = null; // 플레이어가 사물함 범위를 나가면 선택 해제
            }
        }
    }

    public void CollectCardKey()
    {
        if (cardKey != null && cardKey.activeSelf)
        {
            Debug.Log("CollectCardKey called."); // 디버그 로그 추가
            cardKey.SetActive(false); // 카드키를 획득하면 비활성화
            // 여기에 카드키를 인벤토리에 추가하는 로직을 추가할 수 있습니다.
            Debug.Log("CardKey collected!");
        }
    }




}
