using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pronoun : MonoBehaviour
{

    public delegate void OnPronounCaught();
    public static OnPronounCaught onPronounCaught;

    private string correctPronoun = "they";

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnMouseDown()
    {
        PronounCaught();
    }

    private void PronounCaught()
    {
        onPronounCaught();
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = correctPronoun;
        gameObject.GetComponentInChildren<ParticleSystem>().Play();
    }
}