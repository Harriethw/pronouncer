using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneTimer : MonoBehaviour
{
    public float time = 30f;
    public delegate void TimeOutEvent();
    public static event TimeOutEvent OnTimeOut;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("TimeOut",time);
    }

    void TimeOut() {
        if (OnTimeOut != null){
            OnTimeOut();
        }
    }
}
