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

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedSprite; // 초기 상태는 닫힌 상태
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
        }
    }
}
