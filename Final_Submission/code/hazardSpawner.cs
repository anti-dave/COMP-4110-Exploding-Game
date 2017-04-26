using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class hazardSpawner : NetworkBehaviour {

    public GameObject hazard_prefab;
    public int hazard_limit = 3;
    private float spawn_timer = 15f;
    private Vector3 position;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spawn_hazard();
	}

    void spawn_hazard()
    {
        spawn_timer -= Time.deltaTime;
        if(spawn_timer <= 0)
        {
            random_spawn();
            spawn_timer = 15f;
        }
    }

    void random_spawn()
    {
        for(int num_spawned = 0; num_spawned < hazard_limit; num_spawned++)
        {
            position = new Vector3(Random.Range(-30f, 30f), Random.Range(-17f, 17f));
            var haz = (GameObject)Instantiate(hazard_prefab, position, Quaternion.identity);
            NetworkServer.Spawn(haz);
        }
    }
}
