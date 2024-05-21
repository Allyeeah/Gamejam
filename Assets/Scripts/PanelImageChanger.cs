/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;
using UnityEngine.UI;


public class PanelImageChanger : MonoBehaviour
{
    public Image panelImage; // Panel의 Image 컴포넌트를 참조합니다.
    public Sprite newSprite; // 변경할 새로운 Sprite를 참조합니다.

    public Sprite originalSprite; // 원래의 Sprite를 저장합니다.

    void Start()
    {
        // Panel의 원래 Sprite를 저장합니다.
        if (panelImage != null)
        {
            originalSprite = panelImage.sprite;
        }

        // Button 컴포넌트를 가져와서 클릭 이벤트를 등록합니다.
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ChangeImage);
        }
    }

    void ChangeImage()
    {
        // 이미지를 변경합니다.
        if (panelImage != null && newSprite != null)
        {
            if (panelImage.sprite == originalSprite)
            {
                panelImage.sprite = newSprite;
            }
            else
            {
                panelImage.sprite = originalSprite;
            }
        }
    }
}
