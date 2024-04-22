using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenUnitScroll : MonoBehaviour
{
    public GameObject UnitScrollRef;
    public void OpenUnitsScroll()
    {
        UnitScrollRef.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
