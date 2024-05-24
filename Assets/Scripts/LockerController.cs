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

    private bool playerInRange = false;
    public GameObject cardKey;  // ī��Ű ������Ʈ
    public ParticleSystem particleSystem; // ��ƼŬ �ý��� ������Ʈ

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedSprite; // �ʱ� ���´� ���� ����

        if (cardKey != null)
        {
            cardKey.SetActive(false); // �繰���� ���� ���� �� ī��Ű ��Ȱ��ȭ
        }
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
            Debug.Log(isOpen ? "Locker opened." : "Locker closed.");

            if (isOpen)
            {
                if (cardKey != null)
                {
                    cardKey.SetActive(true); // �繰���� ������ ī��Ű Ȱ��ȭ
                    Debug.Log("CardKey activated.");
                }

                if (particleSystem != null)
                {
                    particleSystem.Stop(); // �繰���� ������ ��ƼŬ �ý��� ��Ȱ��ȭ
                    Debug.Log("Particle system stopped.");
                }
            }
            else
            {
                if (cardKey != null)
                {
                    cardKey.SetActive(false); // �繰���� ������ ī��Ű ��Ȱ��ȭ
                    Debug.Log("CardKey deactivated.");
                }

                if (particleSystem != null)
                {
                   // particleSystem.Play(); // �繰���� ������ ��ƼŬ �ý��� Ȱ��ȭ
                    Debug.Log("Particle system started.");
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �÷��̾ �繰�Կ� ���� ��
        {
            playerInRange = true;
            selectedLocker = this; // �繰���� ���õ� �繰������ ����
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �÷��̾ �繰���� ���� ��
        {
            playerInRange = false;
            if (selectedLocker == this)
            {
                selectedLocker = null; // �÷��̾ �繰�� ������ ������ ���� ����
            }
        }
    }

    public void CollectCardKey()
    {
        if (cardKey != null && cardKey.activeSelf)
        {
            Debug.Log("CollectCardKey called."); // ����� �α� �߰�
            Destroy(cardKey.gameObject);
            //cardKey.SetActive(false); // ī��Ű�� ȹ���ϸ� ��Ȱ��ȭ
            // ���⿡ ī��Ű�� �κ��丮�� �߰��ϴ� ������ �߰��� �� �ֽ��ϴ�.
            Debug.Log("CardKey collected!");
        }
    }




}
