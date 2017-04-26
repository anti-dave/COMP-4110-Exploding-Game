using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WinScript : NetworkBehaviour
{
    public float restartDelay = 5f;
    //public bool playerAlive;

    Animator anim;
     float restartTimer;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    

    int sizeofcount;
    // Update is called once per frame
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //is this how i check if we're last one... no right
        //sizeofcount = NetworkServer.localConnections.Count;
        //if (BehaviourScript.playerAlive == playerAlive && (sizeofcount == 1))

        if(players.Length == 1)
        {
            //anim.SetTrigger("YouWin");
            anim.SetTrigger("WinCondition");
             restartTimer += Time.deltaTime;
        
            if (restartTimer >= restartDelay)
            {
                 Application.LoadLevel(Application.loadedLevel);
             }
        }
    }
}
