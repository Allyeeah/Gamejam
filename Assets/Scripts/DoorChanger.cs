using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorChanger : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer; // 변경할 스프라이트 렌더러를 참조합니다.
    public Sprite newSprite; // 새로운 스프라이트를 참조합니다.
    public Sprite originalSprite; // 원래의 스프라이트를 저장합니다.

    public GameObject panel; // E키를 두 번째 눌렀을 때 표시할 패널
    private bool isSpriteChanged = false; // 스프라이트 변경 여부
    private bool isPanelShown = false; // 패널이 표시되었는지 여부

    void Start()
    {
        // 원래 스프라이트를 저장합니다.
        if (targetSpriteRenderer != null)
        {
            originalSprite = targetSpriteRenderer.sprite;
        }
    }

    void Update()
    {
        // E키를 눌렀을 때 상호작용을 처리
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
