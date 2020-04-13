using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Scroll : MonoBehaviour
{
   
    public float speed;
    public Vector3 direction;

    void Update()
    {
        float translation = speed * Time.deltaTime;

        transform.Translate(direction * translation);
    }
   
}
