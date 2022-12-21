using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    [SerializeField] private GameObject Startingscreen;
    [SerializeField] private bool gamestart; 
    private void Start()
    {
        Time.timeScale = 0;//necessary to pause the game so cylinder would not change properties on the background
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !gamestart) //start the game
        {
            Time.timeScale = 1;
            Startingscreen.SetActive(false);
            gamestart = true;
        }
    }
}
