using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public float amplitude = 0.2f;
    public float frequency = 0.5f;

    Vector2 startPos;
    Vector2 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = startPos;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
