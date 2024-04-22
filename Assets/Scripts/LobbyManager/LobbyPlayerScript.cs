using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NETWORK_ENGINE;

public class LobbyPlayerScript : NetworkComponent 
{
    public int Team;
    public bool IsReady, ReadyToggled, NameSet, IsPressed, LeaderSelected = false;

    public GameObject LobbyContainerRef;
    public InputField PlayerName;
    public Text title;
    public Button SetPlayerName;

    public Toggle ReadyToggle;

    public Toggle LeaderOne;
    public Toggle LeaderTwo;
    public Toggle LeaderThree;
    public Toggle LeaderFour;

    public GameObject InGameMenuRef;

    
    public GameObject leader;
    public int spawnNum;

    //public bool gameActive = false;

    public void SetReady(bool b)
    {
        if (IsLocalPlayer && MyId.IsInit)
        {
            if (!b)
            {
                b = true;
                SendCommand("READY", b.ToString());
                
            }
        }
    }
    public void SetName(string s)
    {
        if (IsLocalPlayer && MyId.IsInit)
        {
            if (PlayerName != null)
            {
                s = PlayerName.text.ToString();
                NameSet = true;
                SendCommand("NAME", s.ToString());
            }
        }
    }
    public void SetLeader1()
    {
        if (IsLocalPlayer && MyId.IsInit && IsPressed == false)
        {
            SendCommand("LEADER1", NetId.ToString());
            LeaderTwo.isOn = false;
            LeaderThree.isOn = false;
            LeaderFour.isOn = false;
            LeaderSelected = true;
            if (NameSet)
            {
                ReadyToggle.interactable = true;
            }
            IsPressed = true;
        }
    }
    public void SetLeader2()
    {
        if (IsLocalPlayer && MyId.IsInit && IsPressed == false)
        {
            SendCommand("LEADER2", NetId.ToString());
            LeaderOne.isOn = false;
            LeaderThree.isOn = false;
            LeaderFour.isOn = false;
            LeaderSelected = true;
            if (NameSet)
            {
                ReadyToggle.interactable = true;
            }
            IsPressed = true;
        }
    }
    public void SetLeader3()
    {
        if (IsLocalPlayer && MyId.IsInit && IsPressed == false)
        {
            SendCommand("LEADER3", NetId.ToString());
            LeaderOne.isOn = false;
            LeaderTwo.isOn = false;
            LeaderFour.isOn = false;
            LeaderSelected = true;
            if (NameSet)
            {
                ReadyToggle.interactable = true;
            }
            IsPressed = true;
        }
    }
    public void SetLeader4()
    {
        if (IsLocalPlayer && MyId.IsInit && IsPressed == false)
        {
            SendCommand("LEADER4", NetId.ToString());
            LeaderOne.isOn = false;
            LeaderTwo.isOn = false;
            LeaderThree.isOn = false;
            LeaderSelected = true;
            if (NameSet)
            {
                ReadyToggle.interactable = true;
            }
            IsPressed = true;
            Debug.Log("--Leader 4 Assignment (button clicked)--");
        }
    }

