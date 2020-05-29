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

    // Start is called before the first frame update
    void Start()
    {
        GenerateSpeech();
    }

    private void GenerateSpeech()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject speech = Instantiate(speechBubble);
            speech.transform.SetParent(gameObject.transform, false);
        }
    }

    public void Interrupt()
    {
        GameObject interrupt = Instantiate(interruption);
        interrupt.transform.SetParent(gameObject.transform, false);
        interrupt.transform.SetSiblingIndex(interruptIndex);
        StartCoroutine(StopScroll());
    }

    private IEnumerator StopScroll()
    {
        gameObject.GetComponent<Scroll>().speed = 0;
        interruptButton.GetComponent<Button>().interactable = false;

        yield return new WaitForSeconds(2);

        gameObject.GetComponent<Scroll>().speed = 1;

        yield return new WaitForSeconds(3);

        interruptButton.GetComponent<Button>().interactable = true;
    }
}