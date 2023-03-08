using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameObject PipeGlow;
    public GameObject childPipe;
    public bool isHover;

    void awake()
    {
       childPipe = transform.GetChild(0).gameObject;
       PipeGlow.SetActive(false);
    }
    void OnMouseEnter()
    {
        print("Pipe:OnMouseEnter()");
        PipeGlow.SetActive(true);
        isHover = true;
    }

    void OnMouseExit()
    {
        print("Pipe:OnMouseExit()");
        PipeGlow.SetActive(false);
        isHover = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && isHover)
        {
            
            childPipe.transform.Rotate(0, 0, 90, Space.Self);
        }
    }
    
        
}
