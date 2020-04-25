using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGenerator : MonoBehaviour {
    public GameObject wordPrefab;
    public GameObject pronounPrefab;
    private string paragraph = "Lorem ipsum dolor sit she, consectetur adipiscing she, sed do eiusmod tempor incididunt ut labore et she magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation she laboris nisi ut aliquip she ea commodo consequat. she aute irure dolor in reprehenderit she voluptate velit esse cillum dolore she fugiat nulla pariatur. Excepteur sint occaecat cupidatat she proident, sunt in culpa qui officia deserunt mollit anim id est laborum. ";
    private List<string> words = new List<string> ();
    private List<GameObject> wordGrid = new List<GameObject> ();

    private string wrongPronoun = "she";

    private float windowWidth;
    private float minX;
    private float maxX;

    public float maxY = 570;
    public float changeY = 50;
    public float padding = 10;

    void Start () {
        GetWidthMeasurements ();
        words = GetWords (paragraph);
        GenerateWords ();
    }

    private void GetWidthMeasurements () {
        windowWidth = gameObject.GetComponent<RectTransform> ().rect.width;
        minX = 0 - (windowWidth / 2);
        maxX = (windowWidth / 2);
    }

    private List<string> GetWords (string paragraphToSplit) {
        string[] wordArray = paragraphToSplit.Split (char.Parse (" "));
        var wordList = new List<string> (wordArray);
        return wordList;
    }

    private void GenerateWords () {
        foreach (var word in words) {
            GameObject wordObject;
            if (word == wrongPronoun) {
                wordObject = Instantiate (pronounPrefab);
            } else {
                wordObject = Instantiate (wordPrefab);
                wordObject.GetComponent<TMPro.TextMeshProUGUI> ().text = word;
            }
            Canvas.ForceUpdateCanvases ();
            wordGrid.Add (wordObject);
            GenerateGrid ();
        }

    }

    private void GenerateGrid () {
        float x = minX;
        float y = maxY;
        for (int i = 0; i < wordGrid.Count; i++) {
            wordGrid[i].transform.SetParent (gameObject.transform, false);
            if (i != 0) {
                float previousObjectWidth = wordGrid[i - 1].GetComponent<RectTransform> ().rect.width;
                x += previousObjectWidth + padding;
                float distanceToEdge = Math.Abs (maxX - x);
                float currentWordWidth = wordGrid[i].GetComponent<RectTransform> ().rect.width;
                if (distanceToEdge < currentWordWidth) {
                    y -= changeY;
                    x = minX;
                }
            }
            wordGrid[i].transform.localPosition = new Vector3 (x, y, 0);

        }
    }

}