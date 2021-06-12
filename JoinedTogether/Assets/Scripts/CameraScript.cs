using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public SpriteRenderer fader;
    public float fadeSpeed = 10f;

    public void Fade(bool fadeToBlack = true)
    {
        StartCoroutine(FadeBlackOutSquare(fadeToBlack));
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true)
    {
        Color objectColor = fader.color;
        float fadeAmount;

        if (fadeToBlack)
        {
            // While not quite black
            while (fader.color.a < 1)
            {
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, objectColor.a + (fadeSpeed * Time.deltaTime));
                fader.color = objectColor;
                yield return null;
            }
        }
        else
        {
            // While not quite invisible
            while (fader.color.a > 0)
            {
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, objectColor.a - (fadeSpeed * Time.deltaTime));
                fader.color = objectColor;
                yield return null;
            }
        }
    }
}
