using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public bool gotKey = false;
    private bool isNearKey = false;
    public GameObject key;  // Reference to the key GameObject

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearKey && Input.GetKeyDown(KeyCode.E))
        {
            GetKey();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger test");
        if (other.gameObject == key)
        {
            isNearKey = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == key)
        {
            isNearKey = false;
        }
    }

    public void GetKey()
    {
        gotKey = true;
        Destroy(key);
    }
}
