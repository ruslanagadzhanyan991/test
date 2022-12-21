using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinderscript : MonoBehaviour
{
    private Vector3 localscale;
    private float x;
    private bool peak;
    [SerializeField] private bool stop;
    [SerializeField] Limits limit;
    [SerializeField] GameObject prefab;
    [SerializeField] private float allowedrange;

    private void Start()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f); //random color generation
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
            if (difference <= allowedrange && !stop) //calculating difference between current position and limit, this made in order to achieve this floating area in which player can land in order it to be considered as a streak.
            {
                limit.streak++;
                limit.score++;
            }
            if (!stop) //updating maximum limit, updating score and spawning next cylinder
            {
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
            localscale.y += Time.deltaTime;
            transform.localScale = localscale;
        }

        else if (peak)
        {
            localscale = transform.localScale;
            localscale.y -= Time.deltaTime;
            transform.localScale = localscale;
        }
    }

    private void newcylinderspawn()//spawning new cylinder and assigning important variables
    {
        x = transform.position.x + 2;
        Vector3 newspawnposition = new Vector3(x, transform.position.y, transform.position.z);
        GameObject value = (GameObject)Instantiate(prefab, newspawnposition, Quaternion.identity);
        if (value.TryGetComponent(out Cylinderscript cilinder))
        {
            cilinder.limit = limit;
        }
    }
}
