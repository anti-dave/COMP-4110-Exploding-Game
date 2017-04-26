using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class petSpawner : NetworkBehaviour {

    public GameObject catPrefab;
    public float spawnX, spawnY;

    public override void OnStartServer()
    {
        Vector3 spawnPos = new Vector3(spawnX, spawnY);
        var cat = (GameObject)Instantiate(catPrefab, spawnPos, Quaternion.Euler(0f,0f,0f));
        NetworkServer.Spawn(cat);
    }
}
