using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private LineRenderer _lineRenderer;
    private Transform _closest;
    private SpringJoint2D _springJoint2D;

    private float _maxSpeed = 30f;

    public GameObject hitEffect;
    public float forceAmount;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _lineRenderer = GetComponent<LineRenderer>();

        _lineRenderer.positionCount = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // get the closest hinge
            _closest = GetClosestHinge(GameObject.FindGameObjectsWithTag("hinge"));
            // attach joint to it
            _springJoint2D = _closest.GetComponent<SpringJoint2D>();
            _springJoint2D.connectedBody = _rigidbody2D;
            // set line renderer position count
            _lineRenderer.positionCount = 2;
        }

        if (Input.GetMouseButton(0))
        {
            // draw line from player to hinge
            _lineRenderer.SetPosition(0,transform.position);
            _lineRenderer.SetPosition(1,_closest.position);
            _rigidbody2D.AddForce( transform.forward * forceAmount,ForceMode2D.Impulse );
            
            if (_springJoint2D.distance > 3)
            {
                _springJoint2D.distance -= 0.01f;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            // remove line and hinge
            _lineRenderer.positionCount = 0;
            _springJoint2D.connectedBody = null;
        }
    }


    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity.magnitude > _maxSpeed)
        {
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * _maxSpeed;
        }
    }

    Transform GetClosestHinge(GameObject[] hinges)
    {
        Transform closest = null;
        var closestDistanceSqr = Mathf.Infinity;
        var currentPosition = transform.position;
        foreach (var potentialTarget in hinges)
        {
            var directionToTarget = potentialTarget.transform.position - currentPosition;
            var dSqrToTarget = directionToTarget.sqrMagnitude;
            if (!(dSqrToTarget < closestDistanceSqr)) continue;
            closestDistanceSqr = dSqrToTarget;
            closest = potentialTarget.transform;
        }

        return closest;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(hitEffect, other.transform.position, Quaternion.identity);
        Destroy(other.gameObject);
    }
}