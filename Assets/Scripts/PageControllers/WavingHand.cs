using System;
using UnityEngine;

public class WavingHand : MonoBehaviour
{
    [SerializeField] private GameObject armObject = null;
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float startAngleZ;
    [SerializeField] private float endAngleZ;

    private float timeElapsed = 0f;

    private void Reset()
    {
        if (armObject == null)
        {
            armObject = gameObject;
        }
    }

    private void Update ()
    {
        if (armObject)
        {
            float difference = Math.Abs(endAngleZ - startAngleZ);
            float angleZ = startAngleZ + Mathf.Sin(timeElapsed) * difference;

            Vector3 eulers = armObject.transform.eulerAngles;
            eulers.z = angleZ;
            armObject.transform.eulerAngles = eulers;
            timeElapsed += Time.deltaTime * movementSpeed;
        }
    }
}
