using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pronoun : MonoBehaviour
{
    public delegate void PronounCaughtAction();
    public static event PronounCaughtAction OnPronounCaught;

    private AudioSource audioSource;
    public AudioClip[] chimes;
    private AudioClip chimeClip;

    protected string correctPronoun;

    protected bool clicked = false;

    public virtual void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
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