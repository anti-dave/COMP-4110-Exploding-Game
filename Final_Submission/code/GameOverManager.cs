using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class GameOverManager : MonoBehaviour {
    public float restartDelay = 5f;
    public bool playerAlive;
   // private GameObject[] active_players;

    Animator anim;
   // float restartTimer;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
       // active_players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        //for(int i = 0; i < active_players.Length; i++)
        //{

        //}

        if (BehaviourScript.playerAlive == false)
        {
            anim.SetTrigger("GameOver");
        }

    }
}