    public override void HandleMessage(string flag, string value)
    {
        switch (flag)
        {
            case "READY":
                IsReady = bool.Parse(value);
                if (IsClient && ReadyToggled == false && LeaderSelected == true)
                {
                    ReadyToggle.isOn = IsReady;
                    ReadyToggled = true;
                    if (IsReady)
                    {
                        ReadyToggle.interactable = false;
                        InGameMenuRef = GameObject.Find("IngameUI");
                    }

                }
                if (IsServer)
                {
                    SendUpdate("READY", value);
                }
                break;
            case "NAME":
                name = value;
                if (value != null || value != "")
                {
                    if (!IsLocalPlayer && !IsServer)
                    {
                        title.text = name;
                    }
                    if (IsLocalPlayer)
                    {
                        title.text = name;
                        SetPlayerName.gameObject.SetActive(false);
                        if (LeaderSelected)
                        {
                            ReadyToggle.interactable = true;
                        }
                    }
                    if (IsServer)
                    {
                        SendUpdate("NAME", value);
                    }
                }
                break;

            case "SPAWN":
                int spawnIndex = int.Parse(value);
                if (IsClient)
                {
                    Debug.Log("change name");
                    //set leader team
                    leader.GetComponent<Leader>().setUnitTeam(this.Owner);
                    //set leader name
                    leader.name = "Leader " + (spawnIndex - 10);
                    Debug.Log("Client leader name:" + leader.name);
                    
                }
                if (IsServer)
                {
                    Vector3 pos = Vector3.zero;
                    //spawn your leader
                    if(spawnIndex == 11)
                    {
                        pos = new Vector3(-0.3f, 0, -2.2f);
                    }
                    if(spawnIndex == 12)
                    {
                        pos = new Vector3(15.7f, 0, -3.5f);
                    }
                    if(spawnIndex == 13)
                    {
                        pos = new Vector3(8, 0, 4.8f);
                    }
                    if(spawnIndex == 14)
                    {
                        pos = new Vector3(8, 0, -9.3f);
                    }

                    //spawn leader
                    leader = MyCore.NetCreateObject(spawnIndex, -1, pos, Quaternion.identity);
                    
                    SendUpdate("SPAWN", value);
                    Debug.Log("Server: leader spawned");
                }
                break;
            case "LEADER1":
                int PlayerID = int.Parse(value);
                if (IsLocalPlayer || !IsLocalPlayer)
                {
                    LeaderFour.interactable = false;
                    LeaderTwo.interactable = false;
                    LeaderThree.interactable = false;
                    
                }
                if (IsClient)
                {
                    foreach (LobbyPlayerScript lp in GameObject.FindObjectsOfType<LobbyPlayerScript>())
                    {
                        if (lp.NetId != PlayerID)
                        {
                            lp.LeaderOne.interactable = false;
                        }
                        else
                            lp.LeaderOne.isOn = true;
                    }

                    SendCommand("SPAWN", "11");

                }
                if (IsServer)
                {
                    SendUpdate("LEADER1", value);
                        
                }
                break;

            case "LEADER2":
                PlayerID = int.Parse(value);
                if (IsLocalPlayer || !IsLocalPlayer)
                {
                    LeaderOne.interactable = false;
                    LeaderThree.interactable = false;
                    LeaderFour.interactable = false;
                }
                if (IsClient)
                {
                    foreach (LobbyPlayerScript lp in GameObject.FindObjectsOfType<LobbyPlayerScript>())
                    {
                        if (lp.NetId != PlayerID)
                        {
                            lp.LeaderTwo.interactable = false;
                        }
                        else
                            lp.LeaderTwo.isOn = true;
                    }

                    SendCommand("SPAWN", "12");
                }
                if (IsServer)
                {
                    SendUpdate("LEADER2", value);

                    
                }
                break;

            case "LEADER3":
                PlayerID = int.Parse(value);
                if (IsLocalPlayer || !IsLocalPlayer)
                {
                    LeaderOne.interactable = false;
                    LeaderTwo.interactable = false;
                    LeaderFour.interactable = false;
                }
                if (IsClient)
                {
                    foreach (LobbyPlayerScript lp in GameObject.FindObjectsOfType<LobbyPlayerScript>())
                    {
                        if (lp.NetId != PlayerID)
                        {
                            lp.LeaderThree.interactable = false;
                        }
                        else
                            lp.LeaderThree.isOn = true;
                    }

                    SendCommand("SPAWN", "13");
                }
                if (IsServer)
                {
                    SendUpdate("LEADER3", value);

                }

                break;
            case "LEADER4":
                PlayerID = int.Parse(value);
                if (IsLocalPlayer || !IsLocalPlayer)
                {
                    LeaderOne.interactable = false;
                    LeaderTwo.interactable = false;
                    LeaderThree.interactable = false;
                }
                if (IsClient)
                {
                    foreach (LobbyPlayerScript lp in GameObject.FindObjectsOfType<LobbyPlayerScript>())
                    {
                        if (lp.NetId != PlayerID)
                        {
                            lp.LeaderFour.interactable = false;
                        }
                        else
                            lp.LeaderFour.isOn = true;
                    }
                    SendCommand("SPAWN", "14");
                }
                if (IsServer)
                {
                    SendUpdate("LEADER4", "14");

                    
                }
                break;
        }
    }

    public override void NetworkedStart(){}

    public override IEnumerator SlowUpdate()
    {
        if (!IsLocalPlayer)
        {
            ReadyToggle.interactable = false;
            LeaderOne.interactable = false;
            LeaderTwo.interactable = false;
            LeaderThree.interactable = false;
            LeaderFour.interactable = false;
            SetPlayerName.gameObject.SetActive(false);
            PlayerName.interactable = false;
        }
        
        switch (Owner)
        {
            case 0:
                this.transform.position = new Vector3(-2, 2, 10);
                break;
            case 1:
                this.transform.position = new Vector3(2.3f, 2, 10);
                break;
            case 2:
                this.transform.position = new Vector3(6.4f, 2, 10);
                break;
            case 3:
                this.transform.position = new Vector3(10.5f, 2, 10);
                break;
        }

        while (IsConnected)
        {
            if (IsServer)
            {
                if (IsDirty)
                {
                    SendUpdate("READY", IsReady.ToString());
                    SendUpdate("TEAM", Team.ToString());
                    SendUpdate("SPAWN", spawnNum.ToString());
                    IsDirty = false;
                }
            }
            yield return new WaitForSeconds(.1f);
        }
        }
    }