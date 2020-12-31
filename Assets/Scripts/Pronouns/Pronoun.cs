using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Pronoun : MonoBehaviour
{
    public delegate void PronounCaughtAction();
    public static event PronounCaughtAction OnPronounCaught;

    private EventSystem myEventSystem;

    private AudioSource audioSource;
    public AudioClip[] chimes;
    private AudioClip chimeClip;

    protected string correctPronoun;

    protected bool clicked = false;

    public virtual void Start()
    {
        myEventSystem = EventSystem.current;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (myEventSystem.currentSelectedGameObject == this.gameObject)
        {
            gameObject.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = FontStyles.Underline | FontStyles.Bold;
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                {
                    PronounCaught();
                    clicked = true;
                }
        } else {
            gameObject.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = FontStyles.Bold;
        }
    }

    public void OnMouseDown()
    {
        if (!clicked)
        {
            PronounCaught();
            clicked = true;
        }
    }

    protected void PronounCaught()
    {
        PlaySoundEffect();
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = correctPronoun;
        gameObject.GetComponentInChildren<ParticleSystem>().Play();
        if (OnPronounCaught != null)
        {
            OnPronounCaught();
        }
    }

    private void PlaySoundEffect()
    {
        if(audioSource != null)
        {
            int index = Random.Range(0, chimes.Length);
            chimeClip = chimes[index];
            audioSource.clip = chimeClip;
            audioSource.Play();
        }
    }
}