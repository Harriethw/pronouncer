using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pronoun : MonoBehaviour {

    public delegate void OnPronounCaught ();
    public static OnPronounCaught onPronounCaught;

    private string correctPronoun;

    private bool clicked = false;

    void Start () {
        correctPronoun = PronounValues.GetPronoun1 () != null ? PronounValues.GetPronoun1 () : "they";
    }

    public void OnMouseDown () {
        if (!clicked) {
            PronounCaught ();
            clicked = true;
        }
    }

    private void PronounCaught () {
        if (onPronounCaught != null) {
            onPronounCaught ();
        }
        gameObject.GetComponent<TMPro.TextMeshProUGUI> ().text = correctPronoun;
        gameObject.GetComponentInChildren<ParticleSystem> ().Play ();
    }
}