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
    //
    // void Update()
    // {
    //     // Move our position a step closer to the target.
    //     var step =  speed * Time.deltaTime; // calculate distance to move
    //     transform.position = Vector3.MoveTowards(transform.position, currentDst, step);
    //
    //     // Check if the position of the cube and sphere are approximately equal.
    //     if (Vector3.Distance(transform.position, currentDst) < 0.1f)
    //     {
    //         // Swap the position of the cylinder.
    //         currentDst = currentDst == pointA
    //             ? pointB
    //             : pointA;
    //     }
    // }

    // [SerializeField] private float timeDurationOneWay = 3f;
    // [SerializeField] private Vector3 dstPosition;
    // [SerializeField] private Vector3 srcPosition;
    //
    // void Start()
    // {
    //     StartCoroutine(LerpPosition(dstPosition, timeDurationOneWay));
    // }
    // IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    // {
    //     float time = 0;
    //     Vector3 startPosition = transform.position;
    //     while (time < duration)
    //     {
    //         transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
    //         time += Time.deltaTime;
    //         yield return null;
    //     }
    //     transform.position = targetPosition;
    // }
}
