using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NETWORK_ENGINE;

public class Game_Manager_Script : NetworkComponent
{
    public bool GameStarted;
    public GameObject BackdropMenuRef;
    public GameObject InGameMenuRef;
    public GameObject lobbyCamRef;
    public GameObject CameraGroup;
    
    public bool IsCreated=false;

    //Can also include extra information here such as player metrics, score, progress ...

    public override void HandleMessage(string flag, string value)
    {
         //* client side only
        if(flag == "GAMESTART")
        {
            Debug.Log("Game has started.");
            GameObject test1 = CameraGroup.transform.GetChild(0).gameObject;
            test1.SetActive(true);
            GameObject test = Instantiate(InGameMenuRef);
            test.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            BackdropMenuRef.gameObject.SetActive(false);

            Destroy(lobbyCamRef);
            GameStarted = true;
            foreach (LobbyPlayerScript lp in GameObject.FindObjectsOfType<LobbyPlayerScript>())
            {
                lp.LobbyContainerRef.gameObject.SetActive(false);
            }
            foreach (LobbyPlayerScript lp in GameObject.FindObjectsOfType<LobbyPlayerScript>())
            {
                Debug.Log("GameStart Call");
                GameObject.Find("Menu Backdrop").SetActive(false);
            }
            IsCreated = true;
        }
    }

    public override void NetworkedStart()
    {
        InGameMenuRef = GameObject.Find("IngameUI");
        lobbyCamRef = GameObject.Find("LobbyCameraGroup");
        BackdropMenuRef = GameObject.Find("New_Menu_Backdrop");
        CameraGroup = GameObject.Find("CameraGroup");
    }

    public override IEnumerator SlowUpdate()
    {
        while (!GameStarted && IsServer)
        {
            bool readyGo = true;
            int count = 0;
 
            foreach (LobbyPlayerScript lp in GameObject.FindObjectsOfType<LobbyPlayerScript>())
            {
                if (!lp.IsReady)
                {
                    readyGo = false;
                    break;
                }
                count++;
            }
            if (count < 1)
            {
                readyGo = false;
            }
            GameStarted = readyGo;
            yield return new WaitForSeconds(5);
        }
        if (IsServer)
        { 
            SendUpdate("GAMESTART", GameStarted.ToString());

        }
        if (IsLocalPlayer)
        {
            //GameObject.Find("IngameUI").SetActive(true);
        }
        
        while (IsServer)
        {
            if (IsDirty)
            {
                SendUpdate("GAMESTART", GameStarted.ToString());
                IsDirty = false;
            }
            yield return new WaitForSeconds(10);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        GameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
