﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public Text leaveCountText;
    private int leaveCount = 0;

    // Start is called before the first frame update
    void Start () {
        WindowController.onPronounLeave += UpdateLeaveCount;
    }

    // Update is called once per frame
    void Update () {

    }

    private void UpdateLeaveCount () {
        leaveCount += 1;
        leaveCountText.text = leaveCount.ToString ();
    }
}