using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PronounCatcher : MonoBehaviour {
    public delegate void PronounLeaveHandler ();
    public static event PronounLeaveHandler PronounLeaveEvent;
    void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.tag == "Pronoun" && PronounLeaveEvent != null) {
            PronounLeaveEvent ();
        }
    }
}