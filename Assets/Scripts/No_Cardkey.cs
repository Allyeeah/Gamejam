using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class No_Cardkey : MonoBehaviour
{
    public GameObject monsterSprite;

    private ClassRoomCardKey cardKeyManager;
    void Update()
{
    if (!ClassRoomCardKey.Instance.hasCardKey)
    {
        ActivateMonsterSprite();
    }
}

void ActivateMonsterSprite()
{
    if (monsterSprite != null && !monsterSprite.activeInHierarchy)
    {
        monsterSprite.SetActive(true);
    }
}
}
