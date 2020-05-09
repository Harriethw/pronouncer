using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pronoun : MonoBehaviour {
    public delegate void OnPronounCaught ();
    public static OnPronounCaught onPronounCaught;

    protected string correctPronoun;

    protected bool clicked = false;

    public void OnMouseDown () {
        if (!clicked) {
            PronounCaught ();
            clicked = true;
        }
    }

    protected void PronounCaught () {
        if (onPronounCaught != null) {
            onPronounCaught ();
        }
        gameObject.GetComponent<TMPro.TextMeshProUGUI> ().text = correctPronoun;
        gameObject.GetComponentInChildren<ParticleSystem> ().Play ();
    }
}