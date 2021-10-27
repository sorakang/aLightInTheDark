using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRender : MonoBehaviour
{
    public GameObject light2d;
    public static bool on = false;
    
    float startTime = 0f;
    float holdTime = 5f;
    // float startWaitTime = 0f;
    // float waitTime = 5.0f;
    // bool wait = false;

    //tried implementing a wait time to resuse light but set an accidental 

    void Update()
    {
        //on space press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //starts timer
            startTime = Time.time;
        }

        //while holding space
        if (Input.GetKey(KeyCode.Space))
        {
            light2d.SetActive(true);
            on = true;
            
            //after x seconds, light turns off
            if (startTime + holdTime <= Time.time)
            {
            light2d.SetActive(false);
            on = false;
            // wait = true;
            // startWaitTime = Time.time;
            }
        }
        else
        {
        light2d.SetActive(false);
        on = false;
            // while (wait = true)
            // {
            //     if (startTime + waitTime <= Time.time)
            //     {
            //         if (Input.GetKey(KeyCode.Space))
            //         {
            //             Debug.Log("Flash is ready");
            //         }
            //         else
            //         {
            //             Debug.Log("Please Wait 5 Seconds");
            //         }
            //     }
            // }
        }
    }
}
