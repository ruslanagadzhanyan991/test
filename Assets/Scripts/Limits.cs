using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits : MonoBehaviour
{
    public float limits;
    public float minimalsize;
    public int streak;
    public int score;
    [SerializeField] private Limitdisplay uilmits;
    [SerializeField] private float addition;
    [SerializeField] CameraManager cammanager;
    [SerializeField] private float looselimits;


    private void Update()
    {
        if (streak == 3) //if streak is 3 then limit is increases
        {
            limits += addition;
            streak = 0;
        }

        if (limits <= looselimits)
        {
            uilmits.gameoverscreen.gameover();
        }
    }
    public void sendlimit() //request to update score on UI
    {
        uilmits.limitonui(limits);
    }

    public void sendscore()// request to update score on UI
    {
        uilmits.scoretoui(score);
    }

    public void camtargetswitch(Transform target) // set and/or update the camera target to look at
    {
        cammanager.Target = target;
    }
}
