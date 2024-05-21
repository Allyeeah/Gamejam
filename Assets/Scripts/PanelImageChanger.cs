/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;
using UnityEngine.UI;


public class PanelImageChanger : MonoBehaviour
{
    public Image panelImage; // Panel�� Image ������Ʈ�� �����մϴ�.
    public Sprite newSprite; // ������ ���ο� Sprite�� �����մϴ�.

    public Sprite originalSprite; // ������ Sprite�� �����մϴ�.

    void Start()
    {
        // Panel�� ���� Sprite�� �����մϴ�.
        if (panelImage != null)
        {
            originalSprite = panelImage.sprite;
        }

        // Button ������Ʈ�� �����ͼ� Ŭ�� �̺�Ʈ�� ����մϴ�.
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ChangeImage);
        }
    }

    void ChangeImage()
    {
        // �̹����� �����մϴ�.
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
