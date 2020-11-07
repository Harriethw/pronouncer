using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

    public Animator canvasAnim;
    void Start () {
        FinishLine.OnTextFinished += this.GoToNextScene;
        CutSceneTextGenerator.CutSceneFinishEvent += this.GoToNextScene;
        PronounSubmit.OnPronounSubmit += this.GoToNextScene;
        VideoSceneController.VideoSceneEndEvent += this.GoToNextScene;
        CanvasFade.OnCanvasFadeOut += this.LoadScene;
    }

    public void GoToNextScene () {
        //trigger canvas fade, then load next scene
        Debug.Log("clicked");
        if (canvasAnim != null) {
            canvasAnim.Play ("Canvas_fade_out");
        } else {
            Debug.Log (SceneManager.GetActiveScene ().buildIndex);
        }
    }

    public void LoadScene () {
        int nextSceneIndex = SceneManager.GetActiveScene ().buildIndex + 1;
        if (!(nextSceneIndex > SceneManager.sceneCountInBuildSettings)) {
            SceneManager.LoadScene (nextSceneIndex);
        }
    }
}