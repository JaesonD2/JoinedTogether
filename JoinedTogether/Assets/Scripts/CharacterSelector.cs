using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public string currentSelected;
    private Rigidbody2D cyanRB;
    private Rigidbody2D yellowRB;
    private Rigidbody2D magentaRB;

    public GameObject CyanSelector;
    public GameObject YellowSelector;
    public GameObject MagentaSelector;

    private Animator CyanAnimator;
    private Animator MagentaAnimator;
    private Animator YellowAnimator;

    private SpriteRenderer cyanRenderer;
    private SpriteRenderer yellowRenderer;
    private SpriteRenderer magentaRenderer;

    private Color normalCyan;
    private Color fadedCyan;

    private Color normalYellow;
    private Color fadedYellow;

    private Color normalMagenta;
    private Color fadedMagenta;

    public GameObject CyanPlayer;
    public GameObject MagentaPlayer;
    public GameObject YellowPlayer;

    private string CyanCollider = "CyanSelector";
    private string MagentaCollider = "MagentaSelector";
    private string YellowCollider = "YellowSelector";
    private string RedCollider = "RedSelector";

    private void Start()
    {
        cyanRB = CyanPlayer.GetComponent<Rigidbody2D>();
        magentaRB = MagentaPlayer.GetComponent<Rigidbody2D>();
        yellowRB = YellowPlayer.GetComponent<Rigidbody2D>();

        cyanRenderer = CyanSelector.GetComponent<SpriteRenderer>();
        yellowRenderer = YellowSelector.GetComponent<SpriteRenderer>();
        magentaRenderer = MagentaSelector.GetComponent<SpriteRenderer>();

        normalCyan = cyanRenderer.color;
        fadedCyan = new Color(normalCyan.r, normalCyan.g, normalCyan.b, .5f);
        normalMagenta = magentaRenderer.color;
        fadedMagenta = new Color(normalMagenta.r, normalMagenta.g, normalMagenta.b, .5f);
        normalYellow = yellowRenderer.color;
        fadedYellow = new Color(normalYellow.r, normalYellow.g, normalYellow.b, .5f);

        CyanAnimator = CyanPlayer.GetComponentInChildren<Animator>();
        MagentaAnimator = MagentaPlayer.GetComponentInChildren<Animator>();
        YellowAnimator = YellowPlayer.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == CyanCollider && currentSelected != CyanCollider)
        {
            currentSelected = collision.name;
            cyanRB.constraints = RigidbodyConstraints2D.FreezeRotation;
            yellowRB.constraints = RigidbodyConstraints2D.FreezeAll;
            magentaRB.constraints = RigidbodyConstraints2D.FreezeAll;

            CyanAnimator.SetBool("CurrentlyActive", true);
            MagentaAnimator.SetBool("CurrentlyActive", false);
            YellowAnimator.SetBool("CurrentlyActive", false);

            cyanRenderer.color = fadedCyan;
            yellowRenderer.color = normalYellow;
            magentaRenderer.color = normalMagenta;

            CyanSelector.transform.localScale = new Vector3(0.4f, 0.4f, 1);
            YellowSelector.transform.localScale = new Vector3(0.6f, 0.6f, 1);
            MagentaSelector.transform.localScale = new Vector3(0.6f, 0.6f, 1);
        }
        if (collision.name == MagentaCollider && currentSelected != MagentaCollider)
        {
            currentSelected = collision.name;
            magentaRB.constraints = RigidbodyConstraints2D.FreezeRotation;
            yellowRB.constraints = RigidbodyConstraints2D.FreezeAll;
            cyanRB.constraints = RigidbodyConstraints2D.FreezeAll;

            CyanAnimator.SetBool("CurrentlyActive", false);
            MagentaAnimator.SetBool("CurrentlyActive", true);
            YellowAnimator.SetBool("CurrentlyActive", false);

            cyanRenderer.color = normalCyan;
            yellowRenderer.color = normalYellow;
            magentaRenderer.color = fadedMagenta;

            CyanSelector.transform.localScale = new Vector3(0.6f, 0.6f, 1);
            YellowSelector.transform.localScale = new Vector3(0.6f, 0.6f, 1);
            MagentaSelector.transform.localScale = new Vector3(0.4f, 0.4f, 1);
        }
        if (collision.name == YellowCollider && currentSelected != YellowCollider)
        {
            currentSelected = collision.name;
            yellowRB.constraints = RigidbodyConstraints2D.FreezeRotation;
            magentaRB.constraints = RigidbodyConstraints2D.FreezeAll;
            cyanRB.constraints = RigidbodyConstraints2D.FreezeAll;

            CyanAnimator.SetBool("CurrentlyActive", false);
            MagentaAnimator.SetBool("CurrentlyActive", false);
            YellowAnimator.SetBool("CurrentlyActive", true);

            cyanRenderer.color = normalCyan;
            yellowRenderer.color = fadedYellow;
            magentaRenderer.color = normalMagenta;

            CyanSelector.transform.localScale = new Vector3(0.6f, 0.6f, 1);
            YellowSelector.transform.localScale = new Vector3(0.4f, 0.4f, 1);
            MagentaSelector.transform.localScale = new Vector3(0.6f, 0.6f, 1);
        }
        if (collision.name == RedCollider && currentSelected != RedCollider)
        {
            currentSelected = collision.name;
            yellowRB.constraints = RigidbodyConstraints2D.FreezeAll;
            magentaRB.constraints = RigidbodyConstraints2D.FreezeAll;
            cyanRB.constraints = RigidbodyConstraints2D.FreezeAll;

            CyanAnimator.SetBool("CurrentlyActive", false);
            MagentaAnimator.SetBool("CurrentlyActive", false);
            YellowAnimator.SetBool("CurrentlyActive", false);

            cyanRenderer.color = normalCyan;
            yellowRenderer.color = normalYellow;
            magentaRenderer.color = normalMagenta;

            CyanSelector.transform.localScale = new Vector3(0.6f, 0.6f, 1);
            YellowSelector.transform.localScale = new Vector3(0.6f, 0.6f, 1);
            MagentaSelector.transform.localScale = new Vector3(0.6f, 0.6f, 1);
        }
    }
}
