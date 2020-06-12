using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    private int leaveCount = 0;

    private int scoreCount = 0;

    public Image scoreBar;

    // Start is called before the first frame update
    void Start () {
        PronounCatcher.PronounLeaveEvent += this.UpdateLeaveCount;
        Pronoun.onPronounCaught += this.UpdateScoreCount;
        scoreBar.fillAmount = 0f;
    }

    private void UpdateLeaveCount () {
        leaveCount += 1;
    }

    private void UpdateScoreCount () {
        scoreCount += 1;
        scoreBar.fillAmount += 0.2f;
    }

    void OnDestroy () {
        PronounCatcher.PronounLeaveEvent -= this.UpdateLeaveCount;
        Pronoun.onPronounCaught -= this.UpdateScoreCount;
    }
}