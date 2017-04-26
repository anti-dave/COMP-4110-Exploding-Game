using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeScript : MonoBehaviour {

	// This script is simply for displaying an explosion which occurs if the cat touches the player
	void Start () {
        Invoke("explode", 2f);
	}
	
    void explode()
    {
        Destroy(gameObject);
    }
}
