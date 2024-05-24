using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassRoomCardKey : MonoBehaviour
{
    public static ClassRoomCardKey Instance { get; private set; }

    public bool hasCardKey = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ObtainCardKey()
    {
        hasCardKey = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LockerController locker = GetComponentInParent<LockerController>();
            if (locker != null)
            {
                ObtainCardKey();
                hasCardKey = true;
                locker.CollectCardKey();
            }
        }
    }
}
