using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LightRender flash;

    public float speedRoam;
    public float speedChase;
    private float waitTime;
    public float startWaitTime;
    public float distance;

    public Transform[] moveSpots;
    private int randomSpot;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //sets player as target
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //sets range for AI to move randomly
        randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;

        //finding error for mission comma?
        //setting distance between player position and enemy position
        // distance = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Enemy").transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        if(LightRender.on = true || (GameObject.FindGameObjectWithTag("Player").transform.position-this.transform.position).sqrMagnitude<3*3)
        {
            if((GameObject.FindGameObjectWithTag("Player").transform.position-this.transform.position).sqrMagnitude<3*3)
            {
                //begin chasing after player
                transform.position = Vector2.MoveTowards(transform.position, target.position, speedChase * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speedRoam * Time.deltaTime);
            }
        }
        else
        {
            //moves AI from current position to random position with speed
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speedRoam * Time.deltaTime);

            //if close to random spot, move to new random spot
            if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }
}
