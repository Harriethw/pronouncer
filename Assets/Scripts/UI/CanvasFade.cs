using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CanvasFadeHandler ();

public class CanvasFade : MonoBehaviour {
    public static event CanvasFadeHandler OnCanvasFadeOut;

    public void CanvasFadeOut () {
        if (OnCanvasFadeOut != null) {
            OnCanvasFadeOut ();
        }
    }
}