using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTopUnfade : MonoBehaviour
{
    public CameraScript topCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "CyanSelector")
        {
            topCamera.Fade(false);
        }
    }
}
