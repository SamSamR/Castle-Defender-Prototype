using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitScrollMinimize : MonoBehaviour
{
    public Button minibutton;
    public GameObject miniScrollUnitRef;
    public void minimizeScroll()
    {
        miniScrollUnitRef.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
