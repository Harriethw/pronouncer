using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PronounValues
{
    private static string rightPronoun1 = "they";
    private static string rightPronoun2 = "them";

    private static List<string> wrongPronouns1 = new List<string> { "they", "she", "he" };
    private static List<string> wrongPronouns2 = new List<string> { "them", "her", "him" };

    private static List<string> possiblePronouns1 = new List<string> { "they", "she", "he" };
    private static List<string> possiblePronouns2 = new List<string> { "them", "her", "him" };

    public static void SetPronouns(string pronoun1, string pronoun2)
    {
        rightPronoun1 = pronoun1;
        rightPronoun2 = pronoun2;
    }

    public static void SetPronoun1(string pronoun1)
    {
        rightPronoun1 = pronoun1.ToLower();
        SetWrongPronoun1();
    }

    public static void SetPronoun2(string pronoun2)
    {
        rightPronoun2 = pronoun2.ToLower();
        SetWrongPronoun2();
    }

    public static string GetRightPronoun1()
    {
        return rightPronoun1;
    }

    public static string GetRightPronoun2()
    {
        return rightPronoun2;
    }


    private static void SetWrongPronoun1()
    {
        foreach (string pronoun in possiblePronouns1)
        {
            if (pronoun == rightPronoun1)
            {
                wrongPronouns1.Remove(pronoun);
            }
        }
    }
    private static void SetWrongPronoun2()
    {
        foreach (string pronoun in possiblePronouns2)
        {
            if (pronoun == rightPronoun2)
            {
                wrongPronouns2.Remove(pronoun);
            }
        }
    }

    public static List<string> GetWrongPronouns1()
    {
        return wrongPronouns1;
    }

    public static List<string> GetWrongPronouns2()
    {
        return wrongPronouns2;
    }
}