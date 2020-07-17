using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechController : MonoBehaviour {

    public static int interruptIndex = 3;
    public GameObject interruption;
    public GameObject speechBubble;
    public GameObject interruptButton;
    public Sprite leftSpeechBubble;

    private int interruptCount = 0;

    // Start is called before the first frame update
    void Start () {
        GenerateSpeech ();
    }

    private void GenerateSpeech () {
        List<string> formattedChatter = CopyFormatter.AddWrongPronounsToArray (SpeechCopy.chatter);
        for (int i = 0; i < formattedChatter.Count; i++) {
            GameObject speech = Instantiate (speechBubble);
            speech.transform.SetParent (gameObject.transform, false);
            speech.GetComponentInChildren<TMPro.TextMeshProUGUI> ().text = formattedChatter[i];
            SetHeightOfSpeechBubble (speech.transform);
            if (i % 2 == 0) {
                LeftAlignSpeechBubble (speech);
            }
        }
    }

    private void SetHeightOfSpeechBubble (Transform speechTransform) {
        Canvas.ForceUpdateCanvases ();
        float textHeight = speechTransform.GetChild (0).GetComponent<RectTransform> ().rect.height + 25;
        float currentWidth = speechTransform.GetComponent<RectTransform> ().rect.width;
        speechTransform.GetComponent<RectTransform> ().sizeDelta = new Vector2 (currentWidth, textHeight);
    }

    private void LeftAlignSpeechBubble (GameObject speech) {
        speech.GetComponent<Image> ().sprite = leftSpeechBubble;
        Vector3 childPos = speech.transform.GetChild (0).transform.localPosition;
        childPos = new Vector3 ((childPos.x + 30), childPos.y, 0);
        speech.transform.GetChild (0).transform.localPosition = childPos;
    }

    public void Interrupt () {
        //TODO put this in CopyFormatter
        string formattedInterruption = SpeechCopy.interruption.Replace ("(rightPronoun1)", PronounValues.GetRightPronoun1 ()).Replace ("(rightPronoun2)", PronounValues.GetRightPronoun2 ());
        GameObject interrupt = Instantiate (interruption);
        interrupt.GetComponentInChildren<TMPro.TextMeshProUGUI> ().text = formattedInterruption;
        interrupt.transform.SetParent (gameObject.transform, false);
        interrupt.transform.SetSiblingIndex (interruptIndex);

        GameObject apology = Instantiate (speechBubble);
        apology.GetComponentInChildren<TMPro.TextMeshProUGUI> ().text = SpeechCopy.apologies[0];
        apology.transform.SetParent (gameObject.transform, false);
        apology.transform.SetSiblingIndex (interruptIndex + 1);
        SetHeightOfSpeechBubble (apology.transform);

        ++interruptCount;

        if (interruptCount >= 3) {
            CorrectAllPronouns ();
        }

        StartCoroutine (StopScroll ());
    }

    private void CorrectAllPronouns () {
        GameObject[] speechBubbles = GameObject.FindGameObjectsWithTag ("Speech");
        foreach (var speech in speechBubbles) {
            string speechText = speech.GetComponentInChildren<TMPro.TextMeshProUGUI> ().text;
            speechText = speechText.Replace (PronounValues.GetWrongPronouns1 () [1], PronounValues.GetRightPronoun1 ());
            speechText = speechText.Replace (PronounValues.GetWrongPronouns2 () [1], PronounValues.GetRightPronoun2 ());
            speech.GetComponentInChildren<TMPro.TextMeshProUGUI> ().text = speechText;
        }
    }

    private IEnumerator StopScroll () {
        gameObject.GetComponent<Scroll> ().speed = 0;
        interruptButton.GetComponent<Button> ().interactable = false;

        yield return new WaitForSeconds (2);

        gameObject.GetComponent<Scroll> ().speed = 1;

        yield return new WaitForSeconds (4);

        interruptButton.GetComponent<Button> ().interactable = true;
    }
}