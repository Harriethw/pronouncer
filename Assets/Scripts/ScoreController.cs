using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public Text leaveCountText;
    private int leaveCount = 0;

    public Text scoreCountText;
    private int scoreCount = 0;

    public Image scoreBar;

    // Start is called before the first frame update
    void Start () {
        WindowController.onPronounLeave += this.UpdateLeaveCount;
        Pronoun.onPronounCaught += this.UpdateScoreCount;
        scoreBar.fillAmount = 0f;
    }

    private void UpdateLeaveCount () {
        leaveCount += 1;
        leaveCountText.text = leaveCount.ToString ();
    }

    private void UpdateScoreCount () {
        scoreCount += 1;
        scoreCountText.text = scoreCount.ToString ();
        scoreBar.fillAmount += 0.2f;
    }

    void OnDestroy () {
        WindowController.onPronounLeave -= this.UpdateLeaveCount;
        Pronoun.onPronounCaught -= this.UpdateScoreCount;
    }
}