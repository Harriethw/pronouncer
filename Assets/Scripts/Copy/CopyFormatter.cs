using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CopyFormatter
{

    //TODO choose a random set of wrong pronouns? 
    public static List<string> AddWrongPronounsToArray(string[] copyList)
    {
        List<string> newCopyList = new List<string>();
        foreach (var text in copyList)
        {
            string newText = "";
            newText = text.Replace("(wrongPronoun1)", PronounValues.GetWrongPronouns1()[0]);
            newText = newText.Replace("(wrongPronoun2)", PronounValues.GetWrongPronouns2()[0]);
            newCopyList.Add(newText);
        }
        return newCopyList;
    }

}