using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGenerator : MonoBehaviour {
    public GameObject wordPrefab;
    public GameObject pronounPrefab;
    private string paragraph = "Lorem ipsum dolor sit she, consectetur adipiscing she, sed do eiusmod tempor incididunt ut labore et she magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation she laboris nisi ut aliquip she ea commodo consequat. she aute irure dolor in reprehenderit she voluptate velit esse cillum dolore she fugiat nulla pariatur. Excepteur sint occaecat cupidatat she proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
    private List<string> words = new List<string> ();
    private string wrongPronoun = "she";
    // Start is called before the first frame update
    void Start () {
        words = GetWords (paragraph);
        GenerateWords (words);
    }

    // Update is called once per frame
    void Update () { }

    private List<string> GetWords (string paragraphToSplit) {
        string[] wordArray = paragraphToSplit.Split (char.Parse (" "));
        var wordList = new List<string> (wordArray);
        return wordList;
    }

    private void GenerateWords (List<string> words) {
        //to do instantiate the objects, set their parent, add them to list of gameobjects
        //iterate through that list and for each [i] set the localposition.x to be x + (i-1.width/2 + i.width/2) 
        float x = -300;
        float y = 570;
        foreach (var word in words) {
            GameObject wordObject;
            if (word == wrongPronoun) {
                wordObject = Instantiate (pronounPrefab);
            } else {
                wordObject = new GameObject ();
                wordObject.AddComponent<TMPro.TextMeshProUGUI> ();
                wordObject.GetComponent<TMPro.TextMeshProUGUI> ().text = word;
                wordObject.GetComponent<TMPro.TextMeshProUGUI> ().color = new Color32 (255, 128, 0, 255);
            }
            wordObject.AddComponent<ContentSizeFitter> ();
            wordObject.GetComponent<ContentSizeFitter> ().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            Canvas.ForceUpdateCanvases ();
            float width = wordObject.GetComponent<RectTransform> ().rect.width;
            float height = wordObject.GetComponent<RectTransform> ().rect.height;
            x += (width);
            wordObject.transform.SetParent (gameObject.transform, false);
            wordObject.transform.localPosition = new Vector3 (x, y, 0);
            if (x >= 200) {
                y -= height;
                x = -300;
            }
        }
    }

}