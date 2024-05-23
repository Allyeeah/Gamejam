using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassRoomCardKey : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LockerController locker = GetComponentInParent<LockerController>();
            if (locker != null)
            {
                locker.CollectCardKey();
            }
        }
    }
}
