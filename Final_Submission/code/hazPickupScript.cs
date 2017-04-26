using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class hazPickupScript : NetworkBehaviour {

    public int hazType;
    private Animator anim;
    private float lifetime = 10f;


    void start()
    {
        hazType = (int)Random.Range(0f, 4f);
        anim = GetComponent<Animator>();
    }
	
	void Update () {
        if((lifetime -= Time.deltaTime) <= 0) {
            NetworkServer.Destroy(gameObject);
        }
        switch (hazType)
        {
            case 0:
                anim.SetTrigger("hazAttack");
                break;
            case 1:
                anim.SetTrigger("hazBolt");
                break;
            case 2:
                anim.SetTrigger("hazDefuse");
                break;
            case 3:
                anim.SetTrigger("hazScope");
                break;
            case 4:
                anim.SetTrigger("hazSneak");
                break;
        }
    }
}
