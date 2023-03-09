using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameObject PipeGlow;
    public GameObject childPipe;
    //public bool isHover;

    public float RotateTimeSeconds = 2f;
    public float RotateAngleDegrees = 90;

    private float timer = 0;
    private float rotateAngleStart;
    private float rotateAngleEnd;

    void Start()
    {
        rotateAngleStart = transform.rotation.eulerAngles.z;
        rotateAngleEnd = transform.rotation.eulerAngles.z;
    }

    void awake()
    {
       childPipe = transform.GetChild(0).gameObject;
       PipeGlow.SetActive(false);
    }
    void OnMouseEnter()
    {
        print("Pipe:OnMouseEnter()");
        PipeGlow.SetActive(true);
        //isHover = true;
    }

    void OnMouseExit()
    {
        print("Pipe:OnMouseExit()");
        PipeGlow.SetActive(false);
        //isHover = false;
    }

    private IEnumerator SetRotation()
    {
        while (timer > 0)
        {
            Vector3 temp = childPipe.transform.rotation.eulerAngles;
            float alpha = (RotateTimeSeconds - timer) / RotateTimeSeconds;
            temp.z = Mathf.Lerp(rotateAngleStart, rotateAngleEnd, alpha);
            childPipe.transform.rotation = Quaternion.Euler(temp);

            //wait one frame
            yield return null;

            timer -= Time.deltaTime;
        }

        EndRotation();
    }

    private void EndRotation()
    {
        Vector3 temp = childPipe.transform.rotation.eulerAngles;

        temp.z = rotateAngleEnd;

        childPipe.transform.rotation = Quaternion.Euler(temp);
    }

    private void OnMouseDown()
    {
        bool timerRunning = timer > 0;

        EndRotation();

        timer = RotateTimeSeconds;

        rotateAngleStart = transform.rotation.eulerAngles.z;
        rotateAngleEnd = rotateAngleStart + RotateAngleDegrees;

        if (!timerRunning)
        {
            StartCoroutine(SetRotation());
        }
    }
}
