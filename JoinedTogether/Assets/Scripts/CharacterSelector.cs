using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public Rigidbody2D cyanRB;
    public Rigidbody2D yellowRB;
    public Rigidbody2D magentaRB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "CyanSelector")
        {
            cyanRB.constraints = RigidbodyConstraints2D.FreezeRotation;
            yellowRB.constraints = RigidbodyConstraints2D.FreezeAll;
            magentaRB.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (collision.name == "MagentaSelector")
        {
            magentaRB.constraints = RigidbodyConstraints2D.FreezeRotation;
            yellowRB.constraints = RigidbodyConstraints2D.FreezeAll;
            cyanRB.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (collision.name == "YellowSelector")
        {
            yellowRB.constraints = RigidbodyConstraints2D.FreezeRotation;
            magentaRB.constraints = RigidbodyConstraints2D.FreezeAll;
            cyanRB.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

}
