﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PronounGenerator : MonoBehaviour {
    public GameObject pronoun;
    private Transform[] spawnPoints;
    public float maxTime = 50;
    public float minTime = 10;
    //current time
    private float time;
    //The time to spawn the object
    private float spawnTime;

    private float speed = 1;
    private float direction = 2;

    void Awake () {

        List<Transform> spawningPointsAsList = new List<Transform> ();

        foreach (Transform child in transform) {
            spawningPointsAsList.Add (child);
        }

        spawnPoints = spawningPointsAsList.ToArray ();
    }
    void Start () {
        SetRandomTime ();
        time = 0;
    }

    void SetRandomTime () {
        spawnTime = Random.Range (minTime, maxTime);
        Debug.Log ("Next object spawn in " + spawnTime + " seconds.");
    }

    void FixedUpdate () {
        //Counts up
        time += Time.deltaTime;
        //Check if its the right time to spawn the object
        if (time >= spawnTime) {
            Spawn ();
            SetRandomTime ();
            time = 0;
        }
    }

    void Spawn () {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        GameObject newPronoun = Instantiate (pronoun, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        newPronoun.transform.SetParent (spawnPoints[spawnPointIndex].transform, false);
        //TODO set to random wrong pronoun
        AddScroll (newPronoun);
    }

    void AddScroll (GameObject newPronoun) {
        newPronoun.AddComponent<Scroll> ();
        newPronoun.GetComponent<Scroll> ().speed = speed;
        newPronoun.GetComponent<Scroll> ().direction = new Vector3 (0, direction, 0);
    }
}