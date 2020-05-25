using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptionIndex : MonoBehaviour {
    void OnTriggerEnter2D (Collider2D collider) {
        SpeechController.interruptIndex = collider.gameObject.transform.GetSiblingIndex ();
    }
}