using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FormNavigator : MonoBehaviour {
    public List<GameObject> inputs = new List<GameObject> ();

    private int targetIndex = 0;
    private EventSystem myEventSystem;

    void Start () {
        myEventSystem = EventSystem.current;
        if (inputs.Count > 0 && !myEventSystem.currentSelectedGameObject) {
            SetCurrentTabObject();
        }
    }

    void Update () {
        if (Input.GetKeyDown (KeyCode.Tab))
            SetCurrentTabObject ();
    }

    void SetCurrentTabObject () {
        if (targetIndex >= inputs.Count) {
            targetIndex = 0;
        }
        myEventSystem.SetSelectedGameObject (inputs[targetIndex]);
        targetIndex++;
    }
}