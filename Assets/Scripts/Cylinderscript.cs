using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinderscript : MonoBehaviour
{
    private Vector3 localscale;
    private float x;
    private float y;
    private bool peak;
    [SerializeField] private bool stop;
    [SerializeField] private Limits limit;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject cube;
    [SerializeField] private float allowedrange;
    [SerializeField] private Renderer objcolor;
    [SerializeField] private float scalingspeed;

    private void Start()
    {
        objcolor.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f); //random color generation
        stop = false;
        limit.camtargetswitch(transform); //assigning current object as target for camera to look at
    }
    void Update()
    {
        if (localscale.y >= limit.limits)
        {
            peak = true;
        }

        if (localscale.y <= limit.minimalsize)
        {
            peak = false;
        }
        //conditions adove decide if y scale is going to upscale or downscale
        if (!stop)
        {
            Scalechange();
        }

        if (Input.GetButtonDown("Jump") && Time.timeScale == 1) // Time.timeScale == 1 is important to include because without it player will loose on the starting screen
        {
            float difference = limit.limits - localscale.y;
            if (limit.limits == 0)
            {
                limit.streak++;
            }

            else
            {
                if (difference <= allowedrange && !stop) //calculating difference between current position and limit, this made in order to achieve this floating area in which player can land in order it to be considered as a streak.
                {
                    limit.streak++;
                }
                else if (difference >= allowedrange && !stop)
                {
                    limit.streak = 0;
                }
            }
            if (!stop) //updating maximum limit, updating score and spawning next cylinder
            {
                limit.score++;
                limit.limits = localscale.y;
                limit.sendlimit();
                limit.sendscore();
                newcylinderspawn();
            }
            stop = true;
        }
    }

    private void Scalechange() //changing y scale of cylinder
    {
        if (!peak)
        {
            localscale = transform.localScale;
            localscale.y += Time.deltaTime * scalingspeed;
            transform.localScale = localscale;
        }

        else if (peak)
        {
            localscale = transform.localScale;
            localscale.y -= Time.deltaTime * scalingspeed;
            transform.localScale = localscale;
        }
    }

    private void newcylinderspawn()//spawning new cylinder and assigning important variables
    {
        x = transform.position.x + 1.05f;
        Vector3 newspawnposition = new Vector3(x, transform.position.y, transform.position.z);
        GameObject value = (GameObject)Instantiate(prefab, newspawnposition, Quaternion.identity);
        if (value.TryGetComponent(out Cylinderscript cilinder))
        {
            cilinder.limit = limit;
        }
        y = transform.position.y + 0.1f;
        Vector3 cubepawnposition = new Vector3(x, y, transform.position.z);
        GameObject losecube = (GameObject)Instantiate(cube, cubepawnposition, Quaternion.identity);
    }
}
