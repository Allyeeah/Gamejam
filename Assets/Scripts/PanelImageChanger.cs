using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelImageChanger : MonoBehaviour
{
    public Image panelImage; // Panel�� Image ������Ʈ�� �����մϴ�.
    public Sprite newSprite; // ������ ���ο� Sprite�� �����մϴ�.

    private Sprite originalSprite; // ������ Sprite�� �����մϴ�.

    void Start()
    {
        // Panel�� ���� Sprite�� �����մϴ�.
        if (panelImage != null)
        {
            originalSprite = panelImage.sprite;
        }
    }

    void Update()
    {
        // ���콺 ���� ��ư�� ���ȴ��� Ȯ���մϴ�.
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 �����ǿ��� Ray�� �����մϴ�.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ray�� Panel�� �¾Ҵ��� Ȯ���մϴ�.
            if (Physics.Raycast(ray, out hit))
            {
                // Ŭ���� ������Ʈ�� Panel���� Ȯ���մϴ�.
                if (hit.transform == transform)
                {
                    ChangeImage();
                }
            }
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
