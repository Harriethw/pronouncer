using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PronounSubmit : MonoBehaviour
{

    public TMP_InputField tmpInputField;

    public void SetPronoun1()
    {
        PronounValues.SetPronoun1(tmpInputField.text);
    }

    public void SetPronoun2()
    {
        PronounValues.SetPronoun2(tmpInputField.text);
    }

    public void OnSubmit()
    {
        Debug.Log("submitting " + PronounValues.GetRightPronoun1() + PronounValues.GetRightPronoun2());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}