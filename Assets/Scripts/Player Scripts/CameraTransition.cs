using NETWORK_ENGINE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;

    [SerializeField]
    private GameObject lobbyManager;

    [SerializeField]
    private bool started = false;

    [SerializeField]
    private bool moved = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        started = gameManager.GetComponent<Game_Manager_Script>().GameStarted;

       // lobbyManager = GameObject.Find("")
    }

    // Update is called once per frame
    void Update()
    {
        started = gameManager.GetComponent<Game_Manager_Script>().GameStarted;
        if (started == true && moved == false)
        {
            //get owner id
            int owner = gameManager.GetComponent<NetworkID>().Owner;

            //rotate camera
            this.gameObject.transform.Rotate(0, 77.207f, 0);

            //position camera
            GameObject[] leaderArray;
            leaderArray = GameObject.FindGameObjectsWithTag("Unit");
            for(int i = 0; i <= leaderArray.Length; i++)
            {
                if(leaderArray[i].GetComponent<NetworkID>().Owner == owner)
                {
                    this.gameObject.transform.position = leaderArray[i].transform.position - new Vector3(0,0,5f);
                    this.gameObject.transform.GetChild(0).transform.Rotate(90, 0, 0); //12.793
                }
            }
            moved = true;
        }   
    }
}
