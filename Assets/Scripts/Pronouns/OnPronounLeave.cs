using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnPronounLeave : MonoBehaviour
{
   public Text leaveCountText;
   private int leaveCount = 0;

   void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
        leaveCount += 1;
        leaveCountText.text = leaveCount.ToString();
    }
}
