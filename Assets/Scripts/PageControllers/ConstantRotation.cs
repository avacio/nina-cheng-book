using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 25f;
    private void Update()
    {
        transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
    }
}
