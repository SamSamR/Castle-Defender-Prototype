using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NETWORK_ENGINE;

public class SamGameManager : MonoBehaviour
{
    /*
    public bool GameStarted;
    //score
    //player metrics
    //progress
    //etc
    public int RandomNumber;
    public int num;
    public List<int> CheckList;
    public bool isBingo = false;


    public override void HandleMessage(string flag, string value)
    {
        //happens only client side
        if (flag == "GAMESTART")
        {
            GameStarted = true;
            foreach (BingoLobbyPlayerScript lp in GameObject.FindObjectsOfType<BingoLobbyPlayerScript>())
            {
                //disable Lobby UI's //disabling canvas not the object so we can find and get info from gameobject later
                lp.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
       
    }



    public override IEnumerator SlowUpdate()
    {
        while (!GameStarted && IsServer)
        {
            bool readyGo = true;
            int count = 0; //max number of ppl who need to be ready for game to start???

            foreach (BingoLobbyPlayerScript lp in GameObject.FindObjectsOfType<BingoLobbyPlayerScript>())
            {
                if (!lp.IsReady)
                {
                    readyGo = false;
                    break;
                }
                count++;
            }
            if (count < 1) //how many ppl need to be ready before game starts ( if 2 or less players are ready don't start yet))
            {
                readyGo = false;
            }
            GameStarted = readyGo;
            yield return new WaitForSeconds(2);
        }
        if (IsServer)
        {
            SendUpdate("GAMESTART", GameStarted.ToString());
            //stop listening for more players

            //go through each lobbyplayersript
            foreach (BingoLobbyPlayerScript lp in GameObject.FindObjectsOfType<BingoLobbyPlayerScript>())
            {
                //create bingo card based off what option player chose
                MyCore.NetCreateObject(lp.BingoCard, lp.Owner, lp.transform.position - new Vector3(-2.0f, 2.5f, 0), Quaternion.identity);
            }
            Debug.Log("isBingo : " + isBingo);
            while (isBingo != true)
            {
                UseCreatedCheckingList();
                yield return new WaitForSeconds(5f);
            }
            //assumes all players have joined before while loop ends, if while loop is ended new players can only spectate
            //spawn players;
        }
        while (IsServer)
        {
            if (IsDirty)
            {
                SendUpdate("GAMESTART", GameStarted.ToString());
                IsDirty = false;
            }
            yield return new WaitForSeconds(5);
        }
    }

    public override void NetworkedStart()
    {

    }
    */
}
