using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pronoun : MonoBehaviour
{
    public delegate void PronounCaughtAction();
    public static event PronounCaughtAction OnPronounCaught;

    protected string correctPronoun;

    protected bool clicked = false;

    public void OnMouseDown()
    {
        if (!clicked)
        {
            PronounCaught();
            clicked = true;
        }
    }

    protected void PronounCaught()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = correctPronoun;
        gameObject.GetComponentInChildren<ParticleSystem>().Play();
        if (OnPronounCaught != null)
        {
            OnPronounCaught();
        }
    }
}