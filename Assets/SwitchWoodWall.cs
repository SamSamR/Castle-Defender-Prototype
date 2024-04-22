using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWoodWall : MonoBehaviour
{
    public GameObject ShortWoodWall;
    public GameObject TallWoodWall;
    public GameObject OtherWoodWall;
    public void SwitchWall()
    {
        if (ShortWoodWall.gameObject.activeSelf == true)
        {
            TallWoodWall.gameObject.SetActive(true);
            ShortWoodWall.gameObject.SetActive(false);
        }
        else if(TallWoodWall.gameObject.activeSelf == true)
        {
            TallWoodWall.gameObject.SetActive(false);
            OtherWoodWall.gameObject.SetActive(true);
        }
        else
        {
            OtherWoodWall.gameObject.SetActive(false);
            ShortWoodWall.gameObject.SetActive(true);
        }
    }
}
