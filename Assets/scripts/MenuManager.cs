using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance {get; set;}

    public GameObject MenuCanvas;

    public bool isMenuOpen;
    
    private void Awake()
    {




    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && !isMenuOpen)
        {
            MenuCanvas.SetActive(true);

            isMenuOpen = true;
            

            Cursor.lockState = CursorLockMode.None;
            
            
        }
        else if(Input.GetKeyDown(KeyCode.M) && isMenuOpen)
        {

            MenuCanvas.SetActive(false);

            isMenuOpen = false;
            

            Cursor.lockState = CursorLockMode.Locked;

        }

    }
}
