using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basin : MonoBehaviour
{
    public GameObject basinGlow;
    public GameObject cylinder;
    public GameObject WaterSpawn;
    public GameObject waterPrefab;
    public GameObject water;

    void awake()
    {
        cylinder = transform.GetChild(1).gameObject;
        basinGlow.SetActive(false);

    }

    IEnumerator Start()
    {
        for (int i = 0; i < 20; i++)
        {
            waterSpawn();
            yield return new WaitForSeconds(0.3f);
        } 
 
    }

    private void waterSpawn()
    {
        water = Instantiate<GameObject>(waterPrefab);
        water.transform.position = WaterSpawn.transform.position;
        water.GetComponent<Rigidbody>().isKinematic = false;
    }

    void OnMouseEnter()
    {
        basinGlow.SetActive(true);
    }

    void OnMouseExit()
    {
        basinGlow.SetActive(false);
    }

    private void OnMouseDown()
    {
        cylinder.SetActive(false);

    }
}
