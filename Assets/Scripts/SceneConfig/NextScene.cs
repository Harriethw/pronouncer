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
        NextSceneTimer.OnTimeOut += this.GoToNextScene;
        CanvasFade.OnCanvasFadeOut += this.LoadScene;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            GoToNextScene();
    }

    public void GoToNextScene () {
        //trigger canvas fade, then load next scene
        if (canvasAnim != null) {
            Debug.Log("fade_out");
            canvasAnim.SetBool ("fade_out", true);
        } else {
            Debug.Log ("no canvas animator");
        }
    }


    public void LoadScene () {
        int nextSceneIndex = SceneManager.GetActiveScene ().buildIndex + 1;
        if (!(nextSceneIndex >= SceneManager.sceneCountInBuildSettings)) {
            SceneManager.LoadScene (nextSceneIndex);
        } else {
            SceneManager.LoadScene (0);
        }
    }

    void OnDestroy (){
        FinishLine.OnTextFinished -= this.GoToNextScene;
        CutSceneTextGenerator.CutSceneFinishEvent -= this.GoToNextScene;
        PronounSubmit.OnPronounSubmit -= this.GoToNextScene;
        VideoSceneController.VideoSceneEndEvent -= this.GoToNextScene;
        NextSceneTimer.OnTimeOut -= this.GoToNextScene;
        CanvasFade.OnCanvasFadeOut -= this.LoadScene;
    }
}