using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PronounValues {
    private static string chosenPronoun1 = "they";
    private static string chosenPronoun2 = "them";

    private static List<string> wrongPronouns1 = new List<string> { "she", "he" };
    private static List<string> wrongPronouns2 = new List<string> { "her", "him" };

    private static List<string> possiblePronouns1 = new List<string> { "they", "she", "he" };
    private static List<string> possiblePronouns2 = new List<string> { "them", "her", "him" };

    public static void SetPronouns (string pronoun1, string pronoun2) {
        chosenPronoun1 = pronoun1;
        chosenPronoun2 = pronoun2;
        Debug.Log ("chosen pronouns are " + chosenPronoun1 + " " + chosenPronoun2);
    }

    public static void SetPronoun1 (string pronoun1) {
        chosenPronoun1 = pronoun1.ToLower ();
        SetWrongPronouns ();
        Debug.Log ("chosen pronoun1 is " + chosenPronoun1);
    }

    public static void SetPronoun2 (string pronoun2) {
        chosenPronoun2 = pronoun2.ToLower ();
        SetWrongPronouns ();
        Debug.Log ("chosen pronoun2 is " + chosenPronoun2);
    }

    public static string GetPronoun1 () {
        return chosenPronoun1;
    }

    public static string GetPronoun2 () {
        return chosenPronoun2;
    }

    private static void SetWrongPronouns () {
        foreach (string pronoun in possiblePronouns1) {
            if (pronoun.ToLower () != chosenPronoun1) {
                wrongPronouns1.Add (pronoun);
            }
        }
        Debug.Log (wrongPronouns1);
        foreach (string pronoun in possiblePronouns2) {
            if (pronoun.ToLower () != chosenPronoun2) {
                wrongPronouns2.Add (pronoun);
            }
        }
        Debug.Log (wrongPronouns2);
    }

    public static List<string> GetWrongPronouns1 () {
        return wrongPronouns1;
    }

    public static List<string> GetWrongPronouns2 () {
        return wrongPronouns2;
    }
}