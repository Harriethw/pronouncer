using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour {
    public delegate void OnPronounLeave ();
    public static OnPronounLeave onPronounLeave;

    void OnTriggerExit2D (Collider2D other) {
        Destroy (other.gameObject);
        if (onPronounLeave != null) {
            onPronounLeave ();
        }
    }
}