using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorChanger : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer; // ������ ��������Ʈ �������� �����մϴ�.
    public Sprite newSprite; // ���ο� ��������Ʈ�� �����մϴ�.
    public Sprite originalSprite; // ������ ��������Ʈ�� �����մϴ�.

    public GameObject panel; // EŰ�� �� ��° ������ �� ǥ���� �г�
    private bool isSpriteChanged = false; // ��������Ʈ ���� ����
    private bool isPanelShown = false; // �г��� ǥ�õǾ����� ����

    void Start()
    {
        // ���� ��������Ʈ�� �����մϴ�.
        if (targetSpriteRenderer != null)
        {
            originalSprite = targetSpriteRenderer.sprite;
        }
    }

    void Update()
    {
        // EŰ�� ������ �� ��ȣ�ۿ��� ó��
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isSpriteChanged)
            {
                ChangeSprite();
            }
            else if (!isPanelShown)
            {
                ShowPanel();
            }
        }
    }

    void ChangeSprite()
    {
        if (targetSpriteRenderer != null && newSprite != null)
        {
            targetSpriteRenderer.sprite = newSprite;
            isSpriteChanged = true;
        }
    }

    void ShowPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
            isPanelShown = true;
        }
    }
}
