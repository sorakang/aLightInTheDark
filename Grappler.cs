using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    public LayerMask ropeLayerMask;

    public float distance = 90.0f;

    LineRenderer line;
    DistanceJoint2D rope;

    Vector2 lookDirection;

    bool checker = true;

    void Start()
    {
        rope = gameObject.AddComponent<DistanceJoint2D>();
        line = GetComponent<LineRenderer>();

        rope.enabled = false;
        line.enabled = false;
    }

    void Update()
    {
        line.SetPosition(0, transform.position);

        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; 
        Debug.DrawLine(transform.position, lookDirection);

        if (Input.GetMouseButtonDown(0) && checker == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, lookDirection, distance, ropeLayerMask);

            if (hit.collider != null)
            {
                checker = false;
                SetRope(hit);
            }
        }
        else if (Input.GetMouseButtonDown(0) && checker == false)
        {
            checker = true;
            DestroyRope();
        }
    }

    void SetRope(RaycastHit2D hit)
    {
        rope.enabled = true;
        rope.connectedAnchor = hit.point;

        line.enabled = true;
        line.SetPosition(1, hit.point);
    }

    void DestroyRope()
    {
        rope.enabled = false;
        line.enabled = false;
    }


    // public Camera mainCamera;
    // public LineRenderer _lineRenderer;
    // public DistanceJoint2D _distanceJoint;

    // Start is called before the first frame update
    // void Start()
    // {
    //     _distanceJoint.enabled = false;
    // }

    // Update is called once per frame
    // void Update()
    // {

        // if (Input.GetKeyDown(KeyCode.Mouse0))
        // {
        //     Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //     _lineRenderer.SetPosition(0, mousePos);
        //     _lineRenderer.SetPosition(1, transform.position);
        //     _distanceJoint.connectedAnchor = mousePos;
        //     _distanceJoint.enabled = true;
        //     _lineRenderer.enabled = true;
        // }
        // else if (Input.GetKeyUp(KeyCode.Mouse0))
        // {
        //     _distanceJoint.enabled = false;
        //     _lineRenderer.enabled = false;
        // }
        // if (_distanceJoint.enabled) 
        // {
        //     _lineRenderer.SetPosition(1, transform.position);
        // }
    // }
}
