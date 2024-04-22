using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStoneWall : MonoBehaviour
{
    public GameObject StoneWallShortRef;
    public GameObject StoneWallTallRef;
    
    public void SwitchWall()
    {
        if (StoneWallShortRef.gameObject.activeSelf == true)
        {
            StoneWallTallRef.gameObject.SetActive(true);
            StoneWallShortRef.gameObject.SetActive(false);
        }
        else
        {
            StoneWallTallRef.gameObject.SetActive(false);
            StoneWallShortRef.gameObject.SetActive(true);
        }
    }
}
