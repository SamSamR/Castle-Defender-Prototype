using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTimer : MonoBehaviour
{
    public float buildTime = 120;

    public GameObject buildUICanvas;
    

    // Update is called once per frame
    void Update()
    {
        if (buildTime > 0)
        {
            buildTime -= Time.deltaTime;
        }
        else
        {
            buildTime = 0;
            buildUICanvas.SetActive(false);
        }
    }
}
