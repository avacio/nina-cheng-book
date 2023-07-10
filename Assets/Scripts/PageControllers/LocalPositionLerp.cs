using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPositionLerp : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector3 pointA;
    [SerializeField] private Vector3 pointB;

    private Vector3 currentDst;

    private void Start()
    {
        currentDst = pointA;
    }


    void Update()
    {
        // Move our position a step closer to the target.
        var step =  speed * Time.deltaTime; // calculate distance to move
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, currentDst, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.localPosition, currentDst) < 0.1f)
        {
            // Swap the position of the cylinder.
            currentDst = currentDst == pointA
                ? pointB
                : pointA;
        }
    }
}
