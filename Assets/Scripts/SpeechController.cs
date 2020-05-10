using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechController : MonoBehaviour {

    public GameObject speechBubble;
    // Start is called before the first frame update
    void Start () {
        GenerateSpeech ();
    }

    private void GenerateSpeech () {
        for (int i = 0; i < 10; i++) {
            GameObject speech = Instantiate (speechBubble);
            speech.transform.SetParent (gameObject.transform, false);
            Debug.Log (speech.transform.GetSiblingIndex ());
        }
    }
}