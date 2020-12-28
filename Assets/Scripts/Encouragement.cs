using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encouragement : MonoBehaviour
{

    private List<string> encouragementPhrases = new List<string> { "Nice work!", "Awesome!", "Well done!", "You got this!" };

    // Start is called before the first frame update
    void Start()
    {
        Pronoun.OnPronounCaught += this.ShowEncouragement;
        SpeechController.OnInterruption += this.ShowEncouragement;
    }

    private void ShowEncouragement()
    {
        gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = encouragementPhrases[Random.Range(0, encouragementPhrases.Count)];
        gameObject.GetComponent<Animator>().Play("fade");
    }

    void OnDestroy()
    {
        Pronoun.OnPronounCaught -= this.ShowEncouragement;
        SpeechController.OnInterruption -= this.ShowEncouragement;
    }
}