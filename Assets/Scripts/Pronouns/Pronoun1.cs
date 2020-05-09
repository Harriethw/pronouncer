using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pronoun1 : Pronoun {
    //e.g. she, he, they
    void Start () {
        SetCorrectPronoun ();
    }

    private void SetCorrectPronoun () {
        correctPronoun = PronounValues.GetPronoun1 ();
    }
}