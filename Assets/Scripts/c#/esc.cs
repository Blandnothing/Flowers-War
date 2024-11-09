using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Esc : MonoBehaviour
{
    public GameObject esc;
    [SerializeField] private bool menuKey = true;

    private void Update()
    {
        if (menuKey)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                esc.SetActive(true);
                menuKey = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            esc.SetActive(false);
            menuKey = true;
        }
    }
    public void Return()
    {
        esc.SetActive(false);
        menuKey = true;
    }
    public void Exit()
    {
        Application.Quit();
    }
}