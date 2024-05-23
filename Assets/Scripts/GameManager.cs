using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ClearPanel;
    public GameObject StartPanel;
   // public GameObject keybutton;
   // public bool gotkey = false;

    //private bool isnearkeybutton = false;

    
    void Update()
    {
        //if (isnearkeybutton && Input.GetKeyDown(Keycode.E))
        //{
        //    getkey();
        //}
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("check");
            ClearPanel.SetActive(true);
        }

    }

 
        //public void opendoor()
        //{
        //    if (gotkey == true)
        //    {
        //        ClearPanel.setactive(true);
        //    }
        //}

        //public void getkey()
        //{
        //    gotkey = true;
        //    destroy(keybutton);
        //}

        //private void OnTriggerEnter2D(Collider2D other)
        //{
        //    if (other.gameobject == keybutton)
        //    {
        //        isnearkeybutton = true;
        //    }
        //}

        //private void OnTriggerExit2D(Collider2D other)
        //{
        //    if (other.gameobject == keybutton)
        //    {
        //        isnearkeybutton = false;
        //    }
        //}
    }
