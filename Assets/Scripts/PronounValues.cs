using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PronounValues {
    private static string chosenPronoun1;
    private static string chosenPronoun2;

    private static List<string> possiblePronouns1 = new List<string> { "they", "she", "he" };
    private static List<string> possiblePronouns2 = new List<string> { "them", "her", "him" };

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

    public static List<string> GetWrongPronouns1 () {
        List<string> wrongPronouns = new List<string> ();

        foreach (string pronoun in possiblePronouns1) {
            if (pronoun.ToLower () != chosenPronoun1) {
                wrongPronouns.Add (pronoun);
            }
        }
        Debug.Log (wrongPronouns);
        return wrongPronouns;
    }

    public static List<string> GetWrongPronouns2 () {
        List<string> wrongPronouns = new List<string> ();

        foreach (string pronoun in possiblePronouns2) {
            if (pronoun.ToLower () != chosenPronoun2) {
                wrongPronouns.Add (pronoun);
            }
        }
        Debug.Log (wrongPronouns);
        return wrongPronouns;
    }
}