using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PronounController : MonoBehaviour {

    public delegate void OnPronounCaught ();
    public static OnPronounCaught onPronounCaught;

    // Start is called before the first frame update
    void Start () {

    }

    public void OnMouseDown () {
        PronounCaught ();
    }

    private void PronounCaught () {
        onPronounCaught ();
        Destroy (gameObject);
    }
}