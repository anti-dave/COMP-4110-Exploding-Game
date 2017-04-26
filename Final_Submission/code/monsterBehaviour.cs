using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class monsterBehaviour : NetworkBehaviour {

    public float _speed;
    private Animator anim;
    private float match_time;

    public override void OnStartServer()
    {
        GetComponent<NavMeshAgent2D>().speed = _speed;
        anim = GetComponent<Animator>();
        match_time = 0f;
    }

    [ServerCallback]
    void Update () {
        if(match_time%10 == 0)
        {
            GetComponent<NavMeshAgent2D>().speed += 1;
        }
        match_time += Time.deltaTime;

        Vector3 target = get_target();
        if (transform.position.x - target.x > 0)
        {
            anim.SetTrigger("catLeft");
        }
        if (transform.position.x - target.x <= 0)
        {
            anim.SetTrigger("catRight");
        }
        GetComponent<NavMeshAgent2D>().destination = target;
    }

    // get_target will hold other methods of targeting later when players trigger certain events
    Vector3 get_target() {
        Vector3 target_loc;
        GameObject[] all_players = GameObject.FindGameObjectsWithTag("Player");         // collects all of the players still alive into an array
        target_loc = all_players[nearest_player(all_players)].transform.position;       // finds the nearest player and sets the target for the cat to chase
        return target_loc;
    }

    // finds the player nearest to the cat
    int nearest_player(GameObject[] players){
        int target_player = 0;
        for (int i = 1; i < players.Length; i++) {
            if (distance_from_cat(players[target_player].transform.position) > distance_from_cat(players[i].transform.position)) {
                target_player = i;
            }
        }
        return target_player;
    }

    float distance_from_cat(Vector3 pos)
    {
        return Mathf.Sqrt(Mathf.Pow(pos.x - transform.position.x, 2) + Mathf.Pow(pos.y - transform.position.y, 2));
    }
}