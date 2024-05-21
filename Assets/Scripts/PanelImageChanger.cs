using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelImageChanger : MonoBehaviour
{
    public Image panelImage; // Panel의 Image 컴포넌트를 참조합니다.
    public Sprite newSprite; // 변경할 새로운 Sprite를 참조합니다.

    private Sprite originalSprite; // 원래의 Sprite를 저장합니다.

    void Start()
    {
        // Panel의 원래 Sprite를 저장합니다.
        if (panelImage != null)
        {
            originalSprite = panelImage.sprite;
        }
    }

    void Update()
    {
        // 마우스 왼쪽 버튼이 눌렸는지 확인합니다.
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 포지션에서 Ray를 생성합니다.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ray가 Panel에 맞았는지 확인합니다.
            if (Physics.Raycast(ray, out hit))
            {
                // 클릭된 오브젝트가 Panel인지 확인합니다.
                if (hit.transform == transform)
                {
                    ChangeImage();
                }
            }
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
