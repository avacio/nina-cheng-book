using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingScale : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float minScale = 1f;
    [SerializeField] private float maxScale = 2f;

    void Update()
    {
        float scale = Mathf.PingPong(Time.time * speed, maxScale - minScale) + minScale;
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
