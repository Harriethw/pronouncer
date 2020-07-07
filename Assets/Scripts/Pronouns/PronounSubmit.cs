using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void PronounSubmitHandler ();

public class PronounSubmit : MonoBehaviour {
    public static event PronounSubmitHandler OnPronounSubmit;

    public TMP_InputField pronoun1;
    public TMP_InputField pronoun2;

    public void OnSubmit () {
        PronounValues.SetPronoun1 (pronoun1.text);
        PronounValues.SetPronoun2 (pronoun2.text);
        Debug.Log ("submitting " + PronounValues.GetRightPronoun1 () + PronounValues.GetRightPronoun2 ());
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    }
}