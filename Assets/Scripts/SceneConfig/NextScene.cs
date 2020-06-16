using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
    void Start () {
        FinishLine.OnTextFinished += this.GoToNextScene;
        CutSceneTextGenerator.CutSceneFinishEvent += this.GoToNextScene;
    }

    public void GoToNextScene () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    }
}