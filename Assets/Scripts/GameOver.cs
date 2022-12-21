using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameoverscreen;
    [SerializeField] private bool gameoverbool;

    private void Update()
    {
        if (gameoverbool && Input.GetButtonDown("Fire1")) //restarting the scene
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void gameover() //Triggering game over screen and stopping the game
    {
        gameoverscreen.SetActive(true);
        gameoverbool = true;
        Time.timeScale = 0;
    }
}
