using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pronoun2 : Pronoun
{
    //e.g. her, him, them
    public override void Start()
    {
        base.Start();
        SetCorrectPronoun();
    }

    private void SetCorrectPronoun()
    {
        correctPronoun = PronounValues.GetRightPronoun2();
    }
}