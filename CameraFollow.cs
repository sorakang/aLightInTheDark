using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //store cureent camera's position in variable temp
        Vector3 temp = transform.position;

        //set camera's position x = player's position x
        temp.x = playerTransform.position.x;

        //set camera's temp position to camera's position
        transform.position = temp;
    }
}
