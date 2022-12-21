using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Limitdisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text lastlimit;
    [SerializeField] private TMP_Text scoretext;
    public GameOver gameoverscreen;

    public void limitonui(float number) //displaying limit to UI
    {
        lastlimit.text = number.ToString("F2");
    }

    public void scoretoui(int number) //displaying score to UI
    {
        scoretext.text = number.ToString();
    }
}
