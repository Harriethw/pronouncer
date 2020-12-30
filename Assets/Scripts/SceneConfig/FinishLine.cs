using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TextFinishedHandler ();

public class FinishLine : MonoBehaviour {
    public static event TextFinishedHandler OnTextFinished;

    void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.tag == "FinishLine" && OnTextFinished != null) {
            OnTextFinished ();
        }
    }
}