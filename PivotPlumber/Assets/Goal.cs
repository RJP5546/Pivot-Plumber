using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool goalMet = false;


    void OnTriggerEnter (Collider other)
    {
        Water wat = other.GetComponent<Water>();
            if (wat != null)
        {
            GameManager.SCORE_ADD();
        }

    }
}
