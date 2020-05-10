using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechController : MonoBehaviour {

    public int interruptIndex = 2;
    public GameObject interruption;
    public GameObject speechBubble;

    // Start is called before the first frame update
    void Start () {
        GenerateSpeech ();
    }

    private void GenerateSpeech () {
        for (int i = 0; i < 10; i++) {
            GameObject speech = Instantiate (speechBubble);
            speech.transform.SetParent (gameObject.transform, false);
        }
    }

    public void Interrupt () {
        GameObject interrupt = Instantiate (interruption);
        interrupt.transform.SetParent (gameObject.transform, false);
        interrupt.transform.SetSiblingIndex (interruptIndex);
    }
}