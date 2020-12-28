using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pronoun1 : Pronoun
{
    //e.g. she, he, they
    public override void Start()
    {
        base.Start();
        SetCorrectPronoun();
    }

    private void SetCorrectPronoun()
    {
        correctPronoun = PronounValues.GetRightPronoun1();
    }
}