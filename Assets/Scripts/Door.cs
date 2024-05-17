using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isNearDoor = false;
    public GameObject player;  // Reference to the player GameObject
    public Animator doorAnimator;  // Reference to the door's Animator component

    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization logic if needed
    }

    // Update is called once per frame
    void Update()
    {
        MouseClick mouseClick = player.GetComponent<MouseClick>();

        if (isNearDoor && Input.GetKeyDown(KeyCode.E) && mouseClick.gotKey)
        {
            OpenDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject == player)
        {
            isNearDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            isNearDoor = false;
        }
    }

    private void OpenDoor()
    {
        Debug.Log("door trigger test");
        door.transform.Translate(new Vector3(-10, 0, 0));
        doorAnimator.SetTrigger("Open");  // Assumes there is an "Open" trigger in the Animator
    }
}
