﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class TextGenerator : MonoBehaviour
{
    public GameObject wordPrefab;
    public GameObject pronounPrefab1;
    public GameObject pronounPrefab2;
    private string paragraph = "Lorem ipsum (wrongPronoun2) sit (wrongPronoun1), (wrongPronoun2) adipiscing sed do eiusmod tempor (wrongPronoun2) ut labore et (wrongPronoun1) magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation (wrongPronoun1) laboris nisi ut aliquip (wrongPronoun1) ea commodo consequat. (wrongPronoun1), aute irure dolor in reprehenderit (wrongPronoun1) voluptate (wrongPronoun2) esse cillum dolore (wrongPronoun1) fugiat nulla pariatur. Excepteur sint (wrongPronoun2) cupidatat (wrongPronoun1) proident, sunt in culpa qui officia (wrongPronoun2), mollit anim id est laborum. ";
    private List<string> words = new List<string>();
    private List<GameObject> wordGrid = new List<GameObject>();

    private float windowWidth;
    private float minX;
    private float maxX;

    public float maxY = 570;
    public float changeY = 50;
    public float padding = 10;

    void Start()
    {
        paragraph = CopyFormatter.AddWrongPronounsToString(paragraph);
        GetWidthMeasurements();
        GetWords();
        GenerateWords();
    }

    private void GetWidthMeasurements()
    {
        windowWidth = gameObject.GetComponent<RectTransform>().rect.width;
        minX = 0 - (windowWidth / 2);
        maxX = (windowWidth / 2);
    }

    private void GetWords()
    {
        string[] wordArray = paragraph.Split(char.Parse(" "));
        var wordList = new List<string>(wordArray);
        words = wordList;
    }

    private void GenerateWords()
    {
        foreach (var word in words)
        {
            var formattedWord = FormatWord(word);
            GameObject wordObject;
            if (PronounValues.GetWrongPronouns1().Contains(formattedWord))
            {
                wordObject = Instantiate(pronounPrefab1);
            }
            else if (PronounValues.GetWrongPronouns2().Contains(formattedWord))
            {
                wordObject = Instantiate(pronounPrefab2);
            }
            else
            {
                wordObject = Instantiate(wordPrefab);
            }
            wordObject.GetComponent<TMPro.TextMeshProUGUI>().text = word;
            Canvas.ForceUpdateCanvases();
            wordGrid.Add(wordObject);
            GenerateGrid();
        }

    }

    private string FormatWord(string word)
    {
        var formattedWord = word.ToLower();
        Regex rgx = new Regex("[^a-zA-Z0-9 -]");
        formattedWord = rgx.Replace(formattedWord, "");
        return formattedWord;
    }

    private void GenerateGrid()
    {
        float x = minX;
        float y = maxY;
        for (int i = 0; i < wordGrid.Count; i++)
        {
            wordGrid[i].transform.SetParent(gameObject.transform, false);
            if (i != 0)
            {
                float previousObjectWidth = wordGrid[i - 1].GetComponent<RectTransform>().rect.width;
                x += previousObjectWidth + padding;
                float distanceToEdge = Math.Abs(maxX - x);
                float currentWordWidth = wordGrid[i].GetComponent<RectTransform>().rect.width;
                if (distanceToEdge < currentWordWidth)
                {
                    y -= changeY;
                    x = minX;
                }
            }
            wordGrid[i].transform.localPosition = new Vector3(x, y, 0);

        }
    }

}