using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorChanger : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer; // ������ ��������Ʈ �������� �����մϴ�.
    public Sprite newSprite; // ���ο� ��������Ʈ�� �����մϴ�.

    public Sprite originalSprite; // ������ ��������Ʈ�� �����մϴ�.

    public GameObject panel; // QŰ�� ������ �� ǥ���� �г�
    private bool isSpriteChanged = false; // ��������Ʈ ���� ����


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
        // QŰ�� ������ �� �г��� Ȱ��ȭ�մϴ�.
        if (Input.GetKeyDown(KeyCode.Q) && isSpriteChanged)
        {
            if (panel != null)
            {
                panel.SetActive(true);
            }
        }
    }

    void OnMouseDown()
    {
        // ��������Ʈ�� �����մϴ�.
        if (targetSpriteRenderer != null && newSprite != null)
        {
            if (targetSpriteRenderer.sprite == originalSprite)
            {
                targetSpriteRenderer.sprite = newSprite;
                isSpriteChanged = true;
            }
            else
            {
                targetSpriteRenderer.sprite = originalSprite;
                isSpriteChanged = false;
            }
        }
    }
}
