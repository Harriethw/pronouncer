using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSceneController : MonoBehaviour {

    public delegate void VideoSceneEnd ();
    public static VideoSceneEnd VideoSceneEndEvent;
    private int score = 0;
    public int scoreLimit = 8;
    void Start () {
        Pronoun.onPronounCaught += this.IncrementScore;
    }

    private void IncrementScore () {
        score++;
    }

    // Update is called once per frame
    void Update () {
        if (score > scoreLimit && VideoSceneEndEvent != null) {
            VideoSceneEndEvent ();
        }
    }
}