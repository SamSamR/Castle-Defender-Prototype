using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FortUIController : MonoBehaviour
{
    public Button minimizeButton;
    public Button WallsTab;
    public Button TowersTab;
    public Button DoorTab;
    public GameObject WallsTabRef;
    public GameObject DoorsTabRef;
    public GameObject TowersTabRef;
    public GameObject MiniScrollRef;

    public void OpenWalls()
    {
        WallsTabRef.SetActive(true);
        DoorsTabRef.SetActive(false);
        TowersTabRef.SetActive(false);
    }
    public void OpenDoors()
    {
        WallsTabRef.SetActive(false);
        DoorsTabRef.SetActive(true);
        TowersTabRef.SetActive(false);
    }
    public void OpenTowers()
    {
        WallsTabRef.SetActive(false);
        DoorsTabRef.SetActive(false);
        TowersTabRef.SetActive(true);
    }
    public void MinimizeBuildScroll()
    {
        MiniScrollRef.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
