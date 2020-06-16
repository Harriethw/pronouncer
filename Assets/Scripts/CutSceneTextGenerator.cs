using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public delegate void CutSceneFinish ();

public class CutSceneTextGenerator : MonoBehaviour {
    public static event CutSceneFinish CutSceneFinishEvent;
    public int sceneNumber;

    private string[] sceneText;
    private GameObject textObject;
    private TextMeshProUGUI text;
    private float timeSpeed = 1.0f;

    //foreach text in cut scene text 
    //text equals that sentence, lerp colour up and down
    // Start is called before the first frame update
    void Start () {
        sceneText = CutSceneCopy.copy[sceneNumber];
        textObject = this.gameObject.transform.GetChild (0).gameObject;
        text = textObject.GetComponent<TMPro.TextMeshProUGUI> ();
        StartCoroutine (GenerateText ());
    }

    private IEnumerator GenerateText () {
        foreach (string sentence in sceneText) {
            text.text = sentence;
            yield return ShowText ();
        }
        if (CutSceneFinishEvent != null){
            CutSceneFinishEvent();
        }
    }

    private IEnumerator ShowText () {
        yield return FadeInText ();
        yield return new WaitForSeconds (2);
        yield return FadeOutText ();
    }
    private IEnumerator FadeInText () {
        text.color = new Color (text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f) {
            text.color = new Color (text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime * timeSpeed));
            yield return null;
        }
    }

    private IEnumerator FadeOutText () {
        text.color = new Color (text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f) {
            text.color = new Color (text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime * timeSpeed));
            yield return null;
        }
    }
}