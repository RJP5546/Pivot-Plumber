using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    static List<Water> WATERS = new List<Water>();

    void Start()
    {
        WATERS.Add(this);
    }

    private void OnDestroy()
    {
        WATERS.Remove(this);
    }

    static public void DESTROY_WATERS()
    {
        foreach (Water p in WATERS)
        {
            Destroy(p.gameObject);
        }
    }
}
