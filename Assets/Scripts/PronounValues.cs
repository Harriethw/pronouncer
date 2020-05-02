using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PronounValues {
    private static string chosenPronoun1;
    private static string chosenPronoun2;

    public static void SetPronouns (string pronoun1, string pronoun2) {
        chosenPronoun1 = pronoun1;
        chosenPronoun2 = pronoun2;
        Debug.Log ("chosen pronouns are " + chosenPronoun1 + " " + chosenPronoun2);
    }

    public static void SetPronoun1 (string pronoun1) {
        chosenPronoun1 = pronoun1;
        Debug.Log ("chosen pronoun1 is " + chosenPronoun1);
    }

    public static void SetPronoun2 (string pronoun2) {
        chosenPronoun2 = pronoun2;
        Debug.Log ("chosen pronoun2 is " + chosenPronoun2);
    }

    public static string GetPronoun1 () {
        Debug.Log ("returning " + chosenPronoun1);
        return chosenPronoun1;
    }

    public static string GetPronoun2 () {
        Debug.Log ("returning " + chosenPronoun2);
        return chosenPronoun2;
    }
}