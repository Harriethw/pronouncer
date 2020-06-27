using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource MusicSource;

    // Singleton instance.
    public static SoundManager Instance = null;

    // Initialize the singleton instance.
    private void Awake () {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy (gameObject);
        }

        DontDestroyOnLoad (gameObject);
        PlayBackingTrack ();
    }

    public void PlayBackingTrack () {
        MusicSource.Play ();
    }
}