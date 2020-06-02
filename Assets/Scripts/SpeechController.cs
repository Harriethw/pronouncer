using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechController : MonoBehaviour
{

    public static int interruptIndex = 2;
    public GameObject interruption;
    public GameObject speechBubble;
    public GameObject interruptButton;

    private int interruptCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        GenerateSpeech();
    }

    private void GenerateSpeech()
    {
        List<string> formattedChatter = GetChatter();
        for (int i = 0; i < formattedChatter.Count; i++)
        {
            GameObject speech = Instantiate(speechBubble);
            speech.transform.SetParent(gameObject.transform, false);
            speech.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = formattedChatter[i];
            SetHeight(speech.transform);
        }
    }

    //TODO choose a random set of wrong pronouns?s
    private List<string> GetChatter()
    {
        List<string> formattedChatter = new List<string>();
        foreach (var text in SpeechCopy.chatter)
        {
            string newText = "";
            newText = text.Replace("(wrongPronoun1)", PronounValues.GetWrongPronouns1()[0]);
            newText = newText.Replace("(wrongPronoun2)", PronounValues.GetWrongPronouns2()[0]);
            formattedChatter.Add(newText);
        }
        return formattedChatter;
    }

    private void SetHeight(Transform speechTransform)
    {
        Canvas.ForceUpdateCanvases();
        float textHeight = speechTransform.GetChild(0).GetComponent<RectTransform>().rect.height;
        float currentWidth = speechTransform.GetComponent<RectTransform>().rect.width;
        speechTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(currentWidth, textHeight);
    }

    public void Interrupt()
    {
        string formattedInterruption = SpeechCopy.interruption.Replace("(rightPronoun1)", PronounValues.GetRightPronoun1()).Replace("(rightPronoun2)", PronounValues.GetRightPronoun2());
        GameObject interrupt = Instantiate(interruption);
        interrupt.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = formattedInterruption;
        interrupt.transform.SetParent(gameObject.transform, false);
        interrupt.transform.SetSiblingIndex(interruptIndex);

        GameObject apology = Instantiate(speechBubble);
        apology.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = SpeechCopy.apologies[0];
        apology.transform.SetParent(gameObject.transform, false);
        apology.transform.SetSiblingIndex(interruptIndex + 1);

        interruptCount += 1;

        if (interruptCount >= 3)
        {
            CorrectAllPronouns();
        }

        StartCoroutine(StopScroll());
    }

    private void CorrectAllPronouns()
    {
        GameObject[] speechBubbles = GameObject.FindGameObjectsWithTag("Speech");
        foreach (var speech in speechBubbles)
        {
            string speechText = speech.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            speechText = speechText.Replace(PronounValues.GetWrongPronouns1()[0], PronounValues.GetRightPronoun1());
            speechText = speechText.Replace(PronounValues.GetWrongPronouns2()[0], PronounValues.GetRightPronoun2());
            speech.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = speechText;
        }
    }

    private IEnumerator StopScroll()
    {
        gameObject.GetComponent<Scroll>().speed = 0;
        interruptButton.GetComponent<Button>().interactable = false;

        yield return new WaitForSeconds(2);

        gameObject.GetComponent<Scroll>().speed = 1;

        yield return new WaitForSeconds(5);

        interruptButton.GetComponent<Button>().interactable = true;
    }
}