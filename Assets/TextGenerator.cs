using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGenerator : MonoBehaviour {
    public GameObject wordPrefab;
    public GameObject pronounPrefab;
    private string paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, she do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim she, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea she consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur she occaecat cupidatat non proident, sunt in culpa qui officia she mollit anim id est laborum.";
    private List<string> words = new List<string> ();
    // Start is called before the first frame update
    void Start () {
        words = GetWords (paragraph);
        GenerateWords (words);
    }

    // Update is called once per frame
    void Update () {

    }

    private List<string> GetWords (string paragraphToSplit) {
        string[] wordArray = paragraphToSplit.Split (char.Parse (" "));
        var wordList = new List<string> (wordArray);
        return wordList;
    }

    private void GenerateWords (List<string> words) {
        foreach (var word in words) {
            if (word == "she") {
                GameObject pronounObject;
                pronounObject = Instantiate (pronounPrefab);
                pronounObject.transform.SetParent (gameObject.transform, false);
            } else {
                GameObject wordObject;
                wordObject = Instantiate (wordPrefab);
                wordObject.GetComponent<TMPro.TextMeshProUGUI> ().text = word;
                wordObject.transform.SetParent (gameObject.transform, false);
                Debug.Log (wordObject.GetComponent<TMPro.TextMeshProUGUI> ().textBounds);
            }
        }
    }
}