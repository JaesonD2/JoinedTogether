using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public Rigidbody2D blueRB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "BlueSelector")
        {
            blueRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

}
