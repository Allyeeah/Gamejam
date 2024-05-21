using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorChanger : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer; // 변경할 스프라이트 렌더러를 참조합니다.
    public Sprite newSprite; // 새로운 스프라이트를 참조합니다.

    public Sprite originalSprite; // 원래의 스프라이트를 저장합니다.

    public GameObject panel; // Q키를 눌렀을 때 표시할 패널
    private bool isSpriteChanged = false; // 스프라이트 변경 여부


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
        // Q키를 눌렀을 때 패널을 활성화합니다.
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
        // 스프라이트를 변경합니다.
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
