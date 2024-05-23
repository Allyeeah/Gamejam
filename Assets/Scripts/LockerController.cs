using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite closedSprite; // ���� ������ ��������Ʈ
    public Sprite openSprite;   // ���� ������ ��������Ʈ
    private bool isOpen = false;
    private static LockerController selectedLocker;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedSprite; // �ʱ� ���´� ���� ����
    }

    void OnMouseDown()
    {
        selectedLocker = this; // �繰�� Ŭ�� �� ���õ� �繰������ ����
    }

    void Update()
    {
        if (selectedLocker == this && Input.GetKeyDown(KeyCode.E)) // ���õ� �繰���̰� 'E' Ű�� ������
        {
            isOpen = !isOpen;
            spriteRenderer.sprite = isOpen ? openSprite : closedSprite;
        }
    }
}
