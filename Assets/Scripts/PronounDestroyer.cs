using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PronounDestroyer : MonoBehaviour {
    void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.tag == "Pronoun") {
            Destroy (other.gameObject);
        }
    }
}