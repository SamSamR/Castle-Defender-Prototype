using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBuildScroll : MonoBehaviour
{
    public GameObject buildScrollRef;

    public void OpenFortScroll()
    {
        buildScrollRef.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
